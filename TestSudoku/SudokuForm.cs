using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security;

namespace Sudoku
{
    public partial class SudokuForm : Form
    {
        GameController controller;
        private int SelectedVal;
        private List<Graphics> outlines = new List<Graphics>();
        public void SetController(GameController theController)
        {
            controller = theController;
        }
        public SudokuForm()
        {
            InitializeComponent();
        }

        public void MakeSudoku(Game game)
        {
            int H = menuStrip1.Height + 80 + (50 * (game.gridHeight + 2));
            int W = 40 + (50 * (game.gridWidth + 1));
            setWindowSize(W, H);
            DrawGrid(game);
            DrawControlls(game.numberOfSquares);
        }

        private void setWindowSize(int w,int h)
        {
            Width = w;
            Height = h;
        }

        public void DrawSquare(int x, int y, int w, int h, int t)
        {
            Pen blackPen = new Pen(Color.FromArgb(255, 0, 0, 0), t);
            Graphics g = CreateGraphics();
            Rectangle r = new Rectangle(x, y, w, h);
            outlines.Add(g);
            g.DrawRectangle(blackPen, r);
        }

        public void ClearOutlines()
        {
            if (outlines.Count() != 0)
            {
                foreach(Graphics outline in outlines)
                {
                    outline.Clear(Color.White);
                    outline.Dispose();
                }
                outlines.Clear();
            }
        }

        public void DrawOutLine(Game game)
        {
            ClearOutlines();
            for (int i = 0; i < game.numberOfSquares; i++)
            {
                int index = game.GetBySquare(i, 0);
                int row = game.GetRowByIndex(index);
                int col = game.GetColumnByIndex(index);
                int x = 5 + 25 + 50 * col;
                int y = menuStrip1.Height + 5 + 50 * row;
                int w = 55 * game.squareWidth;
                int h = 55 * game.squareHeight;
                DrawSquare(x, y, w, h, 20);
            }
        }
        public void DrawGrid(Game game)
        {
            Panel squarePanel;
            int[] numbersArray = game.ToArray();
            for (int s = 0; s< game.numberOfSquares; s++)
            {
                int cellIndex = game.GetBySquare(s, 0);
                int row = game.GetRowByIndex(cellIndex);
                int col = game.GetColumnByIndex(cellIndex);
                
                squarePanel = new Panel();
                squarePanel.Name = s.ToString();
                squarePanel.Size = new Size(50*game.squareWidth, 50 * game.squareHeight);
                squarePanel.Location = new Point(row*50, col*50);
                squarePanel.BorderStyle = BorderStyle.FixedSingle;
                
                for(int c = 0; c< game.numberOfSquares; c++)
                {
                    cellIndex = game.GetBySquare(s, c);
                    row = game.GetRowByIndex(cellIndex);
                    col = game.GetColumnByIndex(cellIndex);
                    Button btn = MakeButton("", "Sudoku", numbersArray[cellIndex].ToString(), row, col, 25);
                    squarePanel.Controls.Add(btn);
                }
                Controls.Add(squarePanel);
            }
            //int[] numbersArray = game.ToArray();
            //for (int i = 0; i < numbersArray.Length; i++)
            //{
            //    int row = game.GetRowByIndex(i);
            //    int col = game.GetColumnByIndex(i);
            //    bool isZero = game.originalNumbersArray[i] == 0;
            //    if (isZero)
            //    {
            //        AddButton("", "Sudoku", numbersArray[i].ToString(), row, col, 25);
            //    }
            //    else
            //    {
            //        AddLabel("", "Sudoku", numbersArray[i].ToString(), row, col, 25);
            //    }
            //}
            DrawOutLine(game);
        }

        public void DrawControlls(int n)
        {
            for(int i = 0; i<=n; i++)
            {
                Controls.Add(MakeButton("inputBtn_","Control", i==0?"":i.ToString(), n+1, i, 0));
            }
        }

        protected Button MakeButton(string name, string Tag, string text, int row, int column, int xOffset, bool enabled = true)
        {
            
            int x = 50 * column;
            int y = 50 * row;
            Button cell = new Button
            {
                Name = name + row + "_" + column,
                Height = 50,
                Width = 50,
                Font = new Font("Arial", 20),
                Text = (text == 0.ToString()) ? "" : text,
                Tag = Tag,
                Visible = true,
                Location = new Point(x, y),
                Enabled = enabled
            };
            cell.Click += GridButton_clicked;
            return cell;
        }

        protected void AddLabel(string name, string Tag, string text, int row, int column, int xOffset)
        {
            int x = 10 + xOffset + 50 * column;
            int y = menuStrip1.Height + 10 + 50 * row;
            Controls.Add(new Label
            {
                Name = name + row + "_" + column,
                Height = 50,
                Width = 50,
                Font = new Font("Arial", 20),
                Text = text,
                Tag = Tag,
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = true,
                Location = new Point(x, y)
            });
        }
        private void GridButton_clicked(object sender, EventArgs e)
        {
            Button BtnClicked = (Button)sender;
            string btnText = BtnClicked.Text;
            if (BtnClicked.Name.Contains("inputBtn_"))
            {
                btnText = btnText == "" ? 0.ToString() : btnText;
                SelectedVal = int.Parse(btnText);
            }
            else
            {

                BtnClicked.Text = SelectedVal==0?"":SelectedVal.ToString();
                string[] ColRow = BtnClicked.Name.Split('_');
                int cellIndex = controller.game.GetByRow(int.Parse(ColRow[0]), int.Parse(ColRow[1]));
                controller.game.SetCell(SelectedVal, cellIndex);
            }
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.game.ToCSV();
        }

        private void gameSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadGame(true);
        }

        private void newGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LoadGame(false);
        }

        private void LoadGame(bool isLoadingSave)
        {
            if (controller.game.numbersArray.Length > 0)
            {
                RemoveGrid(controller.game.numbersArray.Length + controller.game.gridWidth + 1);
            }
            controller.game.FromCSV(GetFilePath(), isLoadingSave);
            MakeSudoku(controller.game);
        }

        private void RemoveGrid(int count)
        {
            List<Control> itemsToRemove = new List<Control>();
            foreach (Control control in Controls)
            {
                if (control.Tag != null && (control.Tag.ToString() == "Sudoku" || control.Tag.ToString() == "Control"))
                {
                    itemsToRemove.Add(control);
                }
            }
            foreach(Control c in itemsToRemove)
            {
                Controls.Remove(c);
            }
        }

        private string GetFilePath()
        {
            var filePath = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                try
                {
                    filePath = openFileDialog1.FileName;
                    return filePath;
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show($"Security error.\n\nError message: {ex.Message}\n\n" +
                    $"Details:\n\n{ex.StackTrace}");
                    filePath = "";
                }
            }
            return filePath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controls.RemoveAt(Controls.Count-1);
        }

        private void loadSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SudokuForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
        private void Button1_EnabledChanged(Button sender, EventArgs e)
        {
            sender.ForeColor = sender.Enabled == false ? Color.Blue : Color.Red;
            sender.BackColor = Color.AliceBlue;
        }

    }
}

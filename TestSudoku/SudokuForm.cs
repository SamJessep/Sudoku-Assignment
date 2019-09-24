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
            drawGrid(game);
            DrawControlls(game.numberOfSquares);
            int H = menuStrip1.Height + 80 + (50 * (game.gridHeight + 2));  
            int W = 40 + (50 * (game.gridWidth+1));
            setWindowSize(W, H);
        }

        private void setWindowSize(int w,int h)
        {
            Width = w;
            Height = h;
        }

        public void drawGrid(Game game)
        {
            int[] numbersArray = game.ToArray();
            for (int i = 0; i < numbersArray.Length; i++)
            {
                int row = game.GetRowByIndex(i);
                int col = game.GetColumnByIndex(i);
                bool isZero = numbersArray[i] == 0;
                if (isZero)
                { 
                    AddButton("", numbersArray[i].ToString(), row, col);
                }
                else
                {
                    AddLabel("", numbersArray[i].ToString(), row, col);
                }
            }
        }

        public void DrawControlls(int n)
        {
            for(int i = 0; i<=n; i++)
            {
                AddButton("inputBtn_", i==0?"":i.ToString(), n+1, i);
            }
        }

        protected void AddButton(string name, string text, int row, int column)
        {
            
            int x = 10 + 50 * column;
            int y = menuStrip1.Height+10 + 50 * row ;
            Button cell = new Button();
            cell.Name = name+row+"_"+column;
            cell.Height = 50;
            cell.Width = 50;
            cell.Font = new Font("Arial", 20);
            cell.Text = text;
            cell.Visible = true;
            cell.Location = new Point(x,y);
            cell.Click += GridButton_clicked;
            Controls.Add(cell);
        }

        protected void AddLabel(string name, string text, int row, int column)
        {
            int x = 10 + 50 * column;
            int y = menuStrip1.Height + 10 + 50 * row;
            Label cell = new Label();
            cell.Name = name + row + "_" + column;
            cell.Height = 50;
            cell.Width = 50;
            cell.Font = new Font("Arial", 20);
            cell.Text = text;
            cell.BorderStyle = BorderStyle.FixedSingle;
            cell.AutoSize = false;
            cell.TextAlign = ContentAlignment.MiddleCenter;
            cell.Visible = true;
            cell.Location = new Point(x, y);
            Controls.Add(cell);
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
            LoadGame(false);
        }

        private void newGameToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            LoadGame(true);
        }

        private void LoadGame(bool isLoadingSave)
        {
            RemoveGrid(controller.game.numbersArray.Length + controller.game.gridWidth + 1);
            controller.game.FromCSV(GetFilePath(), isLoadingSave);
            MakeSudoku(controller.game);
        }

        private void RemoveGrid(int count)
        {
            for (int i = count; i > 0; i--)
            {
                Controls.RemoveAt(Controls.Count - 1);
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
    }
}

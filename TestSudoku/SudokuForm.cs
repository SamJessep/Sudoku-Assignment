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
        private const int BoxWidth = 50;
        GameController controller;
        private int SelectedVal;

        public void SetController(GameController theController)
        {
            controller = theController;
        }
        public SudokuForm()
        {
            InitializeComponent();
            AutoSize = true;
        }

        public void MakeSudoku(Game game)
        {
            int H = 80 + BoxWidth * (game.gridHeight + 2);
            int W = 40 + BoxWidth * (game.gridWidth + 1);
            setWindowSize(W, H);
            DrawGrid(game);
            DrawControls(game.numberOfSquares);
        }

        private void setWindowSize(int w,int h)
        {
            Width = w;
            Height = h;
        }

        public Button GetCellButton(Game game, int c, int s)
        {
            int[] numbersArray = game.ToArray();
            int posIndex = game.GetBySquare(0, c);
            int cellIndex = game.GetBySquare(s, c);
            int row = game.GetRowByIndex(posIndex);
            int col = game.GetColumnByIndex(posIndex);
            Button btn = MakeButton(
                game.GetRowByIndex(cellIndex) + "_" + game.GetColumnByIndex(cellIndex),
                "Sudoku",
                numbersArray[cellIndex].ToString(),
                row,
                col,
                game.numbersArray[cellIndex] == game.originalNumbersArray[cellIndex] && game.numbersArray[cellIndex] != 0
            );
            btn.BackColor = Color.White;
            return btn;
        }
        public void DrawGrid(Game game)
        {
            Panel gamePanel = new Panel
            {
                Name = "SudokuGame",
                Size = new Size((game.gridWidth * BoxWidth) + 5, (game.gridHeight * BoxWidth) + 5),
                Anchor = (AnchorStyles.Top | AnchorStyles.Left),
                BorderStyle = BorderStyle.None,
            };
            gamePanel.Location = new Point((Width - gamePanel.Width) / 2, MenuPanel.Height);

            Panel squarePanel;
            for (int s = 0; s < game.numberOfSquares; s++)
            {
                int cellIndex = game.GetBySquare(s, 0);
                int row = game.GetRowByIndex(cellIndex);
                int col = game.GetColumnByIndex(cellIndex);

                squarePanel = new Panel
                {
                    Name = s.ToString(),
                    AutoSize = true,
                    Size = new Size(BoxWidth * game.squareWidth, BoxWidth * game.squareHeight),
                    Location = new Point(col * BoxWidth, row * BoxWidth),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.Black
                };

                for (int c = 0; c< game.numberOfSquares; c++)
                {
                    squarePanel.Controls.Add(GetCellButton(game, c, s));
                }
                gamePanel.Controls.Add(squarePanel);
                
            }
            Controls.Add(gamePanel);
        }

        public void DrawControls(int n)
        {
            Panel SudokuControls = new Panel
            {
                Name = "SudokuControls",
                Size = new Size(((n + 1) * BoxWidth), 50),
                Anchor = (AnchorStyles.Top),
                BorderStyle = BorderStyle.None,
                BackColor = Color.Red
            };
            SudokuControls.Location = new Point((Width-SudokuControls.Width)/2, (n + 1) * BoxWidth + MenuPanel.Height);
            for (int i = 0; i<=n; i++)
            {
                SudokuControls.Controls.Add(MakeButton("inputBtn_","Control", i.ToString(), 0, i));
            }
            Controls.Add(SudokuControls);
        }

        protected Button MakeButton(string name, string Tag, string text, int row, int column, bool isStartingNumber = false)
        {
            
            int x = BoxWidth * column;
            int y = BoxWidth * row;
            bool isControl = Tag == "Control";
            Button cell = new Button
            {
                Name = name,
                Height = BoxWidth,
                Width = BoxWidth,
                Font = new Font("Arial", 20),
                Text = (text == 0.ToString()) ? "" : text,
                Tag = Tag,
                Visible = true,
                Location = new Point(x, y),
                Enabled = isControl || !isStartingNumber
            };
            cell.Click += GridButton_clicked;
            return cell;
        }

        public Label AddLabel(string name, string Tag, string text, int row, int column)
        {
            int x = BoxWidth * column;
            int y = BoxWidth * row;
            Label l = new Label
            {
                Name = name + row + "_" + column,
                Height = BoxWidth,
                Width = BoxWidth,
                Font = new Font("Arial", 20),
                Text = text,
                Tag = Tag,
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = true,
                Location = new Point(x, y)
            };
            return l;
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
            
        }

        private void ClearGame()
        {
            if (Controls.ContainsKey("SudokuControls")){
                Controls["SudokuControls"].Controls.Clear();
                Controls.Remove(Controls["SudokuControls"]);
            }
            if (Controls.ContainsKey("SudokuGame"))
            {
                Controls["SudokuGame"].Controls.Clear();
                Controls.Remove(Controls["SudokuGame"]);
            }
        }

        private string GetFilePath()
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            var filePath = "";
            theDialog.Title = "Select Sudoku CSV file";
            theDialog.Filter = "CSV files|*.csv";
            theDialog.InitialDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Export")); ;
            if (theDialog.ShowDialog() == DialogResult.OK)
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
                    filePath = null;
                }
            }
            else
            {
                filePath = null;
            }
            return filePath;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Controls.RemoveAt(Controls.Count-1);
        }

        private void Button1_EnabledChanged(Button sender, EventArgs e)
        {
            sender.ForeColor = sender.Enabled == false ? Color.Blue : Color.Red;
            sender.BackColor = Color.AliceBlue;
        }

        private void Open_Click(object sender, EventArgs e)
        {
            string path = GetFilePath();
            //Load File for game preview
            if(path != null)
            {
                controller.game.FromCSV(path, true);
                ClearGame();
                loadForm f = new loadForm(this, controller.game);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    controller.game.FromCSV(path, f.loadingGameSave);
                    MakeSudoku(controller.game);
                    MenuPanel.Controls["SaveBtn"].Visible = true;
                }
                else
                {
                    MessageBox.Show("Game Load aborted");
                    MenuPanel.Controls["SaveBtn"].Visible = false;
                }
            }
        }

        private void saveButton_click(object sender, EventArgs e)
        {
            controller.game.ToCSV();
            MessageBox.Show("Game Saved");
        }
    }
}

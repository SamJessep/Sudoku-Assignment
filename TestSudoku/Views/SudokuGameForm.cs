using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Security;
using System.Collections.Generic;

namespace Sudoku
{
    public partial class SudokuGameForm : FormView, IGameView
    {
        private const int BoxWidth = 50;
        GameController controller;
        Panel GamePanel;
        private int textFontSize = 20;

        public SudokuGameForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void OpenBtn_Clicked(object sender, EventArgs e)
        {
            controller.SelectGame();
        }

        private void SaveBtn_Clicked(object sender, EventArgs e)
        {
            controller.SaveGame();
        }

        private void CheckBtn_Clicked(Object sender, EventArgs e)
        {
            Color color = controller.game.IsPuzzleValid() ? Color.Green : Color.Red;
            Button btn = (Button)sender;
            btn.BackColor = color;
        }

        private void EditorBtn_Clicked(object sender, EventArgs e)
        {
            controller.StartEditor();
        }

        private void ResetBtn_Clicked(object sender, EventArgs e)
        {
            controller.ResetGame();
        }

        public void SetController(GameController theController)
        {
            controller = theController;
        }

        public void Start()
        {
            Application.EnableVisualStyles();
            Application.Run(this);
        }

        public void Stop()
        {
            Close();
        }

        public void DrawSudoku(Game game)
        {
            int H = 80 + BoxWidth * (game.gridHeight + 2);
            int W = 40 + BoxWidth * (game.gridWidth + 1);
            setWindowSize(W, H);
            GamePanel = new GameGrid(game, 50, controller).MakeSudoku();
            AddCellValidator(GamePanel);
            GamePanel.Location = new Point((Width - GamePanel.Width) / 2, MenuPanel.Height);
            Controls.Add(GamePanel);
        }

        public (bool, bool) ChooseGame()
        {
            LoadGameForm f = new LoadGameForm(this, controller.game);
            bool gameWasChosen = f.ShowDialog() == DialogResult.OK;
            bool loadingGameSave = f.loadingGameSave;
            return (gameWasChosen, loadingGameSave);
        }

        public void ResetGame()
        {
            foreach (Panel p in Controls["Sudoku"].Controls["SudokuGame"].Controls)
            {
                foreach (Button cell in p.Controls)
                {
                    cell.BackColor = Color.White;
                    if (cell.Enabled)
                    {
                        cell.Text = "";
                    }
                }
            }
        }

        public void UpdateTime()
        {
            Label TimeLbl = (Label)Controls["MenuPanel"].Controls["CurrentTime"];
            TimeLbl.Text = controller.GetTimeAsString();
        }



        public void ToggleGameMenu(bool visible)
        {
            MenuPanel.Controls["SaveBtn"].Visible = visible;
            MenuPanel.Controls["Check"].Visible = visible;
            MenuPanel.Controls["ResetBtn"].Visible = visible;
        }

        private void setWindowSize(int w, int h)
        {
            Width = w;
            Height = h;
        }

        public void ClearGameScreen()
        {
            if (Controls.ContainsKey("Sudoku"))
            {
                Controls["Sudoku"].Controls.Clear();
                Controls.Remove(Controls["Sudoku"]);
            }
        }

        private List<Button> GetButtons(int row , bool isCol = false)
        {
            int cellRow;
            int cellCol;
            List<Button> btns = new List<Button>();
            foreach (Panel square in GamePanel.Controls["SudokuGame"].Controls)
            {
                foreach(Button cell in square.Controls)
                {
                    cellRow = int.Parse(cell.Name.Split('_')[0]);
                    cellCol = int.Parse(cell.Name.Split('_')[1]);
                    if (cellCol == row && isCol)
                    {
                        btns.Add(cell);
                    }
                    if (cellRow == row && !isCol)
                    {
                        btns.Add(cell);
                    }
                }
            }
            return btns;
        }

        private void AddCellValidator(Panel GamePanel)
        {
            foreach(Panel square in GamePanel.Controls["SudokuGame"].Controls)
            {
                foreach (Button cell in square.Controls)
                {
                    cell.Click += ValidateCell;
                }
            }
        }

        public void ValidateCell(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string[] nameParts = b.Name.Split('_');
            int row = int.Parse(nameParts[0]);
            int col = int.Parse(nameParts[1]);
            //List<Button> rowBtns = GetButtons(row);
            //List<Button> colBtns = GetButtons(col, true);
            //ShowStatus(colBtns, controller.game.ColumnValid(col));
            //ShowStatus(rowBtns, controller.game.RowValid(row));
            b.Parent.Parent.Parent.Controls.Add(makeTick());
        }

        private Control makeTick()
        {
            PictureBox tick = new PictureBox
            {
                Image = Image.FromFile("..//..//Images//check.png"),
                Size = new Size(50, 50),
                Location = new Point(100, 100),
                BackgroundImageLayout = ImageLayout.Zoom
            };
            return tick;
        }
        private void ShowStatus(List<Button> btns, bool valid)
        {
            foreach(Button btn in btns)
            {
                btn.BackColor = valid ? Color.Green : Color.White;
            }
        }

        public Label AddLabel(string name, string text, int row, int column)
        {
            int x = BoxWidth * column;
            int y = BoxWidth * row;
            int fontSize = text.ToCharArray().Length > 1 ? (int)(textFontSize * 0.75) : textFontSize;
            Label l = new Label
            {
                Name = name + row + "_" + column,
                Height = BoxWidth,
                Width = BoxWidth,
                Font = new Font("Arial", fontSize),
                Text = text,
                BorderStyle = BorderStyle.FixedSingle,
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = true,
                Location = new Point(x, y)
            };
            return l;
        }
        
    }
}

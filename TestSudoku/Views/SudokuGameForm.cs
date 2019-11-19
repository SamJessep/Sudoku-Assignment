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

        private void CheckForComplete(object sender, EventArgs e)
        {
            if (controller.game.isPuzzleCompleted())
            {
                controller.GameWon();
                UpdateHighScore();
            }
        }

        private void EditorBtn_Clicked(object sender, EventArgs e)
        {
            controller.StartEditor();
        }

        private void ResetBtn_Clicked(object sender, EventArgs e)
        {
            controller.ResetGame();
        }

        public new void SetController(GameController theController)
        {
            controller = theController;
        }

        public new void Start()
        {
            Application.EnableVisualStyles();
            Application.Run(this);
        }

        public new void Stop()
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
            UpdateHighScore();
        }

        public (bool, bool) ChooseGame()
        {
            LoadGameForm f = new LoadGameForm(this, controller.game);
            bool gameWasChosen = f.ShowDialog() == DialogResult.OK;
            bool loadingGameSave = f.loadingGameSave;
            ToggleGameMenu(gameWasChosen);
            return (gameWasChosen, loadingGameSave);
        }

        public void ResetGame()
        {
            Controls.Remove(Controls["Sudoku"]);
            DrawSudoku(controller.game);
            controller.StopTimer();
            controller.StartTimer();
            UpdateTime();
        }

        public void UpdateTime()
        {
            Label TimeLbl = GameTimer;
            TimeLbl.Text = controller.GetTimeAsString();
        }

        public void UpdateHighScore()
        {
            Label HighScoreLbl = Highscore;
            HighScoreLbl.Text = "Highscore: " + controller.game.highScore;
        }

        public void ToggleGameMenu(bool visible)
        {
            GameHUD.Visible = visible;
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

        private List<Button> GetButtonsFromSquare(int squareIndex)
        {
            List<Button> btns = new List<Button>();
            foreach (Button cell in GamePanel.Controls["SudokuGame"].Controls[squareIndex.ToString()].Controls)
            {
              btns.Add(cell);
            }
            return btns;
        }

        private void AddCellValidator(Panel GamePanel)
        {
            int n = controller.game.numberOfSquares;
            foreach(Panel square in GamePanel.Controls["SudokuGame"].Controls)
            {
                foreach (Button cell in square.Controls)
                {
                    cell.Click += ValidateCell;
                    cell.Click += CheckForComplete;
                }
            }
            for(int i = 0; i<n; i++)
            {
                GamePanel.Controls.Add(makeTick(n,i));
                GamePanel.Controls.Add(makeTick(i,n));    
            }
        }

        public void ValidateCell(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string[] nameParts = b.Name.Split('_');
            int row = int.Parse(nameParts[0]);
            int col = int.Parse(nameParts[1]);
            int squareIndex = controller.game.GetSquareFromIndex(controller.game.GetByColumn(col, row));
            List<Button> rowBtns = GetButtons(row);
            List<Button> colBtns = GetButtons(col, true);
            List<Button> squareBtns = GetButtonsFromSquare(squareIndex);
            ShowStatus(colBtns, controller.game.ColumnValid(col));
            ShowStatus(rowBtns, controller.game.RowValid(row));
            ShowStatus(squareBtns, controller.game.SquareValid(squareIndex));
            ShowTicStatus(col, controller.game.ColumnValid(col), row, controller.game.RowValid(row));
        }

        private Control makeTick(int row, int col)
        {
            PictureBox tick = new PictureBox
            {
                Name = row + "_" + col,
                BackgroundImage = Image.FromFile("..//..//Images//check.png"),
                Size = new Size(50, 50),
                Location = new Point(GamePanel.Controls["SudokuGame"].Left + col*50, row*50),
                BackgroundImageLayout = ImageLayout.Zoom,
                Visible = false
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

        private void ShowTicStatus(int colNum, bool colValid, int rowNum, bool rowValid)
        {
            PictureBox Coltick = (PictureBox)GamePanel.Controls[controller.game.numberOfSquares + "_" + colNum];
            PictureBox Rowtick = (PictureBox)GamePanel.Controls[rowNum + "_" + controller.game.numberOfSquares];
            Rowtick.Visible = (Rowtick.Name.Split('_')[0] == rowNum.ToString() && rowValid);
            Coltick.Visible = (Coltick.Name.Split('_')[1] == colNum.ToString() && colValid);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Sudoku
{
    class GameGrid
    {
        private object controller;
        private Panel sudokuPanel;
        private Panel gameGrid;
        private Game game;
        private int BoxWidth;
        private int textFontSize = 20;
        private int SelectedVal = 0;

        public GameGrid(Game g, int w, object c)
        {
            controller = c;
            BoxWidth = w;
            game = g;
            sudokuPanel = new Panel
            {
                Name = "Sudoku",
                Size = new Size(((game.gridWidth + 2) * BoxWidth), ((game.gridHeight + 2) * BoxWidth) + 5),
                Anchor = (AnchorStyles.Top | AnchorStyles.Left),
                BorderStyle = BorderStyle.None,
                AutoSize = true
            };
        }

        public Panel MakeSudoku()
        {
            sudokuPanel.Controls.Add(MakeGamePanel());
            Panel gameControls = MakeControls(game.numberOfSquares);
            sudokuPanel.Controls.Add(gameControls);
            return sudokuPanel;
        }

        public Panel MakeControls(int numberOfControls)
        {
            Panel gameControls = new Panel
            {
                Name = "SudokuControls",
                Size = new Size(((numberOfControls + 1) * BoxWidth), 50),
                Anchor = (AnchorStyles.Top),
                BorderStyle = BorderStyle.None,
            };
            gameControls.Location = new Point((sudokuPanel.Width - gameControls.Width) / 2, BoxWidth * (numberOfControls + 1));
            for (int i = 0; i <= numberOfControls; i++)
            {
                Button cell = MakeButton("inputBtn_", i.ToString(), 0, i);
                cell.Click += GridButton_clicked;
                gameControls.Controls.Add(cell);
            }
            return gameControls;
        }

        public Panel MakeGamePanel()
        {
            gameGrid = new Panel
            {
                Name = "SudokuGame",
                Size = new Size((game.gridWidth * BoxWidth) + 5, (game.gridHeight * BoxWidth) + 5),
                Anchor = (AnchorStyles.Top | AnchorStyles.Left),
                BorderStyle = BorderStyle.None,
            };
            gameGrid.Location = new Point((sudokuPanel.Width - gameGrid.Width) / 2, 0);
            for (int s = 0; s < game.numberOfSquares; s++)
            {
                gameGrid.Controls.Add(MakeSquare(s));
            }
            return gameGrid;
        }

        private Panel MakeSquare(int s)
        {
            int cellIndex = game.GetBySquare(s, 0);
            int row = game.GetRowByIndex(cellIndex);
            int col = game.GetColumnByIndex(cellIndex);

            Panel squarePanel = new Panel
            {
                Name = s.ToString(),
                AutoSize = true,
                Size = new Size(BoxWidth * game.squareWidth, BoxWidth * game.squareHeight),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.Black
            };
            squarePanel.Location = new Point(col * BoxWidth, row * BoxWidth);
            for (int c = 0; c < game.numberOfSquares; c++)
            {
                squarePanel.Controls.Add(GetCellButton(game, c, s));
            }
            return squarePanel;
        }

        private Button GetCellButton(Game game, int c, int s)
        {
            int[] numbersArray = game.ToArray();
            int posIndex = game.GetBySquare(0, c);
            int cellIndex = game.GetBySquare(s, c);
            int row = game.GetRowByIndex(posIndex);
            int col = game.GetColumnByIndex(posIndex);
            Button btn = MakeButton(
                game.GetRowByIndex(cellIndex) + "_" + game.GetColumnByIndex(cellIndex),
                numbersArray[cellIndex].ToString(),
                row,
                col,
                game.numbersArray[cellIndex] == game.originalNumbersArray[cellIndex] && game.numbersArray[cellIndex] != 0
            );
            btn.Click += GridButton_clicked;
            btn.BackColor = Color.White;
            return btn;
        }

        private Button MakeButton(string name, string text, int row, int column, bool isStartingNumber = false)
        {

            int x = BoxWidth * column;
            int y = BoxWidth * row;
            int fontSize = text.ToCharArray().Length > 1 ? (int)(textFontSize * 0.75) : textFontSize;
            Button cell = new Button
            {
                Name = name,
                Height = BoxWidth,
                Width = BoxWidth,
                Font = new Font("Arial", fontSize),
                Text = (text == 0.ToString()) ? "" : text,
                Visible = true,
                Location = new Point(x, y),
                Enabled = !isStartingNumber
            };
            return cell;
        }

        private void GridButton_clicked(object sender, EventArgs e)
        {
            Button BtnClicked = (Button)sender;
            string btnText = BtnClicked.Text;
            if (BtnClicked.Name.Contains("inputBtn_"))
            {
                //Changing the selected number to input into sudoku
                UpdateSelectedValue(btnText);
            }
            else
            {
                //changing a cell on the sudoku game
                InputNumberOnSudoku(BtnClicked, btnText);
                if (controller is GameController && isComplete)
                {
                    GameController c = (GameController)controller;
                    c.StopTimer();
                    c.GameWon();
                }
            }
        }

        private bool isComplete => game.IsPuzzleValid();

        private void UpdateSelectedValue(string btnText)
        {
            //Changing the selected number to input into sudoku
            btnText = btnText == "" ? 0.ToString() : btnText;
            SelectedVal = int.Parse(btnText);
            HighlightSelected();
        }

        private void InputNumberOnSudoku(Button BtnClicked, string btnText)
        {
            //changing a cell on the sudoku game
            BtnClicked.Text = SelectedVal == 0 ? "" : SelectedVal.ToString();
            int fontSize = BtnClicked.Text.Length > 1 ? (int)(textFontSize * 0.75) : fontSize = textFontSize;
            BtnClicked.Font = new Font("Arial", fontSize);
            string[] ColRow = BtnClicked.Name.Split('_');
            int cellIndex = game.GetByRow(int.Parse(ColRow[0]), int.Parse(ColRow[1]));
            game.SetCell(SelectedVal, cellIndex);
        }
        private void HighlightSelected()
        {
            foreach (Button btn in sudokuPanel.Controls["SudokuControls"].Controls)
            {
                if (btn.Text == SelectedVal.ToString() || (btn.Text == "" && SelectedVal == 0))
                {
                    btn.BackColor = Color.White;
                }
                else
                {
                    btn.BackColor = Color.LightGoldenrodYellow;
                }
            }
        }
    }
}

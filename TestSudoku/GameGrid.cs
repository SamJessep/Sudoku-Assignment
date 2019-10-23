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
        private Panel gamePanel;
        private Game game;
        private Form parent;
        private int BoxWidth;
        private int textFontSize = 20;
        private int SelectedVal = 0;
        
        public GameGrid(Game g, Form p, int w)
        {
            BoxWidth = w;
            game = g;
            parent = p;
            gamePanel = new Panel
            {
                Name = "SudokuGame",
                Size = new Size((game.gridWidth * BoxWidth) + 5, (game.gridHeight * BoxWidth) + 5),
                Anchor = (AnchorStyles.Top | AnchorStyles.Left),
                BorderStyle = BorderStyle.None,
            };
            gamePanel.Location = new Point((parent.Width - gamePanel.Width) / 2, 0);
        }

        public Panel MakeSudoku()
        {
            MakeGamePanel();
            Panel GridControls = MakeControls(game.numberOfSquares);
            gamePanel.Controls.Add(GridControls);
            return gamePanel;
        }

        public Panel MakeControls(int numberOfControls)
        {
            Panel SudokuControls = new Panel
            {
                Name = "SudokuControls",
                Size = new Size(((numberOfControls + 1) * BoxWidth), 50),
                Anchor = (AnchorStyles.Top),
                BorderStyle = BorderStyle.None,
            };
            SudokuControls.Location = new Point((parent.Width - SudokuControls.Width) / 2, gamePanel.Height + BoxWidth);
            for (int i = 0; i <= numberOfControls; i++)
            {
                Button cell = MakeButton("inputBtn_", "Control", i.ToString(), 0, i, game);
                cell.Click += GridButton_clicked;
                SudokuControls.Controls.Add(cell);
            }
            return SudokuControls;
        }

        public Panel MakeGamePanel()
        {
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

                for (int c = 0; c < game.numberOfSquares; c++)
                {
                    Button cell = GetCellButton(game, c, s);
                    cell.Click += GridButton_clicked;
                    squarePanel.Controls.Add(cell);

                }
                gamePanel.Controls.Add(squarePanel);

            }
            return gamePanel;
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
                game,
                game.numbersArray[cellIndex] == game.originalNumbersArray[cellIndex] && game.numbersArray[cellIndex] != 0
            );
            btn.BackColor = Color.White;
            return btn;
        }

        protected Button MakeButton(string name, string Tag, string text, int row, int column, Game game, bool isStartingNumber = false)
        {

            int x = BoxWidth * column;
            int y = BoxWidth * row;
            int fontSize = text.ToCharArray().Length > 1 ? (int)(textFontSize * 0.75) : textFontSize;
            bool isControl = Tag == "Control";
            Button cell = new Button
            {
                Name = name,
                Height = BoxWidth,
                Width = BoxWidth,
                Font = new Font("Arial", fontSize),
                Text = (text == 0.ToString()) ? "" : text,
                Tag = Tag,
                Visible = true,
                Location = new Point(x, y),
                Enabled = isControl || !isStartingNumber
            };
            return cell;
        }

        public void GridButton_clicked(object sender, EventArgs e)
        {
            Button BtnClicked = (Button)sender;
            string btnText = BtnClicked.Text;
            if (BtnClicked.Name.Contains("inputBtn_"))
            {
                btnText = btnText == "" ? 0.ToString() : btnText;
                SelectedVal = int.Parse(btnText);
                //HighlightSelected(Controls);
            }
            else
            {

                BtnClicked.Text = SelectedVal == 0 ? "" : SelectedVal.ToString();
                int fontSize = BtnClicked.Text.Length > 1 ? (int)(textFontSize * 0.75) : fontSize = textFontSize;
                BtnClicked.Font = new Font("Arial", fontSize);
                string[] ColRow = BtnClicked.Name.Split('_');
                int cellIndex = game.GetByRow(int.Parse(ColRow[0]), int.Parse(ColRow[1]));
                game.SetCell(SelectedVal, cellIndex);
            }
        }
    }
}

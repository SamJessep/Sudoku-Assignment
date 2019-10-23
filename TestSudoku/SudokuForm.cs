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
        private int textFontSize = 20;

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
            Controls.Add(DrawGrid(game));
            Controls.Add(DrawControls(game.numberOfSquares, game));
        }

        public void DrawGame(Game game)
        {
            Controls.Add(DrawGrid(game));
            Controls.Add(DrawControls(game.numberOfSquares, game));
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
                game,
                game.numbersArray[cellIndex] == game.originalNumbersArray[cellIndex] && game.numbersArray[cellIndex] != 0
            );
            btn.BackColor = Color.White;
            return btn;
        }
        public Panel DrawGrid(Game game)
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
                    Button cell = GetCellButton(game, c, s);
                    cell.Click += GridButton_clicked;
                    squarePanel.Controls.Add(cell);
                    
                }
                gamePanel.Controls.Add(squarePanel);
                
            }
            return gamePanel;
        }

        public Panel DrawControls(int numberOfControls, Game g)
        {
            Panel SudokuControls = new Panel
            {
                Name = "SudokuControls",
                Size = new Size(((numberOfControls + 1) * BoxWidth), 50),
                Anchor = (AnchorStyles.Top),
                BorderStyle = BorderStyle.None,
            };
            SudokuControls.Location = new Point((Width-SudokuControls.Width)/2, (numberOfControls + 1) * BoxWidth + MenuPanel.Height);
            for (int i = 0; i<= numberOfControls; i++)
            {
                Button cell = MakeButton("inputBtn_","Control", i.ToString(), 0, i, g);
                cell.Click += GridButton_clicked;
                SudokuControls.Controls.Add(cell);
            }
            return SudokuControls;
        }

        protected Button MakeButton(string name, string Tag, string text, int row, int column, Game game, bool isStartingNumber = false)
        {
            
            int x = BoxWidth * column;
            int y = BoxWidth * row;
            int fontSize = text.ToCharArray().Length > 1 ? (int)(textFontSize*0.75) : textFontSize;
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

        public Label AddLabel(string name, string Tag, string text, int row, int column)
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
                Tag = Tag,
                BorderStyle = BorderStyle.FixedSingle,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Visible = true,
                Location = new Point(x, y)
            };
            return l;
        }
        
        public void GridButton_clicked(object sender, EventArgs e)
        {
            Button BtnClicked = (Button)sender;
            string btnText = BtnClicked.Text;
            if (BtnClicked.Name.Contains("inputBtn_"))
            {
                btnText = btnText == "" ? 0.ToString() : btnText;
                SelectedVal = int.Parse(btnText);
                HighlightSelected(Controls);
            }
            else
            {

                BtnClicked.Text = SelectedVal==0?"":SelectedVal.ToString();
                int fontSize = BtnClicked.Text.Length > 1 ? (int)(textFontSize*0.75) : fontSize = textFontSize;
                BtnClicked.Font = new Font("Arial", fontSize);
                string[] ColRow = BtnClicked.Name.Split('_');
                int cellIndex = controller.game.GetByRow(int.Parse(ColRow[0]), int.Parse(ColRow[1]));
                controller.game.SetCell(SelectedVal, cellIndex);
            }
        }

        private void HighlightSelected(Control.ControlCollection c)
        {
            foreach (Button btn in c["SudokuControls"].Controls)
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
            theDialog.InitialDirectory = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\GameSaves")); ;
            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filePath = theDialog.FileName;
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
                if (controller.game.originalNumbersArray != null)
                {
                    bool hasSaved = Enumerable.SequenceEqual(controller.game.numbersArray, controller.game.lastSaveNumbersArray);
                    if (!hasSaved)
                    {
                        var confirmResult = MessageBox.Show("Are you sure you want to load a new file, you will lose your current progress", "Warning",
                                         MessageBoxButtons.YesNo);
                        if (confirmResult == DialogResult.No)
                        {
                            return;
                        }
                    }
                }
                controller.game.FromCSV(path, true);
                ClearGame();
                loadForm f = new loadForm(this, controller.game);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    controller.game.FromCSV(path, f.loadingGameSave);
                    MakeSudoku(controller.game);
                    MenuPanel.Controls["SaveBtn"].Visible = true;
                    MenuPanel.Controls["Check"].Visible = true;
                }
                else
                {
                    MessageBox.Show("Game Load aborted");
                    MenuPanel.Controls["SaveBtn"].Visible = false;
                    MenuPanel.Controls["Check"].Visible = false;
                }
            }
        }

        private void saveButton_click(object sender, EventArgs e)
        {
            controller.game.SaveGame();
            MessageBox.Show("Game Saved");
        }

        private void checkBtnClicked(Object sender, EventArgs e)
        {
            Color color = controller.game.IsPuzzleValid() ? Color.Green : Color.Red;
            Button btn = (Button)sender;
            btn.BackColor = color;
        }

        private void SudokuMaker_Click(object sender, EventArgs e)
        {
            SudokuMaker SM = new SudokuMaker(controller.game, this);
            SM.Show();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            controller.game.numbersArray = controller.game.originalNumbersArray;
            foreach (Panel p in Controls["SudokuGame"].Controls)
            {
                foreach(Button cell in p.Controls)
                {
                    if (cell.Enabled)
                    {
                        cell.Text = "";
                    }
                }
            }
        }
    }
}

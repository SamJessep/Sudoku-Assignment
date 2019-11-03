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
            Panel GamePanel = new GameGrid(game, this, 50).MakeSudoku();
            GamePanel.Location = new Point((Width - GamePanel.Width) / 2, MenuPanel.Height);
            Controls.Add(GamePanel);
            Timer t = new Timer
            {
                Interval = 1000,
            };
            t.Tick += UpdateTime;
            t.Start();
            controller.game.StartTimer();
        }

        private void setWindowSize(int w,int h)
        {
            Width = w;
            Height = h;
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

        private void ClearGame()
        {
            if (Controls.ContainsKey("Sudoku")){
                Controls["Sudoku"].Controls.Clear();
                Controls.Remove(Controls["Sudoku"]);
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
                    MenuPanel.Controls["ResetBtn"].Visible = true;
                }
                else
                {
                    MessageBox.Show("Game Load aborted");
                    MenuPanel.Controls["SaveBtn"].Visible = false;
                    MenuPanel.Controls["Check"].Visible = false;
                    MenuPanel.Controls["ResetBtn"].Visible = false;
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
            SudokuMaker SM = new SudokuMaker();
            SM.Show();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            controller.game.numbersArray = controller.game.originalNumbersArray;
            foreach (Panel p in Controls["Sudoku"].Controls["SudokuGame"].Controls)
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

        public string GetTimeAsString(Game g)
        {
            int totalSeconds = g.timeTaken;
            int sec = totalSeconds % 60;
            int min = (int)Math.Floor(d: (decimal)totalSeconds / 60);
            string secAsString = sec.ToString().Length == 1 ? "0" + sec : sec.ToString();
            string minAsString = min.ToString().Length == 1 ? "0" + min : min.ToString();
            string timeString = minAsString + ":" + secAsString;
            return timeString;
        }

        private void UpdateTime(object sender, EventArgs e)
        {
            Label TimeLbl = (Label)Controls["MenuPanel"].Controls["CurrentTime"];
            TimeLbl.Text = GetTimeAsString(controller.game);
        }
    }
}

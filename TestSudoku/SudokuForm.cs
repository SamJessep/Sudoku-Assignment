using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Security;

namespace Sudoku
{
    public partial class SudokuForm : Form, IView
    {
        private const int BoxWidth = 50;
        GameController controller;
        private int textFontSize = 20;

        public SudokuForm()
        {
            InitializeComponent();
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
            SudokuMaker SM = new SudokuMaker();
            SM.Show();
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

        public void Show<T>(T Prompt)
        {
            MessageBox.Show(Prompt.ToString());
        }

        public bool GetBoolInput(string prompt)
        {
            var Result = MessageBox.Show("Are you sure you want to load a new file, you will lose your current progress", "Warning",
                                            MessageBoxButtons.YesNo);
            return Result == DialogResult.Yes;
        }

        public void DrawSudoku(Game game)
        {
            int H = 80 + BoxWidth * (game.gridHeight + 2);
            int W = 40 + BoxWidth * (game.gridWidth + 1);
            setWindowSize(W, H);
            Panel GamePanel = new GameGrid(game, this, 50).MakeSudoku();
            GamePanel.Location = new Point((Width - GamePanel.Width) / 2, MenuPanel.Height);
            Controls.Add(GamePanel);
        }

        public string GetFilePath()
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

        public (bool, bool) ChooseGame()
        {
            loadForm f = new loadForm(this, controller.game);
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

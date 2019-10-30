using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class SudokuMaker : Form
    {
        Game g;
        SudokuForm p;

        public SudokuMaker()
        {
            InitializeComponent();
            g = new Game();
        }

        private void Export_Click(object sender, EventArgs e)
        {
            if (!g.IsPuzzleValidForSaving())
            {
                var confirmResult = MessageBox.Show("Current sudoku is invalid, are you sure you want to save", "Warning",
                 MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.No)
                {
                    return;
                }
            }
                SaveFileDialog saveFileDialog1 = new SaveFileDialog
                {
                    Filter = "CSV|*.csv",
                    Title = "Save the sudoku game file"
                };
                saveFileDialog1.ShowDialog();

                // If the file name is not an empty string open it for saving.
                if (saveFileDialog1.FileName != "")
                {
                    System.IO.FileStream fs =
                        (System.IO.FileStream)saveFileDialog1.OpenFile();
                    MessageBox.Show("Sudoku Game saved to: " + fs.Name);
                    fs.Close();
                    string gameSettings = g.WriteJsonSettings(GetSudokuSettings());

                    string csvGame = g.ToCSVString(g.numbersArray);
                    g.ToCSV(fs.Name, gameSettings, csvGame, csvGame);
                }
        }

        private GameSettings GetSudokuSettings()
        {
            GameSettings s = new GameSettings
            {
                SquareWidth = (int)SquareWidth.Value,
                SquareHeight = (int)SquareHeight.Value,
                Highscore = 0,
                TargetTime = (int)TargetTime.Value,
                HintsUsed = 0,
                TimeSpent = 0,
                BaseScore = 100
            };
            return s;
        }

        private void ClearTemplate()
        {
            TemplateArea.Controls.Clear();
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            Export.Enabled = true;
            ClearTemplate();
            DrawTemplate();
        }

        private void DrawTemplate()
        {
            g.SetSettings(GetSudokuSettings(), false);
            GameGrid GG = new GameGrid(g, this, 50);
            Panel SudokuPanel = GG.MakeSudoku();
            //Center add 10 px padding to top
            SudokuPanel.Location = new Point((TemplateArea.Width - SudokuPanel.Width) / 2, 10);
            TemplateArea.Controls.Add(SudokuPanel);
        }
    }
}

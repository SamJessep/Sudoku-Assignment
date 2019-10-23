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
        int[] gameGrid;
        public SudokuMaker(Game game, SudokuForm parentForm)
        {
            InitializeComponent();
            g = new Game();
            p = parentForm;
        }

        private void Export_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog
            {
                Filter = "CSV|*.csv",
                Title = "Save the sudoku game file"
            };
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                    (System.IO.FileStream)saveFileDialog1.OpenFile();
                MessageBox.Show(fs.Name);
                fs.Close();
                string gameSettings = g.WriteJsonSettings(GetSudokuSettings());
                
                string csvGame = g.ToCSVString(gameGrid);
                g.ToCSV(fs.Name, gameSettings, csvGame, csvGame);
            }
        }

        private GameSettings GetSudokuSettings()
        {
            GameSettings s = new GameSettings();
            s.SquareWidth = (int)SquareWidth.Value;
            s.SquareHeight = (int)SquareHeight.Value;
            s.Highscore = 0;
            s.TargetTime = (int)TargetTime.Value;
            s.HintsUsed = 0;
            s.TimeSpent = 0;
            s.BaseScore = 100;
            return s;
        }

        private void ClearTemplate()
        {
            TemplateArea.Controls.Clear();
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            ClearTemplate();
            g.SetSettings(GetSudokuSettings(), false);
            GameGrid GG = new GameGrid(g, this, 50);
            TemplateArea.Controls.Add(GG.MakeSudoku());
            TemplateArea.BackColor = Color.Red;
            
        }

    }
}

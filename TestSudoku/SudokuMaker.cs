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
    public partial class SudokuMaker : Form, IEditor
    {
        Game g;
        SudokuForm p;
        EditorController controller;

        public SudokuMaker()
        {
            InitializeComponent();
            g = new Game();
        }

        public void SetController(EditorController c)
        {
            controller = c;
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            controller.MakeGameTemplate();
        }

        private void Export_Click(object sender, EventArgs e)
        {
            controller.ExportSudoku(g);
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

        public void ClearTemplate()
        {
            TemplateArea.Controls.Clear();
        }

        public void DrawTemplate()
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

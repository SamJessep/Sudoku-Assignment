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
    public partial class EditorForm : FormView, IEditor
    {
        private EditorController controller;

        public EditorForm()
        {
            InitializeComponent();
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
            controller.ExportSudoku();
        }

        public int getSquareWidth() => (int)SquareWidth.Value;

        public int getSquareHeight() => (int)SquareHeight.Value;

        public int getTargetTime() => (int)TargetTime.Value;

        public void ClearTemplate()
        {
            TemplateArea.Controls.Clear();
        }

        public void DrawTemplateComponent(Game game)
        {
            GameGrid GG = new GameGrid(game, this, 50);
            Panel SudokuPanel = GG.MakeSudoku();
            //Center add 10 px padding to top
            SudokuPanel.Location = new Point((TemplateArea.Width - SudokuPanel.Width) / 2, 10);
            TemplateArea.Controls.Add(SudokuPanel);
        }

        public string GetSaveFilePath()
        {
            string path = string.Empty;
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
                Show("Sudoku Game saved to: " + fs.Name);
                fs.Close();
                path = fs.Name;
            }
            return path;
        }

        public void ToggleExportBtn(bool enabled)
        {
            Export.Enabled = enabled;
        }
    }
}

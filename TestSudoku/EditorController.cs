using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class EditorController
    {
        SudokuMaker editor;
        public EditorController(SudokuMaker e)
        {
            editor = e;
            e.SetController(this);
        }

        public void StartEditor()
        {
            editor.Show();
        }

        public void ExportSudoku(Game g)
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

        public void MakeGameTemplate()
        {
            Export.Enabled = true;
            ClearTemplate();
            DrawTemplate();
        }
    }
}

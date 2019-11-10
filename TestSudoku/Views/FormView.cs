using System;
using System.Windows.Forms;
using System.IO;
using System.Security;

namespace Sudoku
{
    public class FormView : Form, IView
    {
        public bool GetBoolInput(string prompt, string title = "Confirmation")
        {
            var Result = MessageBox.Show(prompt, title,
                                MessageBoxButtons.YesNo);
            return Result == DialogResult.Yes;
        }

        public void Show<T>(T Prompt)
        {
            MessageBox.Show(Prompt.ToString());
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

        public void SetController(GameController gameController)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}

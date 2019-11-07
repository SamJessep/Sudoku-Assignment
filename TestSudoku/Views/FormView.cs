using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

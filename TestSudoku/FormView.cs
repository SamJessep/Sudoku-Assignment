using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class FormView : IView
    {
        public SudokuForm form;

        public void DrawSudoku(Game game)
        {
            form.MakeSudoku(game);
        }

        public void Show<T>(T Prompt)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new SudokuForm();

        }
        public void OpenForm()
        {
            Application.Run(form);
        }

        public void Stop()
        {
            Application.Exit();
        }
    }
}

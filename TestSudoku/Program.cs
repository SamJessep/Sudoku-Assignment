using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            //new GameController(new ConsoleView(), new Game()).Go();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SudokuForm form = new SudokuForm();
            new GameController(new FormView(), new Game(), form).Go();
            Application.Run(form);
        }
    }
}

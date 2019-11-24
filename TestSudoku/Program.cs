using System;
using System.Windows.Forms;

namespace Sudoku
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.SetCompatibleTextRenderingDefault(false);
            new GameController(new SudokuGameForm(), new Game()).StartApp();
        }
    }
}

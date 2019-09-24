using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public interface IView
    {
        void Start();
        void Stop();
        void Show<T>(T Prompt);

        void DrawSudoku(Game game);
        void OpenForm();
    }
}

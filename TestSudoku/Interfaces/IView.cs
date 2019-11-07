using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public interface IView
    {
        void SetController(GameController gameController);
        void Start();
        void Stop();
        void Show<T>(T Prompt);
        bool GetBoolInput(string prompt, string title);
    }
}

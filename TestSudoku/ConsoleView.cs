using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class ConsoleView : IView
    {
        public void Start()
        {
            Console.Clear();
        }

        public void Stop()
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        public void Show<T>(T prompt)
        {
            Console.WriteLine(prompt);
        }


    }
}

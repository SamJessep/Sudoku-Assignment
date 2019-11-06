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

        public void DrawSudoku(Game game)
        {
            Console.WriteLine(game.ToPrettyString());
        }

        public void SetController(GameController gameController)
        {
            throw new NotImplementedException();
        }

        public bool GetBoolInput(string prompt)
        {
            throw new NotImplementedException();
        }

        public string GetFilePath()
        {
            throw new NotImplementedException();
        }

        public (bool a, bool b) ChooseGame()
        {
            throw new NotImplementedException();
        }

        public void ResetGame()
        {
            throw new NotImplementedException();
        }

        public void UpdateTime(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void UpdateTime()
        {
            throw new NotImplementedException();
        }
    }
}

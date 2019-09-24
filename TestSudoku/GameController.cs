using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class GameController
    {
        protected IView view;
        protected Game game;

        public GameController(IView theView, Game theGame)
        {
            view = theView;
            game = theGame;
        }

        public void Go()
        {
            view.Start();
            //game.ToCSV();
            view.Show(game.FromCSV("valid3x3Incomplete", false));
            game.timeTaken = 50;
            game.targetTime = 100;
            game.SetHighScore();
            view.Show(game.GetScore());
            view.Stop();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Sudoku
{
    public partial class Game
    {

        public int highScore;
        public int targetTime;
        public int timeTaken;
        public int moves = 0;
        private int baseScore;
        public Timer timer;


        public int GetScore()
        {
            return (gridLength * 10) / (moves + timeTaken + (hintsUsed * 10));
        }



        public void StartTimer()
        {
            // Create a timer with a one second interval.
            timer = new Timer(1000);
            timeTaken = 0;
            // Hook up the Elapsed event for the timer. 
            timer.Elapsed += Count;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        public void StopTimer()
        {
            timer.Stop();
            timer.Dispose();
        }


        private void Count(Object source, ElapsedEventArgs e)
        {
            timeTaken++;
        }

        public void UpdateHighScore()
        {
            int myScore = GetScore();
            if (myScore > highScore)
            {
                highScore = myScore;
                
            }
        }

    }
}

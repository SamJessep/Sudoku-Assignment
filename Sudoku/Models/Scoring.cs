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
        public List<int[]> moves = new List<int[]>();
        private double baseScore;
        public Timer timer;


        public int GetScore()
        {
            
            int emptySquares = CountEmptySquares();
            baseScore = Math.Pow(gridLength, ((double)emptySquares / (double)3));
            double movesPenalty = moves.Count / emptySquares;
            double timeScore = 1 - ((double)timeTaken / (double)targetTime);
            double ratioOfHints = (double)hintsUsed / (double)emptySquares;
            double negativePenatlty = (double)timeScore * (double)movesPenalty;
            double score = baseScore * negativePenatlty * (1 - ratioOfHints);
            return (int)score;
        }

        public int CountEmptySquares()
        {
            return originalNumbersArray.Count(number => number == 0);
        }


        public void StartTimer()
        {
            // Create a timer with a one second interval.
            timer = new Timer(1000);
            
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

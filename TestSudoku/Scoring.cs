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
        private int baseScore;
        private static Timer aTimer;


        public int GetScore()
        {   //time left* BaseScore
            float TimeScore = baseScore * (targetTime/timeTaken);
            int zeros = CountZeros(originalNumbersArray);
            float gridScore = originalNumbersArray.Length / zeros;
            return (int)(TimeScore * gridScore) - (hintsUsed * 30);
        }

        public int CountZeros(int[] a)
        {
            int zeroCount = 0;
            for(int i = 0; i<a.Length; i++)
            {
                if(a[i] == 0)
                {
                    zeroCount++;
                }
            }
            return zeroCount;
        }

        public void StartTimer()
        {
            // Create a timer with a one second interval.
            aTimer = new Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        public void StopTimer()
        {
            aTimer.Stop();
            aTimer.Dispose();
        }


        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            timeTaken++;
        }

        public void SetHighScore()
        {
            int myScore = GetScore();
            if (myScore > highScore)
            {
                highScore = myScore;
                
            }
        }

    }
}

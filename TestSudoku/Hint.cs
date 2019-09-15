using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public partial class Game
    {
        static Random rnd = new Random();
        public int hintsUsed;

        public int[] GetHint()
        {
            int x = rnd.Next(numbersArray.Length);
            bool found = false;
            while (found)
            {
                if (numbersArray[x] == 0)
                {
                    found = true;
                }
                else
                {
                    x = rnd.Next(numbersArray.Length);
                }
            }
            int[] hints = GetValidValues(x);
            int[] result = new int[hints.Length + 1];
            result[0] = x;
            for (var i = 0; i < hints.Length; i++)
            {
                result[i + 1] = hints[i];
            }
            hintsUsed++;
            return result;
        }
    }
}

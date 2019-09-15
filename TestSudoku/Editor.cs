using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public partial class Game
    {
        private int[] CreateGridBlank( int width, int height)
        {
            int length = Convert.ToInt32(Math.Pow(width * height, 2));
            int[] blankGrid = new int[length];
            return blankGrid;
        }
    }
}

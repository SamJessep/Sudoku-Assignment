using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public partial class Game:ISet
    {
        public void SetByColumn(int value, int columnIndex, int rowIndex)
        {
            numbersArray[GetByColumn(columnIndex, rowIndex)] = value;
        }

        public void SetByRow(int value, int rowIndex, int columnIndex)
        {
            numbersArray[GetByRow(rowIndex, columnIndex)] = value;
        }

        public void SetBySquare(int value, int squareIndex, int positionIndex)
        {
            numbersArray[GetBySquare(squareIndex, positionIndex)] = value;
        }
    }
}

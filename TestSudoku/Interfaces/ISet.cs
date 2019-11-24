using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    interface ISet
    {
        void SetByColumn(int value, int columnIndex, int rowIndex);
        void SetByRow(int value, int rowIndex, int columnIndex);
        void SetBySquare(int value, int squareIndex, int positionIndex);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public partial class Game:IGet
    {
        public int GetByColumn(int columnIndex, int rowIndex)
        {
            int index = Convert.ToInt32((rowIndex * Math.Sqrt(gridWidth * gridHeight)) + columnIndex);

            return index;
        }

        public int GetByRow(int rowIndex, int columnIndex)
        {
            int index = Convert.ToInt32((rowIndex * Math.Sqrt(gridWidth * gridHeight)) + columnIndex);

            return index;
        }

        public int GetBySquare(int squareIndex, int positionIndex)
        {
            int index = 0;
            for (int i = 1; i <= squareIndex; i++)
            {
                bool isEndOfLine = i % (gridWidth / squareWidth) == 0;
                index += isEndOfLine ? (gridWidth * (squareHeight - 1)) + squareWidth : squareWidth;
            }
            for (int i = 1; i <= positionIndex; i++)
            {
                bool isEndOfLine = i % squareWidth == 0 && positionIndex != 0;
                index += isEndOfLine ? ((gridWidth - squareWidth) + 1) : 1;
            }
            return index;
        }

        public int GetRowByIndex(int index)
        {
            return index / gridWidth;
        }

        public int GetColumnByIndex(int index)
        {
            return index % gridWidth;
        }

        public int GetSquareFromIndex(int index)
        { 
            int squareCol = (GetColumnByIndex(index)) / squareWidth;
            int squareRow = (GetRowByIndex(index)) / squareHeight;
            int square = squareRow * squareWidth + squareCol;
            return square;
        }
    }
}

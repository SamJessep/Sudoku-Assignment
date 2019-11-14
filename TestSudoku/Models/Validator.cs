using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    partial class Game
    { 
        public bool isPuzzleCompleted(bool ignoreZeros = false)
        {
            for (int i = 0; i < gridHeight; i++)
            {
                if (!CellValid(i, ignoreZeros))
                {
                    return false;
                }
            }
            return true;
        }
        
        public bool IsPuzzleValidForSaving() //Pretty much the same as is puzzle valid but it is ignoring 0's. For use in the puzzle editor
        {
            return isPuzzleCompleted(true);
        }

        public int NumberOfIncorrectSquares()
        {
            int numberIncorrect = 0;
            for (int i = 0; i < numberOfSquares; i++)
            {
                if (!SquareValid(i)) // For each invalid square it checks for duplicate values, if there are the number incorrect increases by each duplicate
                {
                    int[] squareValues = new int[gridHeight];
                    for (int x = 0; x < (gridHeight); x++)
                    {
                        squareValues[x] = numbersArray[GetBySquare(i, x)];
                    }
                    int diff = squareValues.Length;
                    squareValues = new HashSet<int>(squareValues).ToArray();
                    numberIncorrect += diff - squareValues.Length;
                }
            }
            return numberIncorrect;
        }

        public int[] GetValidValues(int index)
        {
            string result = string.Empty;
            int[] possibleValues = new int[gridWidth];
            for (var i = 0; i < gridWidth; i++)
            {
                possibleValues[i] = (i + 1);
            }
            int col = GetColumnByIndex(index);
            int row = GetRowByIndex(index);
            int square = GetSquareFromIndex(index);
            for (var i = 0; i < gridHeight; i++)
            {
                int colVal = numbersArray[GetByColumn(col, i)];
                if(colVal != 0)
                {
                    if (possibleValues.Contains(colVal))
                    {
                        possibleValues[colVal - 1] = 0;
                    }
                }
                int rowVal = numbersArray[GetByRow(row, i)];
                if(rowVal != 0)
                {
                    if (possibleValues.Contains(rowVal))
                    {
                        possibleValues[rowVal - 1] = 0;
                    }
                }
                int squareVal = numbersArray[GetBySquare(square, i)];
                if(squareVal != 0)
                {
                    if (possibleValues.Contains(squareVal))
                    {
                        possibleValues[squareVal - 1] = 0;
                    }
                }
            }
            foreach (int val in possibleValues)
            {
                if (val != 0)
                {
                    result += val.ToString() + ",";
                }
            }
            if (result == "") // This is if it finds no valid values, may need to be changed to empty array not sure
            {
                return null;
            }
            int[] validValues = Array.ConvertAll(result.TrimEnd(',').Split(','), int.Parse);
            Array.Sort(validValues);
            return validValues;
        }

        public bool RowValid(int rowNumber, bool ignoreZero = false)
        {
            int[] newArray = new int[gridLength];
            for (int i = 0; i < gridWidth; i++)
            {
                int number = numbersArray[GetByRow(rowNumber, i)];
                if ((!ignoreZero && number == 0) || newArray.Contains(number))
                {
                    return false;
                }
                newArray[i] = number;

            }
            return true;
        }
        public bool ColumnValid(int columnNumber, bool ignoreZero = false)
        {
            int[] newArray = new int[gridLength];
            for (int i = 0; i < gridHeight; i++)
            {
                int number = numbersArray[GetByColumn(columnNumber, i)];
                if ((!ignoreZero && number == 0) || newArray.Contains(number))
                {
                    return false;
                }
                newArray[i] = number;

            }
            return true;
        }

        public bool SquareValid(int squareNumber, bool ignoreZero = false)
        {
            int Boxes = squareWidth * squareHeight;
            int[] newArray = new int[Boxes];
            for (int i = 0; i < Boxes; i++)
            {
                int number = numbersArray[GetBySquare(squareNumber, i)];
                if ((!ignoreZero && number == 0) || newArray.Contains(number))
                {
                    return false;
                }
                newArray[i] = number;

            }
            return true;
        }

        public bool CellValid(int index, bool ignoreZero = false)
        {
            if (SquareValid(GetSquareFromIndex(index)) && (RowValid(GetRowByIndex(index))) && (ColumnValid(GetColumnByIndex(index))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    partial class Game
    { 
        public bool IsPuzzleValid()
        {
            for (int i = 0; i < gridHeight; i++)
            {
                if (!CellValid(i))
                {
                    return false;
                }
            }
            return true;
        }
        
        public bool IsPuzzleValidForSaving() //Pretty much the same as is puzzle valid but it is ignoring 0's. For use in the puzzle editor
        {
            for (int i = 0; i < numbersArray.Length; i++)
            {
                List<int> rowNums = new List<int>();
                for (int a = 0; a < gridHeight; a++)
                {
                    if (numbersArray[GetByRow(a, GetColumnByIndex(i))] != 0)
                    {
                        rowNums.Add(numbersArray[GetByRow(a, GetColumnByIndex(i))]);
                    }
                }
                int[] rows = rowNums.ToArray();
                if (rows.Length != rows.Distinct().Count())
                {
                    return false;
                }

                List<int> colNums = new List<int>();
                for (int b = 0; b < gridWidth; b++)
                {
                    if (numbersArray[GetByColumn(b, GetRowByIndex(i))] != 0)
                    {
                        colNums.Add(numbersArray[GetByColumn(b, GetRowByIndex(i))]);
                    }
                }
                int[] cols = colNums.ToArray();
                if (cols.Length != cols.Distinct().Count())
                {
                    return false;
                }

                List<int> squareNums = new List<int>();
                for (int c = 0; c < numberOfSquares; c++)
                {
                    if (numbersArray[GetBySquare(GetSquareFromIndex(i), c)] != 0)
                    {
                        squareNums.Add(numbersArray[GetBySquare(GetSquareFromIndex(i), c)]);
                    }
                }
                int[] squares = squareNums.ToArray();
                if (squares.Length != squares.Distinct().Count())
                {
                    return false;
                }
            }

            return true;
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

        private bool RowValid(int rowNumber)
        {
            int[] newArray = new int[gridLength];
            for (int i = 1; i < gridWidth; i++)
            {
                int number = numbersArray[GetByRow(rowNumber, i)];
                if (number == 0 || newArray.Contains(number))
                {
                    return false;
                }
                newArray[i] = number;

            }
            return true;
        }
        private bool ColumnValid(int columnNumber)
        {
            int[] newArray = new int[gridLength];
            for (int i = 1; i < gridHeight; i++)
            {
                int number = numbersArray[GetByColumn(columnNumber, i)];
                if (number == 0 || newArray.Contains(number))
                {
                    return false;
                }
                newArray[i] = number;

            }
            return true;
        }

        private bool SquareValid(int squareNumber)
        {
            int Boxes = squareWidth * squareHeight;
            int[] newArray = new int[Boxes];
            for (int i = 0; i < Boxes; i++)
            {
                int number = numbersArray[GetBySquare(squareNumber, i)];
                if (number == 0 || newArray.Contains(number))
                {
                    return false;
                }
                newArray[i] = number;

            }
            return true;
        }

        private bool CellValid(int index)
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

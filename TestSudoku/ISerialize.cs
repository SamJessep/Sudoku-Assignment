using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku
{
    interface ISerialize
    {
        string FromCSV(string csv, bool loadSave);
        string ToCSV();
        void SetCell(int value, int gridIndex);
        int GetCell(int gridIndex);
        string ToPrettyString();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    interface IEditor
    {
        int getSquareWidth();
        int getSquareHeight();
        int getTargetTime();
        void ClearTemplate();
        void DrawTemplateComponent(Game g);
        string GetSaveFilePath();

    }
}

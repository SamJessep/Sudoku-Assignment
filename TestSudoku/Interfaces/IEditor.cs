using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public interface IEditor:IView
    {
        void SetController(EditorController c);
        int getSquareWidth();
        int getSquareHeight();
        int getTargetTime();
        void ClearTemplate();
        void DrawTemplateComponent(Game g);
        string GetSaveFilePath();
        string GetFilePath();
        void UpdateGameUI(GameSettings gameSettings);

    }
}

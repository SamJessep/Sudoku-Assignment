using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public interface IEditor
    {
        void SetController(EditorController gameController);
        void Start();
        void Stop();
        void Show<T>(T Prompt);
        bool GetBoolInput(string prompt, string title);
        int getSquareWidth();
        int getSquareHeight();
        int getTargetTime();
        void ClearTemplate();
        void DrawTemplateComponent(Game g);
        string GetSaveFilePath();
        string GetFilePath();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class EditorController
    {
        EditorForm editor;
        Game game;

        public EditorController(EditorForm e)
        {
            editor = e;
            e.SetController(this);
        }

        public void StartEditor()
        {
            editor.Show();
        }

        public void ExportSudoku()
        {
            GameSettings settings = GetGameSettings();
            if (!game.IsPuzzleValidForSaving())
            {
                var ChoseNo = !editor.GetBoolInput("Current sudoku is invalid, are you sure you want to save", "Warning");
                if (ChoseNo)
                {
                    return;
                }
            }
            string filePath = editor.GetSaveFilePath();
            string gameSettings = game.WriteJsonSettings(GetGameSettings());
            string csvGame = game.ToCSVString(game.numbersArray);
            SaveFile(filePath, gameSettings, csvGame);
        }

        public void MakeGameTemplate()
        {
            game = new Game();
            editor.ToggleExportBtn(true);
            editor.ClearTemplate();
            game.SetSettings(GetGameSettings(), false);
            editor.DrawTemplateComponent(game);
        }

        private GameSettings GetGameSettings()
        {
            GameSettings s = new GameSettings
            {
                SquareWidth = editor.getSquareWidth(),
                SquareHeight = editor.getSquareHeight(),
                Highscore = 0,
                TargetTime = editor.getTargetTime(),
                HintsUsed = 0,
                TimeSpent = 0,
                BaseScore = 100
            };
            return s;
        }

        public void SaveFile(string path, string settings, string gameCsv)
        {
            if(path != "")
            {
                game.ToCSV(path, settings, gameCsv, gameCsv);
            }
        }

    }
}

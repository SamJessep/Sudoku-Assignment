using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class EditorController
    {
        IEditor editor;
        Game game;
        public int SelectedControl = 0;

        public EditorController(IEditor editorView)
        {
            editor = editorView;
            editor.SetController(this);
        }

        public void StartEditor()
        {
            editor.Start();
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

        public void MakeGameTemplate(Game gameTemplate = null)
        {
            GameSettings GS;
            if (gameTemplate != null)
            {
                game = gameTemplate;
                GS = game.GetSettings();
                editor.UpdateGameUI(GS);
                game.SetSettings(GS, false);
            }
            else
            {
                game = new Game();
                GS = GetGameSettings();
                game.SetSettings(GS, false);
                game.EmptyGrid();
            }
            
            AddTemplate();
        }
        public void AddTemplate()
        {
            editor.ClearTemplate();
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

        public void LoadGameFile()
        {
            Game loadedGameTemplate = new Game();
            string path = editor.GetFilePath();
            loadedGameTemplate.FromCSV(path, false);
            MakeGameTemplate(loadedGameTemplate);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class GameController
    {
        protected SudokuGameForm view;
        public Game game;

        public GameController(SudokuGameForm theView, Game theGame)
        {
            view = theView;
            game = theGame;
        }

        public void StartApp()
        {
            view.SetController(this);
            view.Start();
        }

        public void StartEditor()
        {
            new EditorController(new EditorForm()).StartEditor();
        }

        public void SelectGame()
        {
            string path = view.GetFilePath();
            //Load File for game preview
            if (path != null)
            {
                if (game.originalNumbersArray != null)
                {
                    bool hasSaved = Enumerable.SequenceEqual(game.numbersArray, game.lastSaveNumbersArray);
                    if (!hasSaved)
                    {
                        var UserWantsToAbort = !view.GetBoolInput("Are you sure you want to load a new file, you will lose your current progress");
                        if (UserWantsToAbort)
                        {
                            return;
                        }
                    }
                }
                view.ClearGameScreen();
                LoadGame(path);
            }
        }

        public void LoadGame(string gameFilePath)
        {
            game.FromCSV(gameFilePath, true);
            (bool,bool) r = view.ChooseGame();
            bool ChoseAGame = r.Item1;
            bool isLoadingSave = r.Item2;
            if (ChoseAGame)
            {
                game.FromCSV(gameFilePath, isLoadingSave);
                view.DrawSudoku(game);
                //StartGameTimer();
            }
            else
            {
                view.Show("Game Load aborted");
            }
                view.ToggleGameMenu(ChoseAGame);
        }

        private void StartGameTimer()
        {
            game.StartTimer();
            game.timer.Elapsed += UpdateViewTimer;
        }

        private void UpdateViewTimer(object sender, EventArgs e)
        {
            view.UpdateTime();
        }

        public void SaveGame()
        {
            game.SaveGame();
            view.Show("Game Saved");
        }

        public void ResetGame()
        {
            game.numbersArray = game.originalNumbersArray;
            view.ResetGame();
        }


        public string GetTimeAsString()
        {
            int totalSeconds = game.timeTaken;
            int sec = totalSeconds % 60;
            int min = (int)Math.Floor(d: (decimal)totalSeconds / 60);
            string secAsString = sec.ToString().Length == 1 ? "0" + sec : sec.ToString();
            string minAsString = min.ToString().Length == 1 ? "0" + min : min.ToString();
            string timeString = minAsString + ":" + secAsString;
            return timeString;
        }
    }
}

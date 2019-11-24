using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class GameController
    {
        protected IGameView view;
        public Game game;
        public int SelectedControl = 0;

        public GameController(IGameView theView, Game theGame)
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
                        var UserWantsToAbort = !view.GetBoolInput("Are you sure you want to load a new file, you will lose your current progress", "Warning");
                        if (UserWantsToAbort)
                        {
                            return;
                        }
                    }
                    StopTimer();
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
                StartTimer();
            }
            else
            {
                view.Show("Game Load aborted");
            }
        }

        public void StartTimer()
        {
            game.StartTimer();
            game.timer.Elapsed += UpdateViewTimer;
        }

        private void UpdateViewTimer(object sender, EventArgs e)
        {
            view.UpdateTime();
        }

        public void StopTimer()
        {
            game.StopTimer();
        }

        public void GameWon()
        {
            SetScore();
            view.Show("Game Completed in: " + game.timeTaken + " seconds, Your score was:" + game.GetScore());
            view.Show("Moves:" + game.moves.Count + "TimeTaken:" + game.timeTaken);
            StopTimer();
        }
        
        private void SetScore()
        {
            game.UpdateHighScore();
            game.SaveGame();
        }
        public void SaveGame()
        {
            if (!game.isPuzzleCompleted())
            {
                game.SaveGame();
                view.Show("Game Saved");
            }
            else
            {
                view.Show("You can't save a finished game");
            }

        }

        public void ResetGame()
        {
            string gamePath = game.currentGameFile;
            game = new Game();
            game.FromCSV(gamePath, false);
            game.timeTaken = 0;
            view.ResetGame();
        }

        /*public void Undo()
        {
            int[] LastMove = game.moves[game.moves.Count - 2];
            game.SetCell(LastMove[1], LastMove[0]);
            view.UpdateCellOnView(LastMove[1], LastMove[0]);
        }
        public void Redo()
        {

        }*/


        public string GetTimeAsString()
        {
            int totalSeconds = game.timeTaken;
            int sec = totalSeconds % 60;
            int min = (int)Math.Floor(d: (decimal)totalSeconds / 60);
            string secAsString = sec.ToString().Length == 1 ? "0" + sec : sec.ToString();
            string minAsString = min.ToString().Length == 1 ? "0" + min : min.ToString();
            string timeString = minAsString + ":" + secAsString;
            return "Time: "+timeString;
        }
    }
}

namespace Sudoku
{
    public interface IGameView : IView
    {
        void DrawSudoku(Game game);
        string GetFilePath();
        (bool a, bool b) ChooseGame();
        void ResetGame();
        void UpdateTime();
        void ClearGameScreen();
        void UpdateCellOnView(int value, int index);

    }
}

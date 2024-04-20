namespace MinesweeperService
{
    public interface IMinesweeper
    {
        int Cols { get; }
        int Rows { get; }
        int LifesLeft { get; }

        bool IsGameOver { get; }

        bool IsGameWon { get; }

        string GetCellValue(int row, int col);

        void InitGame(int rows, int cols, int mineCount, int totalLifes);

        bool SetPosition(int row, int col);
    }
}

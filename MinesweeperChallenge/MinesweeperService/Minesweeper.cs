using System.Data.Common;
using System.Linq;

namespace MinesweeperService
{
    public class Minesweeper : IMinesweeper
    {
        private int _lifesConsumed;
        private int _totalLifes;
        private int _mineCount;
        private bool[,] _mines;
        private bool[,] _revealed;
        private int _revealedCount;
        private int _rows;
        private int _cols;

        public int Cols => _cols;
        public int Rows => _rows;
        public int LifesLeft => _totalLifes - _lifesConsumed;
        public bool IsGameOver => _revealedCount == _rows * _cols - _mineCount || _lifesConsumed == _totalLifes;
        public bool IsGameWon => _revealedCount == _rows * _cols - _mineCount;

        public void InitGame(int rows, int cols, int mineCount, int totalLifes)
        {
            _mineCount = mineCount;
            _mines = new bool[rows, cols];
            
            _totalLifes = totalLifes;
            _lifesConsumed = 0;

            _revealed = new bool[rows, cols];

            _rows = rows;
            _cols = cols;

            _revealedCount = 0;

            var random = new Random();
            int minesPlaced = 0;

            while (minesPlaced < _mineCount)
            {
                int row = random.Next(rows);
                int column = random.Next(cols);

                if (!_mines[row, column])
                {
                    _mines[row, column] = true;
                    minesPlaced++;
                }
            }
        }

        string GetNeighborMineCount(int row, int col)
        {
            int count = 0;
            for (int i = Math.Max(0, row - 1); i <= Math.Min(_rows - 1, row + 1); i++)
            {
                for (int j = Math.Max(0, col - 1); j <= Math.Min(_cols - 1, col + 1); j++)
                {
                    if (_mines[i, j])
                    {
                        count++;
                    }
                }
            }
            return count == 0 ? " " : count.ToString();
        }

        public string? GetCellValue(int row, int col)
        {
            return IsValidCellPosition(row, col) ? _revealed[row, col] ? _mines[row, col] ? "*" : GetNeighborMineCount(row, col) : null : null;
        }

        bool IsValidCellPosition(int row, int col)
        {
            return row >= 0 && row < _rows && col >= 0 && col < _cols;
        }

        public bool SetPosition(int row, int col)
        {
            var result = IsValidCellPosition(row, col) && !_revealed[row, col] ;

            if (result)
            {
                SetCell(row, col);
            }

            return result;
        }

        void SetCell(int row, int col)
        {
            _revealed[row, col] = true;
            if (!_mines[row, col])
            {
                _revealedCount++;
                if (GetNeighborMineCount(row, col) == " ")
                {
                    for (int i = Math.Max(0, row - 1); i <= Math.Min(_rows - 1, row + 1); i++)
                    {
                        for (int j = Math.Max(0, col - 1); j <= Math.Min(_cols - 1, col + 1); j++)
                        {
                            if (!_revealed[i, j])
                            {
                                SetCell(i, j);
                            }
                        }
                    }
                }
            }
            else
            {
                _lifesConsumed++;
            }
        }

    }
}

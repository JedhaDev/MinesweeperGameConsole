using MinesweeperService;
using System.Data.Common;

namespace MinesweeperGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMinesweeper game;
            game = new Minesweeper();

            var totalRows = 15;
            var totalCols = 10;
            var totalMines = totalCols * totalRows / 3;
            var totalLifes = 5;

            game.InitGame(totalRows, totalCols, totalMines, totalLifes);

            PrintBoard(game);

            do
            {

                Console.Write("Enter row:");
                var row = Console.ReadLine();
                if (!int.TryParse(row, out int rowValue))
                {
                    Console.WriteLine("Please only enter a number");
                    continue;
                }

                Console.Write("Enter column:");
                var col = Console.ReadLine();

                if (!int.TryParse(col, out int colValue))
                {
                    Console.WriteLine("Please only enter a number");
                    continue;
                }

                if (!game.SetPosition(rowValue, colValue))
                {
                    Console.WriteLine("Invalid cell");
                    continue;
                }

                PrintBoard(game);


            } while (!game.IsGameOver);

            Console.WriteLine(game.IsGameWon ? "You win! :-)" : "Game over! :-(");
        }

        public static void PrintBoard(IMinesweeper game)
        {
            Console.Clear();

            var spaceSize = " ";
            var result = "   ";

            for (int i = 0; i < game.Cols; i++)
            {
                result += string.Format("{0,2:0}", i) + spaceSize;
            }
            result += "\n\r";

            for (int row = 0; row < game.Rows; row++)
            {
                result += string.Format("{0,2:0}", row) + spaceSize;
                for (int col = 0; col < game.Cols; col++)
                {
                    result += spaceSize + (game.GetCellValue(row, col) ?? "■") + spaceSize;
                }
                result += "\n\r";
            }

            Console.WriteLine(result);
            Console.WriteLine($"Total lifes left: {game.LifesLeft}");

        }

    }
}

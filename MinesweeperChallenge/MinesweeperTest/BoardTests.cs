using MinesweeperService;

namespace MinesweeperTest
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void GenerateMines_Should_GenerateCorrectData()
        {
            var board = new Minesweeper();

            var totalRows = 15;
            var totalCols = 10;
            var totalMines = totalCols * totalRows / 3;
            var totalLifes = 5;

            board.InitGame(totalRows, totalCols, totalMines, totalLifes);


            Assert.IsTrue(board.Cols == totalCols);
            Assert.IsTrue(board.Rows == totalRows);
            Assert.IsTrue(board.LifesLeft == totalLifes);
        }

        [TestMethod]
        public void GenerateMines_Should_CalculateCorrectlyInput ()
        {
            var board = new Minesweeper();

            var totalRows = 15;
            var totalCols = 10;
            var totalMines = totalCols * totalRows / 3;
            var totalLifes = 5;

            board.InitGame(totalRows, totalCols, totalMines, totalLifes);


            Assert.IsTrue(board.SetPosition(0, 0));
            Assert.IsTrue(board.SetPosition(totalRows - 1, totalCols - 1));
            Assert.IsTrue(board.SetPosition(0, totalCols - 1));
            Assert.IsTrue(board.SetPosition(totalRows - 1, 0));
            
            Assert.IsFalse(board.SetPosition(-1, 0));
            Assert.IsFalse(board.SetPosition(0, -1));

            Assert.IsFalse(board.SetPosition(totalRows, totalCols - 1));
            Assert.IsFalse(board.SetPosition(totalRows - 1, totalCols));
            Assert.IsFalse(board.SetPosition(totalRows, totalCols));
        }

    }

}
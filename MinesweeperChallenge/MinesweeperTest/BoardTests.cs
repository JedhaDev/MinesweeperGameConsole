using MinesweeperService;

namespace MinesweeperTest
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid init parameters are not allowded")]
        public void Check_Initialization_Wrong_Rows()
        {
            var board = new Minesweeper();

            board.InitGame(0, 10, 5, 5);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid init parameters are not allowded")]
        public void Check_Initialization_Wrong_Cols()
        {
            var board = new Minesweeper();

            board.InitGame(10, 0, 5, 5);

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid init parameters are not allowded")]
        public void Check_Initialization_Wrong_Mines()
        {
            var board = new Minesweeper();

            board.InitGame(10, 10, 10 * 10, 5);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Invalid init parameters are not allowded")]
        public void Check_Initialization_Wrong_Lifes()
        {
            var board = new Minesweeper();

            board.InitGame(10, 10, 10, 0);

        }

        [TestMethod]
        public void Should_Generate_Correct_Data()
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
        public void Should_Calculate_Correctly_Input ()
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


        [TestMethod]
        public void Should_Correctly_Get_Cell_Value()
        {
            var board = new Minesweeper();

            var totalRows = 15;
            var totalCols = 10;
            var totalMines = totalCols * totalRows / 3;
            var totalLifes = 5;

            board.InitGame(totalRows, totalCols, totalMines, totalLifes);


            Assert.IsNull(board.GetCellValue(0, 0));
            Assert.IsNull(board.GetCellValue(totalRows - 1, totalCols - 1));
            Assert.IsNull(board.GetCellValue(0, totalCols - 1));
            Assert.IsNull(board.GetCellValue(totalRows - 1, 0));

            Assert.IsNull(board.GetCellValue(-1, 0));
            Assert.IsNull(board.GetCellValue(0, -1));

            Assert.IsNull(board.GetCellValue(totalRows, totalCols - 1));
            Assert.IsNull(board.GetCellValue(totalRows - 1, totalCols));
            Assert.IsNull(board.GetCellValue(totalRows, totalCols));

            board.SetPosition(0, 0);
            Assert.IsNotNull(board.GetCellValue(0, 0));

            board.SetPosition(totalRows - 1, 0);
            Assert.IsNotNull(board.GetCellValue(totalRows - 1, 0));

            board.SetPosition(0, totalCols - 1);
            Assert.IsNotNull(board.GetCellValue(0, totalCols - 1));

            board.SetPosition(totalRows - 1, totalCols - 1);
            Assert.IsNotNull(board.GetCellValue(totalRows - 1, totalCols - 1));
        }
    }

}
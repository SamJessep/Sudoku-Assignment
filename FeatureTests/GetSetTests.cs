using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace FeatureTests
{
    [TestClass]
    public class GetSetTests
    {
        [TestMethod]
        public void SetByColumnTest()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3",false);
            theGame.SetByColumn(10, 2, 1);
            //Act 
            int actualValue = theGame.numbersArray[11];
            int expectedValue = 10;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Sets value by column correctly");
        }

        [TestMethod]
        public void SetByRowTest()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3",false);
            theGame.SetByRow(10, 6, 7);
            //Act 
            int actualValue = theGame.numbersArray[61];
            int expectedValue = 10;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Sets Row 6 Col 7 to 10 correctly");
        }

        [TestMethod]
        public void SetBySquareTest()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3",false);
            theGame.SetBySquare(10,8,1);
            //Act 
            int actualValue = theGame.numbersArray[61];
            int expectedValue = 10;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Sets Square 8 offset 1 to 10 correctly");
        }

        [TestMethod]
        public void GetByColumnTest()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3", false);
            theGame.numbersArray[0] = 99;
            
            //Act 
            int actualValue = theGame.numbersArray[theGame.GetByColumn(0, 0)];
            int expectedValue = 99;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Correctly gets first cell (row 0 cell 0)");
        }
        [TestMethod]
        public void GetByRow()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3", false);
            theGame.numbersArray[80] = 99;
            //Act 
            int actualValue = theGame.numbersArray[theGame.GetByRow(8, 8)];
            int expectedValue = 99;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Correctly gets last cell(row 8 col 8)");
        }
        [TestMethod]
        public void GetBySquare()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3", false);
            theGame.numbersArray[37] = 99;
            //Act 
            int actualValue = theGame.numbersArray[theGame.GetBySquare(3,4)];
            int expectedValue = 99;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Gets cell correctly (square 3 offset 4)");
        }
        [TestMethod]
        public void GetRowByIndex()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3", false);
            //Act 
            int actualValue = theGame.GetRowByIndex(9);
            int expectedValue = 1;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Correctly gets row 1 from index 9");
        }
        [TestMethod]
        public void GetColumnByIndex()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3", false);
            //Act 
            int actualValue = theGame.GetColumnByIndex(9);
            int expectedValue = 0;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Corretly gets col 0 from index 9");
        }
        [TestMethod]
        public void GetSquareFromIndex()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3", false);
            //Act 
            int actualValue = theGame.GetSquareFromIndex(27);
            int expectedValue = 3;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Correctly gets square 3 from index 9");
        }
    }
}

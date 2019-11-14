using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;
using System.IO;

namespace FeatureTests
{
    [TestClass]
    public class ValidatorTests
    {
        [TestMethod]
        public void IsPuzzleValid()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\valid3X3.csv")),false);
            //Act 
            bool actualValue = theGame.isPuzzleCompleted();
            bool expectedValue = true;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "detects puzzle is valid");
        }

        [TestMethod]
        public void IsPuzzleValidShouldFail()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\invalid3X3.csv")), false);
            //Act 
            bool actualValue = theGame.isPuzzleCompleted();
            bool expectedValue = false;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "detects puzzle is invalid");
        }

        [TestMethod]
        public void IsPuzzleValidForSaving()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\valid3X3.csv")),false);
            //Act 
            bool actualValue = theGame.IsPuzzleValidForSaving();
            bool expectedValue = true;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "detects puzzle is valid for saving");
        }

        [TestMethod]
        public void IsPuzzleValidForSavingShouldFail()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\invalid3X3.csv")), false);
            //Act 
            bool actualValue = theGame.IsPuzzleValidForSaving();
            bool expectedValue = false;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "detects puzzle is invalid for saving");
        }
        [TestMethod]
        public void NumberOfIncorrectSquares()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\valid3X3.csv")),false);
            //Act 
            int actualValue = theGame.NumberOfIncorrectSquares();
            int expectedValue = 0;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "should find no incorret squares");
        }

        [TestMethod]
        public void NumberOfIncorrectSquaresShouldFail()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\invalid3X3.csv")), false);
            //Act 
            int actualValue = theGame.NumberOfIncorrectSquares();
            int expectedValue = 2;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "should find 1 incorrect square");
        }

        [TestMethod]
        public void GetValidValues()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\invalid3X3Incomplete.csv")),false);
            //Act 
            int[] actualValue = theGame.GetValidValues(0);
            int[] expectedValue = { 7 };
            //Assert
            CollectionAssert.AreEqual(expectedValue, actualValue, "should find valid value for square index 0");
        }

        [TestMethod]
        public void GetValidValuesShouldFail()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\invalid3X3Incomplete.csv")), false);
            //Act 
            int[] actualValue = theGame.GetValidValues(0);
            int[] expectedValue = { 7 };
            //Assert
            CollectionAssert.AreEqual(expectedValue, actualValue, "should find valid value for square index 0");
        }

        [TestMethod]
        public void RowValid()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\valid3X3.csv")),false);
            //Act 
            bool actualValue = theGame.RowValid(2);
            bool expectedValue = true;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "finds row is valid");
        }

        [TestMethod]
        public void RowValidShouldFail()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\invalid3X3.csv")), false);
            //Act 
            bool actualValue = theGame.RowValid(2);
            bool expectedValue = false;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "detects row is invalid");
        }

        [TestMethod]
        public void ColumnValid()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\valid3X3.csv")),false);
            //Act 
            bool actualValue = theGame.ColumnValid(5);
            bool expectedValue = true;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "finds column is valid");
        }

        [TestMethod]
        public void ColumnValidShouldFail()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\invalid3X3.csv")), false);
            //Act 
            bool actualValue = theGame.ColumnValid(5);
            bool expectedValue = false;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "detects column is invalid");
        }

        [TestMethod]
        public void SquareValid()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\valid3X3.csv")),false);
            //Act 
            bool actualValue = theGame.SquareValid(4);
            bool expectedValue = true;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "finds square is valid");
        }

        [TestMethod]
        public void SquareValidShouldFail()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\invalid3X3.csv")), false);
            //Act 
            bool actualValue = theGame.SquareValid(4);
            bool expectedValue = false;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "detects square is invalid");
        }

        [TestMethod]
        public void CellValid()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\valid3X3.csv")),false);
            //Act 
            bool actualValue = theGame.CellValid(22);
            bool expectedValue = true;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "finds cell is valid");
        }

        [TestMethod]
        public void CellValidShouldFail()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\invalid3X3.csv")), false);
            //Act 
            bool actualValue = theGame.CellValid(22);
            bool expectedValue = false;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "detects cell is invalid");
        }
    }
}

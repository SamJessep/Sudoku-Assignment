using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace FeatureTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void SetMaxValue()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3",false);
            theGame.SetMaxValue(100);
            //Act 
            int actualValue = theGame.GetMaxValue();
            int expectedValue = 100;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Correctly sets and gets the max value");
        }

        [TestMethod]
        public void ToArray()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3",false);
            //Act 
            int actualValue = theGame.ToArray().Length;
            int expectedValue = 81;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Correctly returns array with all the values");
        }
        [TestMethod]
        public void SetByColumnTest()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3",false);
            int[] numbers = { 1, 2, 99, 5 };
            theGame.Set(numbers);
            //Act 
            
            int actualValue = theGame.numbersArray[2];
            int expectedValue = 99;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Corectly sets the numbers");
        }
        [TestMethod]
        public void SetSquareWidth()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3",false);
            theGame.SetSquareWidth(21);
            //Act 
            int actualValue = theGame.squareWidth;
            int expectedValue = 21;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Correctly sets squareWidth to 21");
        }
        [TestMethod]
        public void SetSquareHeight()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3",false);
            theGame.SetSquareHeight(21);
            //Act 
            int actualValue = theGame.squareHeight;
            int expectedValue = 21;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Correctly sets squareHeight to 21");
        }
        [TestMethod]
        public void Restart()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3",false);
            int expectedValue = theGame.numbersArray[5];
            theGame.numbersArray[5] = 999;
            theGame.Restart();
            //Act 
            int actualValue = theGame.numbersArray[5];
            
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Correctly resests the game");
        }
    }
}

﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace FeatureTests
{
    [TestClass]
    public class HintsTests
    {
        [TestMethod]
        public void GetHintShouldGetAValue()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3x3Incomplete", false);
            //Act 
            int actualLength = theGame.GetHint().Length;
            int expectedLength = 2;

            int expectedValue = 7;
            int actualValue = theGame.GetHint()[1];
            // 
            //Assert
            Assert.AreEqual(expectedLength, actualLength, "should return 1 valid value and the index of the square, so 2 items in the array");
            Assert.AreEqual(expectedValue, actualValue, "should return 7 as the value");
        }
        [TestMethod]
        public void GetHintShouldGetNone()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3x3", false);
            //Act 
            int actualLength = theGame.GetHint().Length;
            int expectedLength = 0;
            // 
            //Assert
            Assert.AreEqual(expectedLength, actualLength, "should return an empty array as the sudoku is full");
        }
    }
}

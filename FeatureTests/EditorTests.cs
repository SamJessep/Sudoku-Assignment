using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace FeatureTests
{
    [TestClass]
    public class EditorTests
    {
        [TestMethod]
        public void CreateGridBlank3X3()
        {
            //Arrange 
            Game theGame = new Game();
            int[] grid = theGame.CreateGridBlank(3, 3);
            //Act 
            int actualValue = grid.Length;
            int expectedValue = 3*3*3*3;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Should create a grid with enough empty slots");
        }
        [TestMethod]
        public void CreateGridBlank2X3()
        {
            //Arrange 
            Game theGame = new Game();
            int[] grid = theGame.CreateGridBlank(2, 3);
            //Act 
            int actualValue = grid.Length;
            int expectedValue = 3*2*3*2;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Should create a grid with enough empty slots");
        }
    }
}

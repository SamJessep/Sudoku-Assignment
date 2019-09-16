using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace FeatureTests
{
    [TestClass]
    class ScoreTests
    {
        [TestMethod]
        public void GetScore()
        {
            //check score is higher if if sudoku is completed quicker
            Game theGame = new Game();
            //Setup
            theGame.FromCSV("valid3X3", false);
            theGame.StartTimer();
            Thread.Sleep(2000);
            theGame.StopTimer();

            int actualTime = theGame.timeTaken;
            int expectedTime = 2;

            Assert.AreEqual(expectedTime, actualTime, "time taken should be 2 seconds");
        }
    }
}

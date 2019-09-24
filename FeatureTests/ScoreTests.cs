using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace FeatureTests
{
    [TestClass]
    public class ScoreTests
    {
        [TestMethod]
        public void TestTimer()
        {
            //check score is higher if if sudoku is completed quicker
            Game theGame = new Game();
            //Setup
            theGame.FromCSV("valid3X3", false);
            theGame.StartTimer();
            Thread.Sleep(3000);
            theGame.StopTimer();

            int actualTime = theGame.timeTaken;
            int expectedTime = 2;

            Assert.AreEqual(expectedTime, actualTime, "time taken should be 2 seconds");
        }

        [TestMethod]
        public void SettingHighScore()
        {
            Game theGame = new Game();
            theGame.FromCSV("valid3x3Incomplete", false);
            theGame.timeTaken = 50;
            theGame.targetTime = 100;
            theGame.SetHighScore();

            int expectedVal = 16200;
            int actualVal = theGame.highScore;

            Assert.AreEqual(expectedVal, actualVal, "old score should Be replaced");
        }

        [TestMethod]
        public void SettingHighScore2()
        {
            Game theGame = new Game();
            theGame.FromCSV("valid3x3Incomplete", false);
            theGame.highScore = 10000;
            theGame.timeTaken = 1000;
            theGame.targetTime = 100;
            theGame.SetHighScore();

            int expectedVal = 10000;
            int actualVal = theGame.highScore;

            Assert.AreEqual(expectedVal, actualVal, "old highscore should stay");
        }
    }
}

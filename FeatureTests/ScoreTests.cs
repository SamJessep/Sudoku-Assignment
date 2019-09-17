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
            theGame.FromCSV("valid3X3", false);
            theGame.highScore = 100;
            theGame.SetHighScore();

            int expectedVal = 100;
            int actualVal = theGame.highScore;

            Assert.AreEqual(expectedVal, actualVal, "old score should stay as the high score");
        }

        [TestMethod]
        public void SettingHighScore2()
        {
            Game theGame = new Game();
            theGame.FromCSV("valid3X3", false);
            theGame.highScore = 1;
            theGame.SetHighScore();

            int expectedVal = 2;
            int actualVal = theGame.highScore;

            Assert.AreEqual(expectedVal, actualVal, "highscore score should be replaced");
        }
    }
}

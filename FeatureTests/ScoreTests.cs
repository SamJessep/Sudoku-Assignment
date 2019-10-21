using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;
using System.IO;

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
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\valid3X3.csv")), false);
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
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\invalid3X3Incomplete.csv")), false);
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
            theGame.FromCSV(Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\GameSaves\invalid3X3Incomplete.csv")), false);
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

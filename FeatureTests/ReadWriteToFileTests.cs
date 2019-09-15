using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace FeatureTests
{
    [TestClass]
    public class ReadWriteToFileTests
    {
        /* Valid 3x3 
        7,3,5,6,1,4,8,9,2
        8,4,2,9,7,3,5,6,1
        9,6,1,2,8,5,3,7,4
        2,8,6,3,4,9,1,5,7
        4,1,3,8,5,7,9,2,6
        5,7,9,1,2,6,4,3,8
        1,5,7,4,9,2,6,8,3
        6,9,4,7,3,8,2,1,5
        3,2,8,5,6,1,7,4,9
        */
        [TestMethod]
        public void FromCSV()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3",false);
            theGame.SetMaxValue(100);
            //Act 
            int actualValue = theGame.numbersArray[5];
            int expectedValue = 4;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Correctly loads csv");
        }

        [TestMethod]
        public void ReadJsonSettings()
        {
            //Arrange 
            Game theGame = new Game();
            string json = "{BaseScore:100,Highscore:2,HintsUsed:2,SquareHeight:2,SquareWidth:3,TargetTime:200,TimeSpent:500000}";
            GameSettings jsonObj = theGame.ReadJsonSettings(json);
            //Act 
            Type actualType = jsonObj.GetType();
            Type expectedType = typeof(GameSettings);

            int expectedHighScore = 2;
            int actualHighScore = jsonObj.Highscore;
            //Assert
            Assert.AreEqual(expectedType, actualType, "returned json is correct type");
            Assert.AreEqual(expectedHighScore, actualHighScore, "Gets the correct highscore");
        }
        /*[TestMethod]
        public void WriteJsonSettings()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3",false);
            GameSettings jsonObj = new GameSettings();
            theGame.squareWidth = 999;
            theGame.WriteJsonSettings(jsonObj);
            //Act 
            int actualValue = theGame.numbersArray[5];
            int expectedValue = 4;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Correctly loads csv");
        }*/

       
    }
}

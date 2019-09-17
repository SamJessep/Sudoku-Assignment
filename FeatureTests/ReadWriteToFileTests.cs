using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Json;

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
            //"{BaseScore:100,Highscore:2,HintsUsed:2,SquareHeight:2,SquareWidth:3,TargetTime:200,TimeSpent:500000}"
            string csvText = System.IO.File.ReadAllText(@"..\..\..\Export\valid3X3.csv");
            Dictionary<string, string> csvParts = theGame.SplitInput(csvText);
            GameSettings jsonObj = theGame.ReadJsonSettings(csvParts["Settings"]);

            //Act

            int expectedHighScore = 2;
            int actualHighScore = jsonObj.Highscore;
            //Assert
            Assert.AreEqual(actualHighScore, expectedHighScore, "Gets the correct highscore");
        }

        [TestMethod]
        public void GetCell()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3", false);
            theGame.numbersArray[0] = 100;

            //Act 
            int actualValue = theGame.GetCell(0);
            int expectedValue = 100;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Gets the correct value of cell 0");
        }
        [TestMethod]
        public void SetCell()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3", false);
            theGame.SetCell(100, 0);
            //Act 
            int actualValue = theGame.numbersArray[0];
            int expectedValue = 100;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Correctly sets cell 0 to 100");
        }
        [TestMethod]
        public void MakeSquare()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3", false);
            //Act 
            int actualValue = theGame.MakeSquare(1).Length;
            int expectedValue = 4;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Correctly creates a string with the correct spacing");
        }
        [TestMethod]
        public void MakeLine()
        {
            //Arrange 
            Game theGame = new Game();
            theGame.FromCSV("valid3X3", false);
            //Act 
            int actualValue = theGame.MakeLine(theGame.squareWidth).Length;
            int expectedValue = 40;
            //Assert
            Assert.AreEqual(expectedValue, actualValue, "Correctly creates a string with the correct amount of - characters");
        }
    }
}

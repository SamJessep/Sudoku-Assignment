using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Sudoku
{
    public partial class Game : ISerialize
    {
        private string currentGameFile;

        public string FromCSV(string csv, bool loadSave)
        {
            csv = GetRelativePath(csv, AppDomain.CurrentDomain.BaseDirectory);
            currentGameFile = csv;
            string csvText = File.ReadAllText(@Uri.UnescapeDataString(csv));
            Dictionary<string, string> csvParts = SplitInput(csvText);
            string OriginalSudoku = csvParts["OriginalSudoku"];
            string EditedSudoku = csvParts.ContainsKey("EditedSudoku") ? csvParts["EditedSudoku"]: csvParts["OriginalSudoku"];
            string Settings = csvParts["Settings"];
            GameSettings csvSettings = ReadJsonSettings(Settings);
            SetSettings(csvSettings, loadSave);
            LoadNumbersArray(OriginalSudoku, loadSave?EditedSudoku:OriginalSudoku);
            return "loaded: " + csv + ".csv "+ (loadSave?"saved ":"orginal ") + "Sudoku";
        }

        public void LoadNumbersArray(string sudoku, string editedSudoku)
        {
            int[] numbers = ToNumberList(sudoku);
            int[] EditedNumbers = ToNumberList(editedSudoku);
            originalNumbersArray = numbers;
            lastSaveNumbersArray = EditedNumbers;
            for (int i = 0; i < numbers.Length; i++)
            {
                SetCell(EditedNumbers[i], i);
            }
        }

        public GameSettings ReadJsonSettings(string settings)
        {
            var deserializedUser = new GameSettings();
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(settings));
            var ser = new DataContractJsonSerializer(deserializedUser.GetType());
            deserializedUser = ser.ReadObject(ms) as GameSettings;
            ms.Close();
            return deserializedUser;
        }
        public string WriteJsonSettings(GameSettings settings)
        {
            var stream1 = new MemoryStream();
            var ser = new DataContractJsonSerializer(typeof(GameSettings));
            ser.WriteObject(stream1, settings);
            stream1.Position = 0;
            var sr = new StreamReader(stream1);
            return sr.ReadToEnd();
        }

        public void SetSettings(GameSettings s, bool loadSave)
        {
            SetSquareWidth(s.SquareWidth);
            SetSquareHeight(s.SquareHeight);
            highScore = s.Highscore;
            targetTime = s.TargetTime;
            hintsUsed = loadSave ? s.HintsUsed : 0;
            timeTaken = loadSave ? s.TimeSpent : 0;
            baseScore = s.BaseScore;
            gridHeight = gridWidth = squareWidth * squareHeight;
            gridLength = gridHeight * gridWidth;
            numberOfSquares = gridHeight;
            numbersArray = new int[gridLength];
            originalNumbersArray = new int[gridLength];
            lastSaveNumbersArray = new int[gridLength];
        }
        public GameSettings GetSettings()
        {
            GameSettings s = new GameSettings();
            s.SquareWidth = squareWidth;
            s.SquareHeight = squareHeight;
            s.Highscore = highScore;
            s.TargetTime = targetTime;
            s.HintsUsed = hintsUsed;
            s.TimeSpent = timeTaken;
            s.BaseScore = baseScore;
            return s;
        }

        public Dictionary<string, string> SplitInput(string input)
        {
            var parts = new Dictionary<string, string>();
            string[] inputParts = input.Split('*');
            parts.Add("Settings", inputParts[0]);
            parts.Add("OriginalSudoku", inputParts[1]);
            if (inputParts.Length>2)
            {
                parts.Add("EditedSudoku", inputParts[2]);
            }
            return parts;
        }

        public int[] ToNumberList(string csvString)
        {
            string[] arrayOfStrings = Regex.Replace(csvString.TrimEnd('\r', '\n'), @"\t|\r\n|\n", ",").Split(',');
            return Array.ConvertAll(arrayOfStrings, int.Parse);
        }

        public string SaveGame()
        {
            lastSaveNumbersArray = numbersArray;
            string gameSettings = WriteJsonSettings(GetSettings());
            string original = ToCSVString(originalNumbersArray);
            string currentSave = ToCSVString(numbersArray);
            return ToCSV(currentGameFile,gameSettings, original, currentSave);
        }

        public string ToCSV(string filePath, string settingsJSON, string original, string currentSave)
        { 
            string csvString = settingsJSON + "\n*" + original + "\n*" + currentSave;
            File.WriteAllText(filePath, csvString);
            lastSaveNumbersArray = numbersArray;
            return csvString;
        }

        public string ToCSVString(int[] numbers)
        {
            string result = numbers[0].ToString();
            for (int i = 1; i < numbers.Length; i++)
            {
                string number = numbers[i].ToString();
                bool endOfLine = i % Math.Sqrt(numbers.Length) == 0 && i != 0;
                bool isLastNumber = i == numbers.Length;
                result += isLastNumber ? number : endOfLine ? "\n" + number: "," + number;
            }
            return result;
        }

        public string GetRelativePath(string path1, string path2)
        {
            Uri uri1 = new Uri(path1);
            Uri uri2 = new Uri(path2);

            Uri relativeUri = uri2.MakeRelativeUri(uri1);
            return relativeUri.ToString();
        }

        public int GetCell(int gridIndex) => numbersArray[gridIndex];

        public void SetCell(int value, int gridIndex) => numbersArray[gridIndex] = value;
 
        public string ToPrettyString()
        {
            string line = MakeLine(squareWidth) + "\n";
            for (int i = 0; i < numbersArray.Length; i++)
            {
                if (i % squareWidth == 0)
                {
                    line += "|";
                }
                int a = ((squareWidth * squareHeight) * squareHeight);
                if (i % a == 0 && i != 0)
                {
                    line += "\n" + MakeLine(squareWidth);
                }
                bool endOfLine = i % (squareWidth * squareHeight) == 0 && i != 0;
                line += endOfLine ? "\n|" + MakeSquare(numbersArray[i]) : MakeSquare(numbersArray[i]);
            }
            return line + "|\n" + MakeLine(squareWidth);
        }


        public string MakeSquare(int number)
        {
            string result = number.ToString();
            if (number.ToString().Length == 1)
            {
                result = " " + number + "  ";
            }
            if (number.ToString().Length == 2)
            {
                result = " " + number + " ";
            }
            return result;
        }

        public string MakeLine(int n)
        {
            int a = n * 4 * squareHeight + n;
            int i = 0;
            string result = "";
            do
            {
                result += "-";
                i++;
            } while (i <= ((n*4)* squareHeight )+ (squareHeight));
            return result;
        }
    }
}

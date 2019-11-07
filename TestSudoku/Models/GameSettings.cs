using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    [DataContract]
    public class GameSettings
    {
        [DataMember]
        public int TargetTime = 0;
        [DataMember]
        public int TimeSpent = 0;
        [DataMember]
        public int HintsUsed = 0;
        [DataMember]
        public int Highscore = 0;
        [DataMember]
        public int SquareWidth = 0;
        [DataMember]
        public int SquareHeight = 0;
        [DataMember]
        public int BaseScore = 0;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLPS
{
    public static class Game
    {
        public static int ComputerWins = 0;
        public static int HumanWins = 0;
        public static int Ties = 0;
        public static int TotalGames = 0;

        public enum HandWeapons
        {
            Rock, Scissors, Lizard, Paper, Spock
        }
        public enum WinningActions
        {
            cut, covers, crushes, poisons, smashes, decapitate, eats, disproves, vaporizes
        }
        public enum Results
        {
            ComputerWin, HumanWin, Tie
        }

    }
}

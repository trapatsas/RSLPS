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
            cut, covers, crushes, poisons, smashes, decapitate, eats, disproves, vaporizes, tie
        }
        public enum Results
        {
            ComputerWin, HumanWin, Tie
        }

        public static List<Decision> PossibleOutcomes = new List<Decision>()
            {
                new Decision { HumanWeapon = Game.HandWeapons.Rock, AIWeapon = Game.HandWeapons.Rock, MatchResult = Game.Results.Tie, TimesPlayed = 0, WeaponCry = Game.WinningActions.tie},
                new Decision { HumanWeapon = Game.HandWeapons.Paper, AIWeapon = Game.HandWeapons.Lizard, MatchResult = Game.Results.ComputerWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.decapitate}
            };
    }
}

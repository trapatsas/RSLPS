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
                new Decision { HumanWeapon = Game.HandWeapons.Rock, AIWeapon = Game.HandWeapons.Lizard
                    , MatchResult = Game.Results.HumanWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.crushes},
                new Decision { HumanWeapon = Game.HandWeapons.Paper, AIWeapon = Game.HandWeapons.Rock
                    , MatchResult = Game.Results.HumanWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.covers},
                new Decision { HumanWeapon = Game.HandWeapons.Scissors, AIWeapon = Game.HandWeapons.Paper
                    , MatchResult = Game.Results.HumanWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.crushes},
                new Decision { HumanWeapon = Game.HandWeapons.Lizard, AIWeapon = Game.HandWeapons.Spock
                    , MatchResult = Game.Results.HumanWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.poisons},
                new Decision { HumanWeapon = Game.HandWeapons.Spock, AIWeapon = Game.HandWeapons.Scissors
                    , MatchResult = Game.Results.HumanWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.smashes},
                new Decision { HumanWeapon = Game.HandWeapons.Scissors, AIWeapon = Game.HandWeapons.Lizard
                    , MatchResult = Game.Results.HumanWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.decapitate},
                new Decision { HumanWeapon = Game.HandWeapons.Lizard, AIWeapon = Game.HandWeapons.Paper
                    , MatchResult = Game.Results.HumanWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.eats},
                new Decision { HumanWeapon = Game.HandWeapons.Paper, AIWeapon = Game.HandWeapons.Spock
                    , MatchResult = Game.Results.HumanWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.disproves},
                new Decision { HumanWeapon = Game.HandWeapons.Spock, AIWeapon = Game.HandWeapons.Rock
                    , MatchResult = Game.Results.HumanWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.vaporizes},
                new Decision { HumanWeapon = Game.HandWeapons.Rock, AIWeapon = Game.HandWeapons.Scissors
                    , MatchResult = Game.Results.HumanWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.crushes},
                new Decision { AIWeapon = Game.HandWeapons.Rock, HumanWeapon = Game.HandWeapons.Lizard
                    , MatchResult = Game.Results.ComputerWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.crushes},
                new Decision { AIWeapon = Game.HandWeapons.Paper, HumanWeapon = Game.HandWeapons.Rock
                    , MatchResult = Game.Results.ComputerWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.covers},
                new Decision { AIWeapon = Game.HandWeapons.Scissors, HumanWeapon = Game.HandWeapons.Paper
                    , MatchResult = Game.Results.ComputerWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.crushes},
                new Decision { AIWeapon = Game.HandWeapons.Lizard, HumanWeapon = Game.HandWeapons.Spock
                    , MatchResult = Game.Results.ComputerWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.poisons},
                new Decision { AIWeapon = Game.HandWeapons.Spock, HumanWeapon = Game.HandWeapons.Scissors
                    , MatchResult = Game.Results.ComputerWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.smashes},
                new Decision { AIWeapon = Game.HandWeapons.Scissors, HumanWeapon = Game.HandWeapons.Lizard
                    , MatchResult = Game.Results.ComputerWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.decapitate},
                new Decision { AIWeapon = Game.HandWeapons.Lizard, HumanWeapon = Game.HandWeapons.Paper
                    , MatchResult = Game.Results.ComputerWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.eats},
                new Decision { AIWeapon = Game.HandWeapons.Paper, HumanWeapon = Game.HandWeapons.Spock
                    , MatchResult = Game.Results.ComputerWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.disproves},
                new Decision { AIWeapon = Game.HandWeapons.Spock, HumanWeapon = Game.HandWeapons.Rock
                    , MatchResult = Game.Results.ComputerWin, TimesPlayed = 0, WeaponCry = Game.WinningActions.vaporizes},
                new Decision { AIWeapon = Game.HandWeapons.Rock, HumanWeapon = Game.HandWeapons.Scissors
                    , MatchResult = Game.Results.Tie, TimesPlayed = 0, WeaponCry = Game.WinningActions.crushes},
                new Decision { AIWeapon = Game.HandWeapons.Scissors, HumanWeapon = Game.HandWeapons.Scissors
                    , MatchResult = Game.Results.Tie, TimesPlayed = 0, WeaponCry = Game.WinningActions.tie},
                new Decision { AIWeapon = Game.HandWeapons.Lizard, HumanWeapon = Game.HandWeapons.Lizard
                    , MatchResult = Game.Results.Tie, TimesPlayed = 0, WeaponCry = Game.WinningActions.tie},
                new Decision { AIWeapon = Game.HandWeapons.Paper, HumanWeapon = Game.HandWeapons.Paper
                    , MatchResult = Game.Results.Tie, TimesPlayed = 0, WeaponCry = Game.WinningActions.tie},
                new Decision { AIWeapon = Game.HandWeapons.Spock, HumanWeapon = Game.HandWeapons.Spock
                    , MatchResult = Game.Results.Tie, TimesPlayed = 0, WeaponCry = Game.WinningActions.tie},
                new Decision { AIWeapon = Game.HandWeapons.Rock, HumanWeapon = Game.HandWeapons.Rock
                    , MatchResult = Game.Results.Tie, TimesPlayed = 0, WeaponCry = Game.WinningActions.tie}
            };
    }
}

//Scissors cut paper
//Paper covers rock
//Rock crushes lizard
//Lizard poisons Spock
//Spock smashes scissors
//Scissors decapitate lizard
//Lizard eats paper
//Paper disproves Spock
//Spock vaporizes rock
//Rock crushes scissors
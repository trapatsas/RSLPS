using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RSLPS
{
    class Program
    {
        static void Main(string[] args)
        {
            Game.GameMode CurrentMode = Game.GameMode.Learning;
            string aiChoice = "";
                Console.WriteLine("\"Learning AI\" Game Mode is selected by default.");
                Console.WriteLine("Press \"R\" to choose back to \"Random AI\" mode");
                Console.Write("or any other key to continue: ");
                aiChoice = Console.ReadLine();
                Console.WriteLine("");
                switch (aiChoice.ToUpper())
                {
                    case "R":
                        CurrentMode = Game.GameMode.Random;
                        Console.WriteLine("\"Random AI\" Mode Selected!");
                        break;
                    default:
                        Console.WriteLine("\"Learning AI\" Mode Selected!");
                        break;
                }


            Console.WriteLine("");
            Console.WriteLine("╔=========  Wellcome  =========╗");
            Console.WriteLine("║    Please select a weapon:   ║");
            Console.WriteLine("║ 1. Rock (R)                  ║");
            Console.WriteLine("║ 2. Paper (P)                 ║");
            Console.WriteLine("║ 3. Scissors(Sc)              ║");
            Console.WriteLine("║ 4. Lizard (Li)               ║");
            Console.WriteLine("║ 5. Spock (Sp)                ║");
            Console.WriteLine("║    or type \"Q\" to quit!      ║");
            Console.WriteLine("╚==============================╝");
            Console.WriteLine("");

            string input = "";
            Weapon userChoice = null;

            while (input.ToUpper() != "Q")
            {
                Console.WriteLine("");
                Console.WriteLine(" =============> Round {0} <=============", Game.TotalGames + 1);
                Console.Write("Type your choice: ");
                input = Console.ReadLine();

                switch (input.ToUpper()) //Switch on Key enum
                {
                    case "0":
                    case "Q":
                    case "QUIT":
                    case "EXIT":
                        input = "Q";
                        break;
                    case "1":
                    case "R":
                    case "RO":
                    case "ROCK":
                        userChoice = new Weapon(Game.HandWeapons.Rock);
                        break;
                    case "3":
                    case "SC":
                    case "SCISSORS":
                        userChoice = new Weapon(Game.HandWeapons.Scissors);
                        break;
                    case "4":
                    case "L":
                    case "LI":
                    case "LIZARD":
                        userChoice = new Weapon(Game.HandWeapons.Lizard);
                        break;
                    case "2":
                    case "P":
                    case "PA":
                    case "PAPER":
                        userChoice = new Weapon(Game.HandWeapons.Paper);
                        break;
                    case "5":
                    case "SP":
                    case "SPOCK":
                        userChoice = new Weapon(Game.HandWeapons.Spock);
                        break;
                    default:
                        userChoice = null;
                        Console.WriteLine("*** Invalid choice. You can only type: R, SC, L, P and SP here! ***");
                        break;
                }
                if (userChoice != null) BeginRound(userChoice, CurrentMode);
            }
        }

        private static void BeginRound(Weapon userChoice, Game.GameMode CurrentMode)
        {
            Game.TotalGames++;

            Round newRound = new Round(userChoice);

            string winner = "";

            switch (newRound.RoundResult)
            {
                case Game.Results.ComputerWin:
                    Game.ComputerWins++;
                    winner = string.Format("{0} {2} {1}. You Lost!", newRound.ComputerWeapon.Name, userChoice.Name, newRound.WeaponCry);
                    break;
                case Game.Results.HumanWin:
                    Game.HumanWins++;
                    winner = string.Format("{1} {2} {0}. You Win!", newRound.ComputerWeapon.Name, userChoice.Name, newRound.WeaponCry);
                    break;
                case Game.Results.Tie:
                    Game.Ties++;
                    winner = string.Format("The game is a tie. Let's go again!");
                    break;
                default:
                    break;
            }


            string PlayerPick = string.Format("Player Picks {0}", userChoice.Name);
            string ComputerPick = string.Format("Computer Picks {0}", newRound.ComputerWeapon.Name);

            string TotalGamesPlayed = string.Format("Total Games played: {0}.", Game.TotalGames);
            string ComputerWins = string.Format("Computer Wins: {0} ({1:0.00}%).", Game.ComputerWins, ((decimal)Game.ComputerWins / (decimal)Game.TotalGames) * 100);
            string HumanWins = string.Format("Human Wins: {0} ({1:0.00}%).", Game.HumanWins, ((float)Game.HumanWins / (float)Game.TotalGames) * 100);
            string Ties = string.Format("Ties: {0} ({1:0.00}%).", Game.Ties, ((decimal)Game.Ties / (decimal)Game.TotalGames) * 100);
            Console.WriteLine(" >>>>> Round Results <<<<<");
            Console.WriteLine(string.Format("{0} and {1}.", PlayerPick, ComputerPick));
            Console.WriteLine("");
            Console.WriteLine(winner);
            Console.WriteLine("");
            Console.WriteLine(string.Format("Game Mode: {0} AI", CurrentMode.ToString()));
            Console.WriteLine(" >>>>> Some Stats <<<<<");
            Console.WriteLine(TotalGamesPlayed);
            Console.WriteLine(ComputerWins);
            Console.WriteLine(HumanWins);
            Console.WriteLine(Ties);
        }
    }
    public static class Game
    {
        public static int ComputerWins = 0;
        public static int HumanWins = 0;
        public static int Ties = 0;
        public static int TotalGames = 0;

        public enum GameMode
        {
            Learning, Random
        }
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

        #region Decision Table
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
        #endregion
    }
    class Round
    {
        public Weapon HumanWeapon { get; set; }
        public Weapon ComputerWeapon { get; private set; }
        public Game.Results RoundResult { get; private set; }
        public Game.WinningActions WeaponCry { get; private set; }

        Random random = new Random();
        Array values = Enum.GetValues(typeof(Game.HandWeapons));

        public Round(Weapon userChoice)
        {
            this.HumanWeapon = userChoice;
            this.ComputerWeapon = LearningAI();
            Decision matchOutcome = AIDecision(userChoice);
            this.WeaponCry = matchOutcome.WeaponCry;
            this.RoundResult = matchOutcome.MatchResult;
            matchOutcome.TimesPlayed++;
        }

        private Weapon RandomAI()
        {
            return new Weapon((Game.HandWeapons)values.GetValue(random.Next(values.Length)));
        }

        private Weapon LearningAI()
        {
            Dictionary<string, int> t = new Dictionary<string, int>();

            foreach (var item in (Game.HandWeapons[])Enum.GetValues(typeof(Game.HandWeapons)))
            {
                t.Add(String.Format("{0}", item.ToString()), Game.PossibleOutcomes.Where(x => x.HumanWeapon == item).Sum(x => x.TimesPlayed));
            }
            var MaxKeys = t.Where(a => a.Value == t.Values.Max()).Select(x => x.Key.ToString()).ToArray().First();

            var d = Game.PossibleOutcomes.Find(item => item.HumanWeapon == (Game.HandWeapons)Enum.Parse(typeof(Game.HandWeapons), MaxKeys) && item.MatchResult == Game.Results.ComputerWin);

            return new Weapon(d.AIWeapon);
        }

        private Decision AIDecision(Weapon userChoice)
        {
            return Game.PossibleOutcomes.Find(item => item.HumanWeapon == userChoice.Name && item.AIWeapon == this.ComputerWeapon.Name);
        }
    }
    public class Decision
    {
        public Game.HandWeapons HumanWeapon { get; set; }
        public Game.HandWeapons AIWeapon { get; set; }
        public Game.Results MatchResult { get; set; }
        public Game.WinningActions WeaponCry { get; set; }
        public int TimesPlayed { get; set; }
    }
    class Weapon
    {
        public Weapon(Game.HandWeapons value)
        {
            Name = value;
        }
        public Game.HandWeapons Name { get; set; }

        public Game.WinningActions Cry { get; set; }
    }
}

using System;
using System.Text;

namespace RSLPS
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            Weapon userChoice = null;

            while (input.ToUpper() != "Q")
            {
                Console.WriteLine("");
                Console.WriteLine("╔======================================================================╗");
                Console.WriteLine("║ Please select a weapon                                               ║");
                Console.WriteLine("║ Rock (R)- Paper (P)- Scissors(Sc) - Lizard (Li) - Spock (Sp)         ║");
                Console.WriteLine("║ or type \"Q\" to quit!                                                 ║");
                Console.WriteLine("╚======================================================================╝");
                Console.WriteLine("");
                Console.WriteLine("Type your choice: ");
                Console.WriteLine("");

                input = Console.ReadLine();

                switch (input.ToUpper()) //Switch on Key enum
                {
                    case "Q":
                    case "QUIT":
                    case "EXIT":
                        input = "Q";
                        break;
                    case "R":
                    case "RO":
                    case "ROCK":
                        userChoice = new Weapon(Game.HandWeapons.Rock);
                        break;
                    case "SC":
                    case "SCISSORS":
                        userChoice = new Weapon(Game.HandWeapons.Scissors);
                        break;
                    case "L":
                    case "LI":
                    case "LIZARD":
                        userChoice = new Weapon(Game.HandWeapons.Lizard);
                        break;
                    case "P":
                    case "PA":
                    case "PAPER":
                        userChoice = new Weapon(Game.HandWeapons.Paper);
                        break;
                    case "SP":
                    case "SPOCK":
                        userChoice = new Weapon(Game.HandWeapons.Spock);
                        break;
                    default:
                        userChoice = null;
                        Console.WriteLine("*** Invalid choice. You can only type: R, SC, L, P and SP here! ***");
                        break;
                }
                if (userChoice != null) BeginRound(userChoice);
            }
        }

        private static void BeginRound(Weapon userChoice)
        {
            Game.TotalGames++;

            Round newRound = new Round(userChoice);

            switch (newRound.RoundResult)
            {
                case Game.Results.ComputerWin:
                    Game.ComputerWins++;
                    break;
                case Game.Results.HumanWin:
                    Game.HumanWins++;
                    break;
                case Game.Results.Tie:
                    Game.Ties++;
                    break;
                default:
                    break;
            }


            string PlayerPick = string.Format("║ Player Picks: {0}.", userChoice.Name);
            string ComputerPick = string.Format("║ Computer Picks: {0}.", newRound.ComputerWeapon.Name);

            string TotalGamesPlayed = string.Format("║ Total Games played: {0}.", Game.TotalGames);
            string ComputerWins = string.Format("║ Computer Wins: {0} ({1}%).", Game.ComputerWins, (Game.ComputerWins / Game.TotalGames) * 100);
            string HumanWins = string.Format("║ Human Wins: {0} ({1}%).", Game.HumanWins, (Game.HumanWins / Game.TotalGames) * 100);
            string Ties = string.Format("║ Ties: {0} ({1}%).", Game.Ties, (Game.Ties / Game.TotalGames) * 100);
            Console.WriteLine("╔==================================╗");
            Console.WriteLine(PlayerPick);
            Console.WriteLine(ComputerPick);
            Console.WriteLine(TotalGamesPlayed);
            Console.WriteLine(ComputerWins);
            Console.WriteLine(HumanWins);
            Console.WriteLine(Ties);
            Console.WriteLine("╚==================================╝");
        }
    }
}

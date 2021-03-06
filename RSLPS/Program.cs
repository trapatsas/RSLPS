﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RSLPS
{
    class Program
    {
        static void Main(string[] args)
        {
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
                if (userChoice != null) BeginRound(userChoice);
            }
        }

        private static void BeginRound(Weapon userChoice)
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
            Console.WriteLine(" >>>>> Some Stats <<<<<");
            Console.WriteLine(TotalGamesPlayed);
            Console.WriteLine(ComputerWins);
            Console.WriteLine(HumanWins);
            Console.WriteLine(Ties);
        }
    }
}

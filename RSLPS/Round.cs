using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLPS
{
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
            this.ComputerWeapon = new Weapon((Game.HandWeapons)values.GetValue(random.Next(values.Length)));
            Decision matchOutcome = Game.PossibleOutcomes.Find(item => item.HumanWeapon == userChoice.Name && item.AIWeapon == this.ComputerWeapon.Name);
            this.WeaponCry = matchOutcome.WeaponCry;
            this.RoundResult = matchOutcome.MatchResult;
            matchOutcome.TimesPlayed++;
        }
    }
}

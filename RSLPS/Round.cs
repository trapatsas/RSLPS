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
            Dictionary<string, int> t = new Dictionary<string,int>();

            foreach (var item in (Game.HandWeapons[]) Enum.GetValues(typeof(Game.HandWeapons)))
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
}

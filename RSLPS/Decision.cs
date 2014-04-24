using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLPS
{
    public class Decision
    {
        public Game.HandWeapons HumanWeapon { get; set; }
        public Game.HandWeapons AIWeapon { get; set; }
        public Game.Results MatchResult { get; set; }
        public Game.WinningActions WeaponCry { get; set; }
        public int TimesPlayed { get; set; }
    }
}

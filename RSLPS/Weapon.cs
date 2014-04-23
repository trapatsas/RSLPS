using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSLPS
{
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

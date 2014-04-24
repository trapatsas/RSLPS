﻿using System;
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

            #region QuickResult
            //if (this.ComputerWeapon.Name == this.HumanWeapon.Name)
            //{
            //     this.RoundResult = Game.Results.Tie;
            //}
            //else if (((int)this.ComputerWeapon.Name == (int)this.HumanWeapon.Name%5 + 1) || ((int)this.ComputerWeapon.Name == (int)this.HumanWeapon.Name%5 + 2))
            //{
            //    this.RoundResult = Game.Results.ComputerWin;
            //}
            //else
            //{
            //    this.RoundResult = Game.Results.HumanWin;
            //}
            #endregion

            this.RoundResult = fight(this.HumanWeapon.Name, this.ComputerWeapon.Name);
        }

        private Game.Results fight(Game.HandWeapons w1, Game.HandWeapons w2)
        {
            return Game.Results.Tie;
        }
    }
}
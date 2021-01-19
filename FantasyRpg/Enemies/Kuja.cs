using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRpg.Enemies
{
    class Kuja : Monster
    {
        public Kuja()
        {

        }
        public Kuja(string _name)
        {
            name = _name;
            NameRare = "Tranced Kuja";
            hp = 200;
            damage = 220;
            minDamage = 120;
            maxDamage = 220;
            gold = 2200;
            exp = 520;
        }
    }
}

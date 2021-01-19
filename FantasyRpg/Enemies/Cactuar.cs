using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRpg.Enemies
{
    class Cactuar : Monster
    {
        public Cactuar()
        {

        }
        public Cactuar(string _name)
        {
            name = _name;
            NameRare = "Mad Cactuar";
            hp = 200;
            damage = 220;
            minDamage = 120;
            maxDamage = 220;
            gold = 2200;
            exp = 520;
        }
    }
}

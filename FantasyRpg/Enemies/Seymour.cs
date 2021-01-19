using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRpg.Enemies
{
    class Seymour : Monster
    {
        public Seymour()
        {

        }
        public Seymour(string _name)
        {
            name = _name;
            NameRare = "Seymour Omnis";
            hp = 200;
            damage = 220;
            minDamage = 120;
            maxDamage = 220;
            gold = 2200;
            exp = 520;
        }
    }
}

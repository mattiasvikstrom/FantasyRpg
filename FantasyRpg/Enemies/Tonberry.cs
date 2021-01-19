using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRpg.Enemies
{
    class Tonberry : Monster
    {
        public Tonberry()
        {

        }
        public Tonberry(string _name)
        {
            name = _name;
            NameRare = "Golden Tonberry";
            hp = 200;
            damage = 220;
            minDamage = 120;
            maxDamage = 220;
            gold = 2200;
            exp = 520;
        }
    }
}

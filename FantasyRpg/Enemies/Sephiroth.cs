using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRpg.Enemies
{
    class Sephiroth : Monster
    {
        public Sephiroth()
        {

        }
        public Sephiroth(string _name)
        {
            name = _name;
            NameRare = "Safer Sephiroth";
            hp = 200;
            damage = 220;
            minDamage = 120;
            maxDamage = 220;
            gold = 2200;
            exp = 520;
        }
    }
}

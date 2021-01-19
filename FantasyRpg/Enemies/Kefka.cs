using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRpg.Enemies
{
    class Kefka : Monster
    {
        public Kefka()
        {

        }
        public Kefka(string _name)
        {
            name = _name;
            NameRare = "Kefka, God of magic";
            hp = 200;
            damage = 220;
            minDamage = 120;
            maxDamage = 220;
            gold = 2200;
            exp = 520;
        }
    }
}

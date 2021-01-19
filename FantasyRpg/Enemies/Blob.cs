using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRpg.Enemies
{
    class Blob : Monster
    {
        public Blob()
        {

        }
        public Blob(string _name)
        {
            name = _name;
            NameRare = "Crimson Blob";
            hp = 800;
            damage = 20;
            minDamage = 15;
            maxDamage = 30;
            gold = 2200;
            exp = 60;
        }
        public override void Specialist()
        {
            name = NameRare;
            hp *= 10;
            minDamage *= 10;
            maxDamage *= 10;
        }
    }
}

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
            minDamage = 30;
            maxDamage = 70;
            gold = 2200;
            exp = 150;
        }
        public override float MonsterAttackBasic(float mobDamage)
        {
            Console.WriteLine($"{name} uses 100 needles!");
            return mobDamage;
        }
        public override float MonsterAttackNormal(float mobDamage)
        {
            Console.WriteLine($"{name} uses 500 needles!");
            mobDamage *= 1.2f;
            return mobDamage;
        }
        public override float MonsterAttackSpecial(float mobDamage)
        {
            Console.WriteLine($"{name} uses 1000 needles!");
            mobDamage *= 2;
            return mobDamage;
        }
    }
}

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
            hp = 1300;
            minDamage = 40;
            maxDamage = 85;
            gold = 600;
            exp = 275;
        }
        public override float MonsterAttackBasic(float mobDamage)
        {
            Console.WriteLine($"{name} uses Lance of Atrophy!");
            return mobDamage;
        }
        public override float MonsterAttackNormal(float mobDamage)
        {
            Console.WriteLine($"{name} casts Flare!");
            mobDamage *= 1.2f;
            return mobDamage;
        }
        public override float MonsterAttackSpecial(float mobDamage)
        {
            Console.WriteLine($"{name} casts Thundaga!");
            mobDamage *= 2;
            return mobDamage;
        }
    }
}

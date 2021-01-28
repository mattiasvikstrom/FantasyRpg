using System;

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
            hp = 1200;
            minDamage = 1;
            maxDamage = 80;
            gold = 320;
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

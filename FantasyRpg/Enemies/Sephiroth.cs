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
            minDamage = 40;
            maxDamage = 90;
            gold = 2200;
            exp = 150;
        }
        public override float MonsterAttackBasic(float mobDamage)
        {
            Console.WriteLine($"{name} attacks you with Masamune");
            return mobDamage;
        }
        public override float MonsterAttackNormal(float mobDamage)
        {
            Console.WriteLine($"{name} uses Pale horse!");
            mobDamage *= 1.2f;
            return mobDamage;
        }
        public override float MonsterAttackSpecial(float mobDamage)
        {
            Console.WriteLine($"{name} uses Super Nova!!");
            mobDamage *= 2;
            return mobDamage;
        }
    }
}

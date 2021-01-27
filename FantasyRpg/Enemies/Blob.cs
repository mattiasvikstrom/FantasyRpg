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
            hp = 600;
            minDamage = 36;
            maxDamage = 55;
            gold = 250;
            exp = 60;
        }
        public override float MonsterAttackBasic(float mobDamage)
        {
            Console.WriteLine($"{name} attacks you with its slimy tentacle, it burns!");
            return mobDamage;
        }
        public override float MonsterAttackNormal(float mobDamage)
        {
            Console.WriteLine($"{name} shoots a mass of slime!");
            mobDamage *= 1.2f;
            return mobDamage;
        }
        public override float MonsterAttackSpecial(float mobDamage)
        {
            Console.WriteLine($"{name} starts glowing, and casts Fira magic on you!");
            mobDamage *= 2;
            return mobDamage;
        }
        public override void Specialist()
        {
            //name = NameRare;
            //hp *= 10;
            //minDamage *= 10;
            //maxDamage *= 10;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRpg.Enemies
{
    class Rogue : Monster
    {
       
        public Rogue()
        {

        }

        public Rogue(string _name)
        {
            name = _name;
            NameRare = "Rogue Specialist";
            hp = 600;
            minDamage = 28;
            maxDamage = 40;
            gold = 200;
            exp = 75;
        }

        public override float MonsterAttackBasic(float mobDamage)
        {
            Console.WriteLine($"{name} attacks you with his dagger");
            return mobDamage;
        }
        public override float MonsterAttackNormal(float mobDamage)
        {
            Console.WriteLine($"{name} throws an explosive bomb in your direction!");
            mobDamage *= 1.5f; 
            return mobDamage;
        }
        public override float MonsterAttackSpecial(float mobDamage)
        {
            Console.WriteLine($"{name} vanishes.... chills come as you feel a presence behind you! Two daggers strikes!");
            mobDamage *= 2;
            return mobDamage;
        }
        //Chance to face a power powerful monster. not fully implemented
        public override void Specialist()
        {
            name = NameRare;
            hp *= 10 / 5;
            minDamage *= 10 / 8;
            maxDamage *= 10 / 8;
        }
        //keep for test printing and stats check
        public override string ToString()
        {
            return $"Heeeeloo {name}\n" +
                   $"HP {hp}\n" +
                   $"MIN {minDamage}\n" +
                   $"MAX {maxDamage}\n" +
                   $"GOLD {gold}\n" +
                   $"EXP {exp}\n";
        }
    }
}

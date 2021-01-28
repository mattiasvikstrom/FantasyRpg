using System;

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
            hp = 600;
            minDamage = 38;
            maxDamage = 60;
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
    }
}

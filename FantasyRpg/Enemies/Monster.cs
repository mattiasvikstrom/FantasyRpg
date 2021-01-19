using FantasyRpg.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRpg.Enemies
{

    abstract class Monster : IMonster
    {
         //se så detta inte fuckar upp vem jag möter etc.
        public string name { get; set; }
        public string NameRare { get; set; }
        public float hp { get; set; }
        public int damage { get; set; }
        public int minDamage { get; set; }
        public int maxDamage { get; set; }
        public int gold { get; set; }
        public int exp { get; set; }
        public float dodge { get; set; }
        public float crit { get; set; }
        public int lvl { get; set; }
        public int def { get; set; }

        public Monster()
        {

        }
        public Monster(string _name)
        {
            name = _name;
        }
        //basic attack method, can be overridden
        public virtual int MonsterDamage(List<Monster> mob, int b)
        {
            int mobDamage = Game.RandomAttackDamage(minDamage, maxDamage);
            return mobDamage;
        }
        public virtual bool Attack(Hero hero, List<Monster> mob, int b, bool defend)
        {
            
            float mobDamage = MonsterDamage(mob, b);

            mobDamage -= hero.def;
            //monsterdamage cant be lower than 0
            if (mobDamage < 0)
            {
                mobDamage = 0;
            }
            if (defend == true)
            {
                float blockCap = 75;
                float mobDamageHoldValue;
                //player cannot exceed 75% block rate cap 
                if (hero.block > blockCap)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("**Over Blockcap**");
                    Console.ResetColor();
                    float blockValue = blockCap;
                    //save the mobs initial attack damage
                    mobDamageHoldValue = mobDamage;
                    //reduce mobs damage by the amount blocked by player , mobDamage: 20 would be 5 with 15 blocked damage
                    Math.Round(mobDamage -= (mobDamage / 100) * blockValue);

                    //get the actual value that was blocked by the hero for display purpose in battle logg
                    mobDamageHoldValue -= mobDamage;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("**not exceeding Blockcap**");
                    Console.ResetColor();
                    //mob damage 20, block 75%
                    //get % value of block
                    float blockValue = hero.block;
                    //save the mobs initial attack damage
                    mobDamageHoldValue = mobDamage;
                    //reduce mobs damage by the amount blocked by player , mobDamage: 20 would be 5 with 15 blocked damage
                    Math.Round(mobDamage -= (mobDamage / 100) * blockValue);

                    //get the actual value that was blocked by the hero for display purpose in battle logg
                    mobDamageHoldValue -= mobDamage;
                    //deal the reduced damage to the player
                    hero.hp -= mobDamage;
                }

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{hero.name} blocked {mobDamageHoldValue}!");
                Console.ResetColor();
            }
            else
            {
                hero.hp -= mobDamage;
            }
            //Hero defending is deactivated at this point
            defend = false;

            Console.WriteLine($"{mob[b].name} attacks for {mobDamage}");
            Console.WriteLine($"{hero.name} has hp: {hero.hp} left");
            return defend;
        }

        //Chance to face a specialist version of the opponent with increased stats
        public virtual void Specialist()
        {

        }


        public virtual int GiveGold() { return gold; }
        public static List<Monster> CreateMonster(Hero hero)
        {
            List<Monster> mob = new List<Monster>()
             {
                new Rogue("Rogue"),
                new Blob("Blob")
             };

            return mob;
        }
    }
}

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
        public virtual float MonsterAttackList(float mobDamage)
        {
            Random ran = new Random();
            var rand = ran.Next(1, 4);
            if (rand <= 50)
            {
                mobDamage = MonsterAttackBasic(mobDamage);
            }
            else if (rand >= 51 && rand <= 80)
            {
                mobDamage = MonsterAttackNormal(mobDamage);
            }
            else
            {
                mobDamage = MonsterAttackSpecial(mobDamage);
            }
            return mobDamage;
        }
        public virtual float MonsterAttackBasic(float mobDamage)
        {
            return mobDamage;
        }
        public virtual float MonsterAttackNormal(float mobDamage)
        {
            return mobDamage;
        }
        public virtual float MonsterAttackSpecial(float mobDamage)
        {
            return mobDamage;
        }
        public virtual bool MonsterCombat(Hero hero, List<Monster> mob, int b, bool defend)
        {
            
            float mobDamage = MonsterDamage(mob, b);
            mobDamage = MonsterAttackList(mobDamage);
            Math.Round(mobDamage);
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
                //player is not allowed to exceed 75% block rate cap 
                if (hero.block > blockCap)
                {
                    //save the mobs initial attack damage
                    mobDamageHoldValue = mobDamage;
                    //reduce mobs damage by the amount blocked by player , mobDamage: 20 would be 5 with 15 blocked damage
                    Math.Round(mobDamage -= (mobDamage / 100) * blockCap);
                    //get the actual value that was blocked by the hero for display purpose in battle logg
                    mobDamageHoldValue -= mobDamage;
                }
                else
                {
                    //save the mobs initial attack damage
                    mobDamageHoldValue = mobDamage;
                    //reduce mobs damage by the amount blocked by player , mobDamage: 20 would be 5 with 15 blocked damage
                    Math.Round(mobDamage -= (mobDamage / 100) * hero.block);
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
                new Blob("Blob"),
                new Tonberry("Tonberry"),
                new Cactuar("Cactuar"),
                new Kuja("Kuja"),
                new Seymour("Seymour"),
                new Sephiroth("Sephiroth"),
                new Kefka("Kefka")
             };

            return mob;
        }
    }
}

using FantasyRpg.Player;
using System;
using System.Collections.Generic;

namespace FantasyRpg.Enemies
{

    abstract class Monster : IMonster
    {
         //se så detta inte fuckar upp vem jag möter etc.
        public string name { get; set; }
        public string NameRare { get; set; }
        public float hp { get; set; }
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
        //Calculates the monster damage
        public virtual int MonsterDamage(List<Monster> mob, int b)
        {
            int mobDamage = Game.RandomAttackDamage(minDamage, maxDamage);
            return mobDamage;
        }
        //Evaluates which of the possible monsterattacks is to be performed
        public virtual float MonsterAttackList(float mobDamage)
        {
            Random ran = new Random();
            var rand = ran.Next(1, 101);
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
        //Monsters have basic, normal and special, they are overridden on each monster and can do different damage
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
        //Handles the monster portion of the combat, rest is handled in HeroMethods.Battle()
        public virtual void MonsterCombat(Hero hero, List<Monster> mob, int b)
        {
            float mobDamage = MonsterDamage(mob, b);
            mobDamage = MonsterAttackList(mobDamage);

            mobDamage = (int)Math.Round(mobDamage);
            mobDamage -= hero.def;
            //monsterdamage cant be lower than 0
            if (mobDamage < 0)
            {
                mobDamage = 0;
            }
            else
            {
                hero.hp -= mobDamage;
            }
            Console.WriteLine($"{mob[b].name} does {mobDamage} damage");
            Console.WriteLine($"{hero.name} has hp: {hero.hp} left\n");
        }

        //Chance to face a specialist version of the opponent with increased stats
        public virtual void Specialist()
        {
            //not implemented yet
        }
        //Method evaluates current level of the hero to determine which monsters are to be randomly choosen for battle
        public static int CheckLevel(Hero hero)
        {
            int randomNumb = 0;
            var randomNum = new Random();

            if (hero.lvl < 3)
            {
                randomNumb = randomNum.Next(1, 3);
            }
            else if (hero.lvl < 5)
            {
                randomNumb = randomNum.Next(3, 5);
            }
            else if (hero.lvl < 7)
            {
                randomNumb = randomNum.Next(5, 7);
            }
            else
            {
                randomNumb = randomNum.Next(7, 9);
            }

            return randomNumb;
        }
        //Method containing the possible monsters for combat
        public static List<Monster> CreateMonster(Hero hero)
        {
            var randomNumb = CheckLevel(hero);
            List<Monster> mob = new List<Monster>();
                switch(randomNumb)
                {
                case 1:
                mob.Add(new Rogue("Rogue"));
                    break;
                case 2:
                mob.Add(new Blob("Blob"));
                    break;
                case 3:
                mob.Add(new Tonberry("Tonberry"));
                    break;
                case 4:
                mob.Add(new Cactuar("Cactuar"));
                    break;
                case 5:
                mob.Add(new Kuja("Kuja"));
                    break;
                case 6:
                mob.Add(new Seymour("Seymour"));
                    break;
                case 7:
                mob.Add(new Sephiroth("Sephiroth"));
                    break;
                case 8:
                mob.Add(new Kefka("Kefka"));
                    break;
                };
            return mob;
        }
        //Method handles adjusting the monsters stats to continue putting up a somewhat challanging experience
        public static void MonsterAdjustStats(List<Monster> mob, Hero hero, int b)
        {
            mob[b].gold = mob[b].gold * hero.lvl / 2;
            mob[b].hp = mob[b].hp * hero.lvl;
            mob[b].minDamage *= hero.lvl / 2;
            mob[b].maxDamage *= hero.lvl / 2;
            mob[b].def *= hero.lvl / 2; 
        }
    }
}

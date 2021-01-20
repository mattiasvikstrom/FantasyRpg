using System;
using System.Collections.Generic;
using System.Text;
using FantasyRpg.Enemies;

namespace FantasyRpg.Player
{
    class HeroMethods
    {
        public static float HeroAttackBasic(Hero hero, List<Monster> mob, float heroDamage, int b)
        {
            Console.WriteLine("basic attack");
            var critical = CriticalChance(hero);
            if (critical > 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Critical hit!");
                Console.ResetColor();
            }
            heroDamage *= critical;
            heroDamage -= mob[b].def;
            Math.Round(heroDamage, 0);
            if (heroDamage < 0)
            {
                heroDamage = 0;
            }
            mob[b].hp -= heroDamage;
            return heroDamage;
        }
        public static float HeroAttackNormal(Hero hero, List<Monster> mob, float heroDamage, int b)
        {
            Console.WriteLine("normal attack");
            heroDamage *= 1.2f;
            var critical = CriticalChance(hero);
            if (critical > 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Critical hit!");
                Console.ResetColor();
            }
            heroDamage *= critical;
            heroDamage -= mob[b].def;
            Math.Round(heroDamage, 0);
            if (heroDamage < 0)
            {
                heroDamage = 0;
            }
            mob[b].hp -= heroDamage;
            return heroDamage;
        }
        public static float HeroAttackSpecial(Hero hero, List<Monster> mob, float heroDamage, int b)
        {
            Console.WriteLine("special attack");
            heroDamage *= 2;
            var critical = CriticalChance(hero);
            if (critical > 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Critical hit!");
                Console.ResetColor();
            }
            heroDamage *= critical;
            heroDamage -= mob[b].def;
            Math.Round(heroDamage, 0);
            if (heroDamage < 0)
            {
                heroDamage = 0;
            }
            mob[b].hp -= heroDamage;
            return heroDamage;
        }
        public static float HeroAttackList(Hero hero, List<Monster> mob, float heroDamage, int b)
        {
            Random ran = new Random();
            var rand = ran.Next(1, 101);
            if (rand <= 50)
            {
                heroDamage = HeroAttackBasic(hero, mob, heroDamage, b);
            }
            else if (rand >= 51 && rand <= 80)
            {
                heroDamage = HeroAttackNormal(hero, mob, heroDamage, b);
            }
            else
            {
                heroDamage = HeroAttackSpecial(hero, mob, heroDamage, b);
            }
            return heroDamage;
        }
        public static bool Battle(Hero hero)
        {
            Console.Clear();
            bool activeFight = true;
            //Checks for possible fight
            var battleChance = BattleChance();
            
            if (battleChance >= 11)
            {
                Console.WriteLine("You encountered an opponent!");
            }
            else
            {
                Console.WriteLine("No danger present.. this time.");
                activeFight = false;
            }

            //generate monster for the battle
            List<Monster> mob = Monster.CreateMonster(hero);
            //variables something something

            var a = mob.Count;
            int b = Convert.ToInt32(a - 1); //kolla om detta behövs med nya random metoden.

            int i = 0;
            int roundCounter = 0;
            bool battleOutcome = false;
            
            //turnbased fight. should player try to use potions? should combat be choicebased. attack, defend , heal, item?
            //Add paus between attacks or turnbased with choices for attack, defend och potion/heal
            int roundVerify = 0;

            while (activeFight)
            {

                if (hero.hp >= 1 && mob[b].hp >= 1)
                {
                    //Verify which round is active. One round needs both fighters to attack once. when both have, go to next round counter
                    if (roundVerify % 2 == 0)
                    {
                        roundCounter++;
                    }
                    Console.WriteLine($"BattleRound #{roundCounter}"); //kika varför det ibland ska tryckas 2 ggr på enter ...
                    Continue(hero, mob, b);

                    if (i % 2 == 0)
                    {
                        //Method determens what attackmove hero should make randomly.
                        float heroDamage = HeroDamage(hero);
                        heroDamage = HeroAttackList(hero, mob, heroDamage, b);

                        Console.WriteLine($"{hero.name} does {heroDamage} damage");
                        Console.WriteLine($"{mob[b].name} has hp: {mob[b].hp} left");

                        roundVerify++;
                    }
                    else
                    {
                        mob[b].MonsterCombat(hero, mob, b);
                        roundVerify++;
                    }
                    
                }
                else if (hero.hp <= 0)
                {
                    Console.WriteLine("Game over!");
                    return battleOutcome = true;
                }
                else
                {
                    //add experience and gold to player and if expmeter is >= full run the levelup method
                    activeFight = false;
                    hero.exp += mob[b].exp;
                    Game.TakeGold(hero, mob[b]);

                    Console.WriteLine($"Victory!\n" +
                                      $"You gained {mob[b].exp} experience\n" +
                                      $"{hero.exp} / {hero.maxExp}\n" +
                                      $"You looted {mob[b].gold} gold");
                    if (hero.exp >= hero.maxExp)
                    {
                        LvlUp(hero);
                    }
                }
                i++;
            }
            return battleOutcome;
        }
        public static void ClassChange(Hero hero)
        {
            //Since the possibility could exist for the player to choose their first class additional class evolutions could be added
            //even if the evolution stages will be fixed following the initial choice.

            //a Warrior evolves into a DeathKnight
            if (hero.className == "Warrior")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("You feel .. different.. more powerful\n" +
                                  "You have accended to the class DeathKnight");
                Console.ResetColor();
                //new class and new modifiers to those stats, higher value with each level up, from 2 -> 4
                hero.className = "DeathKnight";
                hero.strModifier = 4;
                hero.maxHpModifier = 4;
                //what else should be different about the DeathKnight.. necrotic damage added? mob resistance? ability that adds to random if class is deathknight.
                //deathknight could have a frostaura active that damages enemy every turn.
            }

        }
        public static void LvlUp(Hero hero)
        {
            //notes stats before levelup to retrieve the gained amount
            var currStr = hero.str;
            var currMaxHp = hero.maxHp;
            var currDmg = hero.dmg;

            if (hero.exp >= hero.maxExp)
            {
                hero.exp -= hero.maxExp; //resets hero experience after levelup
                hero.lvl = hero.lvl + 1; //adds a level, sufficient when no mob can give a player crazy experience amounts.
                hero.Str = hero.str; //recalculates str since str is leveldependant for its value
                hero.MaxHp = hero.maxHp; //recalculates hero maxhp since it is leveldependent for its value
                hero.MaxExp = hero.maxExp; //recalculates maxExp required for next levelup
                //hero.Dmg = hero.dmg; //recalculates hero damage since it it str dependant
                hero.hp = hero.maxHp; //heals player to full health after levelup

                //gets the added value ontop of old stat value
                currStr = hero.Str - currStr;
                currMaxHp = hero.maxHp - currMaxHp;

                //currDmg = hero.dmg - currDmg; //KOLLA OM SKADAN VERKAR NORMAL ANNARS KAN VI BEHÖVER REFRESHA SKADAN VID LEVEL UPP

                //what did you gain?
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"You reached Level {hero.lvl}\n" +
                                  $"You are now at full health\n" +
                                  $"You gained\n" +
                                  $"Str + {currStr}\n" +
                                  $"Damage + {currDmg}\n" +
                                  $"Maxhp + {currMaxHp}\n");
                Console.ResetColor();

                if (hero.lvl == 5)
                {
                    ClassChange(hero);
                }
            }
        }
        public static int CriticalChance(Hero hero)
        {

            int critChance = 1;
            Random crit = new Random();
            var critical = crit.Next(1, 101);
            if (critical <= hero.crit)
            {
                critChance = 2;
            }
            return critChance;
        }
        public static int BattleChance()
        {
            Random battleChance = new Random();
            var battle = battleChance.Next(1, 101);
            Console.WriteLine($"******ChanceNumber: {battle} ********"); //remove later
            return battle;
        }
        public static int HeroDamage(Hero hero)
        {
            //hero attack , from mindmg to maxdmg , finjustera systemet för dmg
            
            int min = Convert.ToInt32(hero.minDamage);
            int max = Convert.ToInt32(hero.maxDamage); //maybe move to base class. as min and max dmg
            var heroDmg = new Random();
            var heroDamage = heroDmg.Next(min, max);

            return heroDamage;
        }
        static void Continue(Hero hero, List<Monster> mob, int b)
        {

            if (hero.hp >= 0 && mob[b].hp >= 0)
            {
                Console.WriteLine("Press [Enter] to continue");
                while (Console.ReadKey().Key != ConsoleKey.Enter)
                {

                }
            }
        }
    }
}

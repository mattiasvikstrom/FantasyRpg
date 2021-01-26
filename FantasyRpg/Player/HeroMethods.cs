using System;
using System.Collections.Generic;
using FantasyRpg.Enemies;

namespace FantasyRpg.Player
{
    class HeroMethods
    {
        
        //Hero attack Basic, normal and special , they differ in damage and special is a lower chance attack that heals the hero.
        public static float HeroAttackBasic(Hero hero, List<Monster> mob, float heroDamage, int b)
        {
            Console.WriteLine($"{hero.name} attacks head on with {hero.weapon}");
            var critical = CriticalChance(hero);
            if (critical > 1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Critical hit!");
                Console.ResetColor();
            }
            heroDamage *= critical;
            heroDamage -= mob[b].def;
            heroDamage = (int)Math.Round(heroDamage, 0);
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
            heroDamage = (int)Math.Round(heroDamage, 0);
            if (heroDamage < 0)
            {
                heroDamage = 0;
            }
            mob[b].hp -= heroDamage;
            return heroDamage;
        }
        public static float HeroAttackSpecial(Hero hero, List<Monster> mob, float heroDamage, int b)
        {
            
            Console.WriteLine($"{hero.name} rushes {mob[b].name} with unseen ferocity!");
            Console.WriteLine($"{hero.name} uses [Blood Strike]!");
            heroDamage *= 2;
            var critical = CriticalChance(hero);
            Console.ForegroundColor = ConsoleColor.Green;
            if (critical > 1)
            {
                
                Console.WriteLine("Critical hit!");
                
            }
            heroDamage *= critical;
            heroDamage -= mob[b].def;
            
            if (heroDamage < 0)
            {
                heroDamage = 0;
            }
            var bloodStrike = heroDamage * 0.2f;
            bloodStrike = (int)Math.Round(bloodStrike);
            hero.hp += bloodStrike;
            Console.WriteLine($"{hero.name} leeched {bloodStrike} health!");
            if(hero.hp > hero.maxHp)
            {
                var overHeal = hero.hp - hero.maxHp;
                Console.WriteLine($"Overhealed: {(int)Math.Round(overHeal)} health");
                hero.hp = hero.maxHp;
            }

            Console.ResetColor();
            heroDamage = (int)Math.Round(heroDamage);
            mob[b].hp -= heroDamage;
            return heroDamage;
        }
        //Evaluates by random which attack the hero will perform. They have different chance and does different damage multiplier
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
        //controls the fight between hero and oponent
        public static bool Battle(Hero hero)
        {
            Console.Clear();
            bool activeFight = true;
            //Checks for possible fight
            activeFight = BattleChance();

            //generate monster for the battle
            List<Monster> mob = Monster.CreateMonster(hero);
            
            //Get the correct placement of the monster in mob list
            int b = mob.Count - 1;

            //Method call to modify the monster based on players level
            Monster.MonsterAdjustStats(mob, hero, b);

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
                    //Verify which round is active. One round needs both fighters to attack once. when both have attacked once, go to next round counter
                    if (roundVerify % 2 == 0)
                    {
                        roundCounter++;
                    }
                    Continue(hero, mob, b);
                    Console.WriteLine($"BattleRound #{roundCounter}");
                    
                    if (i % 2 == 0)
                    {
                        //Method determens what attackmove hero should make randomly.
                        float heroDamage = HeroDamage(hero);
                        heroDamage = HeroAttackList(hero, mob, heroDamage, b);
                        Console.WriteLine($"{hero.name} does {heroDamage} damage");
                        Console.WriteLine($"{mob[b].name} has hp: {mob[b].hp} left\n");
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

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"**************************************\n" +
                                      $"*            Victory!\n" +
                                      $"*    You gained {mob[b].exp} experience\n" +
                                      $"*            {hero.exp} / {hero.maxExp}\n" +
                                      $"*       You looted {mob[b].gold} gold\n" +
                                      $"**************************************\n");
                    Console.ResetColor();
                    if (hero.exp >= hero.maxExp)
                    {
                        LvlUp(hero);
                    }
                }
                i++;
            }
            return battleOutcome;
        }
        //if criteria is met hero class will be changed, and stat multipliers will be upped x2
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
        //method is called when the hero has met criteria for a level up
        public static void LvlUp(Hero hero)
        {
            //notes stats before levelup to retrieve the gained amount
            var currStr = hero.str;
            var currMaxHp = hero.maxHp;
            

            if (hero.exp >= hero.maxExp)
            {
                hero.exp -= hero.maxExp; //resets hero experience after levelup
                hero.lvl = hero.lvl + 1; //adds a level, sufficient when no mob can give a player crazy experience amounts.
                hero.Str = hero.str; //recalculates str since str is leveldependant for its value
                hero.MaxHp = hero.maxHp; //recalculates hero maxhp since it is leveldependent for its value
                hero.MaxExp = hero.maxExp; //recalculates maxExp required for next levelup
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
                                  $"Maxhp + {currMaxHp}\n");
                Console.ResetColor();

                if (hero.lvl == 5)
                {
                    ClassChange(hero);
                }
            }
        }
        //Evaluates the chance for a critical strike, the chance is dependent on the hero crit stat and chance increases by having higher stat value
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
        //Evaluates chance for a battle to occur
        public static bool BattleChance()
        {
            bool activeFight = true;
            Random battleChance = new Random();
            var battle = battleChance.Next(1, 101);
            Console.WriteLine($"******ChanceNumber: {battle} ********"); //remove later

            if (battle >= 11)
            {
                Console.WriteLine("You encountered an opponent!");
            }
            else
            {
                Console.WriteLine("No danger present.. this time.");
                activeFight = false;
            }
            return activeFight;
        }
        //Evaluates hero damage based on min and max damage of the hero, calls randomAttackDamage() for damage.
        public static int HeroDamage(Hero hero)
        {
            int min = Convert.ToInt32(hero.minDamage);
            int max = Convert.ToInt32(hero.maxDamage);
            var heroDamage = Game.RandomAttackDamage(min, max);

            return heroDamage;
        }
        //Called between Hero and opponent turn and calls for an Return keypress
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
        //updates hero damage when equipping weapons
        public static void Updating(Hero hero)
        {
            hero.WeaponDamage = hero.weaponDamage;
            hero.AttackPower = hero.attackPower;
            hero.MinDamage = hero.minDamage;
            hero.MaxDamage = hero.maxDamage;
        }
    }
}

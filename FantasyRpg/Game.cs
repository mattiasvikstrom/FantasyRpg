using System;
using System.Collections.Generic;
using System.Text;
using FantasyRpg.Shop;
using FantasyRpg.Player;
using FantasyRpg.Enemies;
using FantasyRpg.LocalInn;
using System.Threading;



namespace FantasyRpg
{
    class Game
    {
        public static void Start()
        {
            Console.Title = "Fantasy RPG";
            List<Merchant> startArmor = Armor.StarterArmor();
            Hero hero = CreateHero(startArmor);

            
            List<Merchant> weapon = Weapons.AddWeapon(); //om det blir problem är det säkert kring Weapons och vart listan är placerad.
            List<Merchant> armor = Armor.AddArmor();
            List<Merchant> items = Items.AddItems();

            bool activeGame = false;
            do
            {
                Console.WriteLine("\n**************************************\n" +
                                    "* 1. Go Adventuring\n" +
                                    "* 2. Show details about your character\n" +
                                    "* 3. Rest at the Inn\n" +
                                    "* 4. Visit shop\n" +
                                    "* 5. Exit\n" +
                                    "**************************************\n");
                Console.Write(">> ");
                Console.ForegroundColor = ConsoleColor.Cyan;
                string menuChoice = Console.ReadLine();
                Console.ResetColor();

                switch (menuChoice)
                {
                    case "1": // hero enters battlephase , returns bool which if player dies ends game
                        activeGame = HeroMethods.Battle(hero);
                        break;
                    case "2": //prints Hero stats and current equipment from Tostring in Hero
                        Console.WriteLine(hero);
                        break;
                    case "3": //Allows hero to rest at in in exchange for gold, this heals the player to full health
                        Inn.VisitInn(hero);
                        break;
                    case "4": //Enters shop, where all equipment is located, when purchased items are auto equipped.
                        Merchant.ItemShop(hero, items, armor, weapon, startArmor);
                        break;
                    case "5": // quits game
                        activeGame = true;
                        break;
                    default:
                        break;
                }
                if (hero.lvl >= 10)
                {
                    Console.WriteLine("You are a true hero! You win!");
                    activeGame = true;
                }
            } while (!activeGame);
        }

        public static Hero CreateHero(List<Merchant> startArmor)
        {
            string heroName = Initialize();
            Hero hero = new Hero(heroName);
            
            int ind = 1;
            Console.WriteLine($"\n Greeting {hero.name}, let's get you sorted with some items. It is a harsh world... \n");
            Thread.Sleep(2000);
            foreach (var item in startArmor)
            {
                Merchant.AddAttributes(startArmor, hero, ind);
                ind++;
            }

            hero.helmet = "Iron cap";
            hero.shoulder = "Plated shoulderpads";
            hero.chestArmor = "Iron Chestplate";
            hero.gloves = "Defenders gauntlets";
            hero.legs = "Iron leggings";
            hero.boots = "Steel boots";
            hero.weapon = "Short sword";
            hero.AttackPower = hero.AttackPower;
            hero.MinDamage = hero.MinDamage;
            hero.MaxDamage = hero.MaxDamage;
            
            Console.WriteLine("There we are. you probably noticed getting a bit stronger there. Good luck!");


            return hero;
        }

        public static string Initialize()
        {
            Console.WriteLine("Welcome to Fantasy RPG!\n" +
                              "Enter hero name:\n");
            Console.Write(">> ");
            Console.ForegroundColor = ConsoleColor.Green;
            string heroName = Console.ReadLine();
            Console.ResetColor();
            return heroName;
        }
        public static int RandomAttackDamage(int minDamage, int maxDamage)
        {
            var rand = new Random();
            var ran = rand.Next(minDamage, maxDamage);
             
            return ran;
        }
        public static void TakeGold(Hero hero, Monster mob)
        {
            hero.gold += mob.gold;
        }
    }
}

using System;
using System.Collections.Generic;
using FantasyRpg.Shop;
using FantasyRpg.Player;
using FantasyRpg.Enemies;
using FantasyRpg.LocalInn;
using System.Threading;



namespace FantasyRpg
{
    static class Game
    {
        public static void Start()
        {
            Console.Title = "Fantasy RPG";
            List<Merchant> equipment = Armor.StarterArmor();
            List<Merchant> weapon = Weapons.AddWeapon();
            List<Merchant> armor = Armor.AddArmor();
            List<Merchant> items = Items.AddItems();
            List<Merchant> food = Inn.AddFood();
            Hero hero = CreateHero(equipment, armor);

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
                    case "1": // hero enters battle phase , returns boolean which if player dies ends game
                        activeGame = HeroMethods.Battle(hero);
                        break;
                    case "2": //prints Hero stats and current equipment from ToString in Hero
                        Console.WriteLine(hero);
                        break;
                    case "3": //Allows hero to rest at in exchange for gold, this heals the player to full health
                        Inn.VisitInn(hero, food);
                        break;
                    case "4": //Enters shop, where all equipment is located, when purchased items are auto equipped.
                        Merchant.ItemShop(hero, items, armor, weapon, equipment);
                        break;
                    case "5": // quits game
                        activeGame = true;
                        break;
                }
                if (hero.lvl >= 10)
                {
                    Console.WriteLine("You are a true hero! You win!");
                    activeGame = true;
                }
            } while (!activeGame);
        }
        //Method handles taking the name and creating the hero, adds and assigns gear to hero
        public static Hero CreateHero(List<Merchant> equipment, List<Merchant> armor)
        {
            string heroName = Initialize();
            Hero hero = new Hero(heroName);
            int ind = 1;
            Console.WriteLine($"\n Greeting {hero.name}, let's get you sorted with some items. It is a harsh world... \n");
            Thread.Sleep(2000);
            foreach (var item in equipment)
            {
                Merchant.AddAttributes(equipment, hero, ind);
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
            Console.Clear();
            GodMode(hero, armor, heroName);
            Console.WriteLine("There we are. you probably noticed getting a bit stronger there. Good luck!");

            HeroMethods.Updating(hero);
            return hero;
        }
        //Takes in the hero name and returns it
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
        //Handles Monsters random attack damage ...... change location and use same for hero and monsters accordingly...
        public static int RandomAttackDamage(int minDamage, int maxDamage)
        {
            var rand = new Random();
            var ran = rand.Next(minDamage, maxDamage);
            return ran;
        }
        //If the hero is victorious the hero is granted the current monsters gold
        public static void TakeGold(Hero hero, Monster mob)
        {
            hero.gold += mob.gold;
        }
        //Method for players who find it a bit too challenging!! adds a new item also to the armor shop
        public static void GodMode(Hero hero, List<Merchant> armor, string heroName)
        {
            if (heroName == "Robin" || heroName == "Isshin")
            {
                hero.str += 100;
                hero.maxHp += 9999;
                hero.hp = hero.maxHp;
                hero.attackPower += 666;
                hero.gold += 9999999;
                hero.def += 100;

                armor.Add(new Merchant
                {
                    name = "Godly chestplate",
                    itemType = "chestplate",
                    gold = 2500,
                    def = 2500,
                    str = 2000,
                    maxHp = 8000,
                });
            }
        }
    }
}

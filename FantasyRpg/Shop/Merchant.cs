using System;
using System.Collections.Generic;
using System.Linq;
using FantasyRpg.Player;

namespace FantasyRpg.Shop
{
    class Merchant : Hero
    {
        public string itemType;
        public int itemId;
        

        public Merchant()
        {

        }
        public static void ItemShop(Hero hero, List<Merchant> items, List<Merchant> armor, List<Merchant> weapon, List<Merchant> equipment)
        {
            Console.Clear();
            Console.WriteLine("*******************************\n" +
                              "* Welcome to the item shop!\n" +
                              "* What do you want to buy?\n" +
                             $"* You have {hero.gold} gold.\n" +
                              "*******************************\n" +
                             $"[1]. Items\n" +
                             $"[2]. Armor\n" +
                             $"[3]. Weapons\n" +
                             $"[Q]. Back\n" +
                             $"*******************************");
            Console.Write(">>");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string input = Console.ReadLine(); //Validation. ha menyn i loop och menyval för exit shop?
            Console.ResetColor();
            switch (input)
            {
                case "1":
                    ListItems(items, equipment, hero);
                    ValidatePurchase(hero, items, equipment);
                    break;
                case "2":
                    ListItems(armor, equipment, hero);
                    ValidatePurchase(hero, armor, equipment);
                    break;
                case "3":
                    ListItems(weapon, equipment, hero);
                    ValidatePurchase(hero, weapon, equipment);
                    break;
                default:
                    break;
            }
        }
        private static string ValidatePurchase(Hero hero, List<Merchant> itemsx, List<Merchant> equipment) //bättre namngivning på itemsx för generell lista.
        {
            string input;
            int intInput;
            Console.WriteLine("Enter number of item to buy, " +
                              " and press [Q] to exit shop\n" +
                              ">>" );
            input = Console.ReadLine();
            do
            {
                if (Int32.TryParse(input, out intInput) && intInput <= itemsx.Count && intInput > 0)
                {
                    if (hero.gold >= itemsx[intInput - 1].gold)
                    {
                        BuyItem(itemsx, equipment, hero, intInput);
                        hero.gold -= itemsx[intInput - 1].gold;
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough gold to purchase this");
                    }
                }
                else
                {
                    Console.WriteLine("You did not select a valid choice");
                }
                
            } while (Console.ReadKey().Key != ConsoleKey.Q);
            
            return input;
        }
        public static void BuyItem(List<Merchant> itemsx, List<Merchant> equipment, Hero hero, int intInput)
        {
            //which item to equip
            var itemType = itemsx[intInput - 1].itemType;
             //TEST VARIABLE

            //All "equippment slots" so that they can be tracked. This definition is also carried on to compare which item is currently in that itemslot
            //because we need to remove it and its added attributes to our hero. Only applied to equipment rather than items(permanent buffs) in the shop

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            switch (itemType)
            {
                case "helmet":
                    ItemEquip(itemsx, equipment, hero, intInput, itemType);
                    hero.helmet = itemsx[intInput - 1].name;
                    break;
                case "shoulder":
                    ItemEquip(itemsx, equipment, hero, intInput, itemType);
                    hero.shoulder = itemsx[intInput - 1].name;
                    break;
                case "chestplate":
                    ItemEquip(itemsx, equipment, hero, intInput, itemType);
                    hero.chestArmor = itemsx[intInput - 1].name;
                    break;
                case "gloves":
                    ItemEquip(itemsx, equipment, hero, intInput, itemType);
                    hero.gloves = itemsx[intInput - 1].name;
                    break;
                case "legs":
                    ItemEquip(itemsx, equipment, hero, intInput, itemType);
                    hero.legs = itemsx[intInput - 1].name;
                    break;
                case "boots":
                    ItemEquip(itemsx, equipment, hero, intInput, itemType);
                    hero.boots = itemsx[intInput - 1].name;
                    break;
                case "weapon":
                    ItemEquip(itemsx, equipment, hero, intInput, itemType);
                    hero.weapon = itemsx[intInput - 1].name;
                    break;
            }
            Console.ResetColor();
            //string input = Console.ReadLine();
            //if the item purchaced has more than 0 in the possible stats avaliable for items then it will be added from the chosen item.
            //leaves me to be able to only add new items and not having to worry about anything else for the shop part!
            //since an item can have multiple stats on it this functions well. 

            //Add counter per item? how many do you own of each? seperate list that you could. sell from?or just display in character stats.
            //work with logic for stats that have a max cap

            //adds attributes from item to player when item is equiped
            AddAttributes(itemsx, hero, intInput);
            HeroMethods.Updating(hero);
        }

        private static int ItemEquip(List<Merchant> itemsx, List<Merchant> equipment, Hero hero, int intInput, string itemType)
        {
            var removeItem = 0;
            if (equipment.Any(s => s.itemType.Contains(itemType))) //verkar fungera, se om det kan bli metod för alla möjligheter..
            {
                removeItem = equipment.FindIndex(item => item.itemType == itemType);
                Console.WriteLine($"Unequipped {equipment[removeItem].name}");
                RemoveAttributes(equipment, hero, removeItem, itemType);
                equipment.RemoveAt(removeItem);
            }
            equipment.Add(itemsx[intInput - 1]);

            Console.WriteLine($"You equipped {itemsx[intInput - 1].name}");
            return removeItem;
        }

        private static void RemoveAttributes(List<Merchant> equipment, Hero hero, int intInput, string itemType)
        {
            //compares what the hero is currently wearing. Since the equipped item has a string we referens it below to locate the items position in the list
            //which allows us to remove its attributes from the hero when item is removed.
            //var test = intInput;
            
            if (equipment[intInput].def != 0)
            {
                hero.def -= equipment[intInput].def;
                Console.WriteLine($"Removed {equipment[intInput].def} def");
            }
            if (equipment[intInput].str != 0)
            {
                hero.str -= equipment[intInput].str;
                Console.WriteLine($"Removed {equipment[intInput].str} str");
            }
            if (equipment[intInput].crit != 0)
            {
                hero.crit -= equipment[intInput].crit;
                Console.WriteLine($"Removed {equipment[intInput].crit} crit");
            }
            if (equipment[intInput].dmg != 0)
            {
                hero.dmg -= equipment[intInput].dmg;
                Console.WriteLine($"Removed {equipment[intInput].dmg} damage");
            }
            if (equipment[intInput].weaponDamage != 0)
            {
                hero.weaponDamage -= equipment[intInput].weaponDamage;
                Console.WriteLine($"Removed {equipment[intInput].weaponDamage} damage");
            }
            if (equipment[intInput].attackPower != 0)
            {
                hero.attackPower -= equipment[intInput].attackPower;
                Console.WriteLine($"Removed {equipment[intInput].attackPower} attackpower");
            }
        }

        public static void AddAttributes(List<Merchant> items, Hero hero, int intInput)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            if (items[intInput - 1].def != 0)
            {
                hero.def += items[intInput - 1].def;
                Console.WriteLine($"added {items[intInput - 1].def} def");
            }
            if (items[intInput - 1].str != 0)
            {
                hero.str += items[intInput - 1].str;
                Console.WriteLine($"added {items[intInput - 1].str} str");
            }
            if (items[intInput - 1].dmg != 0)
            {
                hero.dmg += items[intInput - 1].dmg;
                Console.WriteLine($"added {items[intInput - 1].dmg} damage");
            }
            if (items[intInput - 1].weaponDamage != 0)
            {
                hero.weaponDamage = items[intInput - 1].weaponDamage;
                Console.WriteLine($"added {items[intInput - 1].weaponDamage} weapon damage");
            }
            if (items[intInput - 1].attackPower != 0)
            {
                hero.attackPower = items[intInput - 1].attackPower;
                Console.WriteLine($"added {items[intInput - 1].attackPower} attackpower");
            }
            if (items[intInput - 1].crit != 0)
            {
                hero.crit += items[intInput - 1].crit;
                Console.WriteLine($"added {items[intInput - 1].crit} crit");
                if (hero.crit >= 75)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have reached the cap for crit, any stat above cap will not aid");
                    Console.ResetColor();
                }
            }
            Console.ResetColor();
        }
        public static void ListItems(List<Merchant> items, List<Merchant> equipment, Hero hero)
        {
            int i = 1;
            int j = 0;
            Console.Write("Color explanation: ");
            Console.ForegroundColor = ConsoleColor.Green; Console.Write($"[IMPROVEMENT] "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write($"[NO CHANGE] "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red; Console.Write($"[DOWNGRADE] \n"); Console.ResetColor();
            foreach (var item in items)
            {
                Console.Write($"{i++}. || {items[j].itemType} || {items[j].name} Cost: {items[j].gold} gold");
                //if item in list is on the player, its noted as equipped after its listing
                if (items[j].name == hero.helmet || items[j].name == hero.shoulder || items[j].name == hero.chestArmor || items[j].name == hero.gloves || items[j].name == hero.legs || items[j].name == hero.boots || items[j].name == hero.weapon)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" - Equipped");
                    Console.ResetColor();
                }
                
                int itermId = 0;
                if (equipment.Any(s => s.itemType.Equals(items[j].itemType)))
                {
                    foreach (var itemId in equipment)
                    {
                        if (itemId.itemType == items[j].itemType)
                        {
                            itermId = itemId.itemId;
                        }
                    }
                    //Compares to get the correct item and its values to below display which change the player will get with each item.
                    Console.Write("\nChange if bought: ");
                    var myItem = equipment.FindIndex(equip => equip.itemId == itermId);
                    if (equipment[myItem].weaponDamage != 0 || items[j].weaponDamage != 0)
                    {
                        var stat = items[j].weaponDamage - equipment[myItem].weaponDamage;
                        Console.Write($" Weapon damage: ");
                        stat = ColorOfGain(Convert.ToInt32(stat));
                        Console.Write($"{stat}");
                        Console.ResetColor();
                    }
                    if (equipment[myItem].attackPower != 0 || items[j].attackPower != 0)
                    {
                        var stat = items[j].attackPower - equipment[myItem].attackPower;
                        Console.Write($" Attackpower: ");
                        stat = ColorOfGain(Convert.ToInt32(stat));
                        Console.Write($"{stat}");
                        Console.ResetColor();
                    }
                    if (equipment[myItem].str != 0 || items[j].str != 0)
                    {
                        var stat = items[j].str - equipment[myItem].str;
                        Console.Write($" Strength: ");
                        stat = ColorOfGain(Convert.ToInt32(stat));
                        Console.Write($"{stat}");
                        Console.ResetColor();
                    }
                    if (equipment[myItem].def != 0 || items[j].def != 0)
                    {
                        var stat = items[j].def - equipment[myItem].def;
                        Console.Write($" Defense: ");
                        stat = ColorOfGain(Convert.ToInt32(stat));
                        Console.Write($"{stat}");
                        Console.ResetColor();
                    }
                    if (equipment[myItem].maxHp != 0 || items[j].maxHp != 0)
                    {
                        var stat = items[j].maxHp - equipment[myItem].maxHp;
                        Console.Write($" Max Health: ");
                        stat = ColorOfGain(Convert.ToInt32(stat));
                        Console.Write($"{stat}");
                        Console.ResetColor();
                    }
                    if (equipment[myItem].crit != 0 || items[j].crit != 0)
                    {
                        var stat = items[j].crit - equipment[myItem].crit;
                        Console.Write($" Critical: ");
                        stat = ColorOfGain(Convert.ToInt32(stat));
                        Console.Write($"{stat}");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine("\n");
                j++;
            }
        }
        //Depending on value the color of the text will change for the attribute.
        private static int ColorOfGain(int stat)
        {
            if (stat < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            else if (stat > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            return stat;
        }
    }
}

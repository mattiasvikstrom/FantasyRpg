using System;
using System.Collections.Generic;
using System.Linq;
using FantasyRpg.Player;
using FantasyRpg.LocalInn;

namespace FantasyRpg.Shop
{
    class Merchant : Hero
    {
        public string itemType;
        public int itemId;

        public Merchant()
        {
        }
        //Main menu in the shop
        public static void ItemShop(Hero hero, List<Merchant> items, List<Merchant> armor, List<Merchant> weapon, List<Merchant> equipment)
        {
            Console.Clear();
            string input;
            bool inMenu = false;
            do
            {
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
                input = Console.ReadLine();
                Console.ResetColor();
                switch (input)
                {
                    case "1":
                        Inn.ListEnhancements(items);
                        inMenu = ValidatePurchase(hero, items, equipment);
                        break;
                    case "2":
                        ListItems(armor, equipment, hero);
                        inMenu = ValidatePurchase(hero, armor, equipment);
                        break;
                    case "3":
                        ListItems(weapon, equipment, hero);
                        inMenu = ValidatePurchase(hero, weapon, equipment);
                        break;
                    case "Q":
                        inMenu = false;
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        break;
                }
            } while (inMenu);
        }
        //Evaluates if the input is a valid item and if the hero can actually afford to purchase it, or if the user chooses to exit the shop
        //otherwise proceeds with the purchase
        private static bool ValidatePurchase(Hero hero, List<Merchant> itemsx, List<Merchant> equipment)
        {
            bool inMenu = false;

                string input;
                int intInput;
                Console.Write("\nEnter number of the item you want buy, \n" +
                              "and press [Q] to exit shop\n" +
                              ">>");
                Console.ForegroundColor = ConsoleColor.Cyan;
                input = Console.ReadLine();
                Console.ResetColor();
                if (Int32.TryParse(input, out intInput) && intInput <= itemsx.Count && intInput > 0)
                {
                    if (hero.gold >= itemsx[intInput - 1].gold)
                    {
                        BuyItem(itemsx, equipment, hero, intInput);
                        hero.gold -= itemsx[intInput - 1].gold;
                        inMenu = true;
                    }
                    else
                    {
                        Console.WriteLine("You do not have enough gold to purchase this");
                    }
                }
                if (Int32.TryParse(input, out intInput) && intInput > itemsx.Count)
                {
                Console.WriteLine("Invalid input option");
                }
                else if (input == "q" || input == "Q")
                {
                    inMenu = true;
                }

                return inMenu;
        }
        //After validation of the purchase the item itemType is referenced and located in the switch statement. It calls for the ItemEquip method and also then
        //updates what the hero is currently wearing.
        public static void BuyItem(List<Merchant> itemsx, List<Merchant> equipment, Hero hero, int intInput)
        {
            //which item to equip
            var itemType = itemsx[intInput - 1].itemType;
            //All "equipment slots" so that they can be tracked. This definition is also carried on to compare which item is currently in that item slot
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
            

            //adds attributes from item to player when item is equipped
            AddAttributes(itemsx, hero, intInput);
            HeroMethods.Updating(hero);
        }
        //Locates the currently equipped items location in its list, and calls for RemoveAttributes method to remove attributes gained by the item.
        //When it is done the new item is added to equipment list, what the hero is currently wearing
        private static int ItemEquip(List<Merchant> itemsx, List<Merchant> equipment, Hero hero, int intInput, string itemType)
        {
            var removeItem = 0;
            if (equipment.Any(s => s.itemType.Contains(itemType)))
            {
                removeItem = equipment.FindIndex(item => item.itemType == itemType);
                Console.WriteLine($"Unequipped {equipment[removeItem].name}");
                RemoveAttributes(equipment, hero, removeItem, itemType);
                equipment.RemoveAt(removeItem);
            }
            Console.ResetColor();
            equipment.Add(itemsx[intInput - 1]);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"You equipped {itemsx[intInput - 1].name}");
            Console.ResetColor();
            return removeItem;
        }
        //compares what the hero is currently wearing. Since the equipped item has a string we reference it below to locate the items position in the list
        //which allows us to remove its attributes from the hero when item is removed.
        private static void RemoveAttributes(List<Merchant> equipment, Hero hero, int intInput, string itemType)
        {
            if (equipment[intInput].def != 0)
            {
                hero.def -= equipment[intInput].def;
                Console.WriteLine($"Removed {equipment[intInput].def} defense");
            }
            if (equipment[intInput].str != 0)
            {
                hero.str -= equipment[intInput].str;
                Console.WriteLine($"Removed {equipment[intInput].str} strength");
            }
            if (equipment[intInput].crit != 0)
            {
                hero.crit -= equipment[intInput].crit;
                Console.WriteLine($"Removed {equipment[intInput].crit} critical");
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
                Console.WriteLine($"Removed {equipment[intInput].attackPower} attack power");
            }
            
        }
        //Evaluates stats on purchased item/equipment and adds it to hero
        public static void AddAttributes(List<Merchant> items, Hero hero, int intInput)
        {
            //if the item purchased has more than 0 in the possible stats available for items then it will be added from the chosen item.
            //leaves me to be able to only add new items and not having to worry about anything else for the shop part!
            //since an item can have multiple stats on it. 
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
            if (items[intInput - 1].hp != 0)
            {
                if (hero.hp + items[intInput - 1].hp < hero.MaxHp)
                {
                    hero.hp += items[intInput - 1].hp;
                    Console.WriteLine($"Healed {items[intInput - 1].hp} Health");
                    Console.WriteLine($"{hero.hp} / {hero.MaxHp}");
                }
                else
                {
                    hero.hp = hero.MaxHp;
                    Console.WriteLine($"You are back to full health!");
                }
                
            }
            Console.ResetColor();
            
        }
        //Method presents Armor and Weapons, compares heroes current gear and displays basic information and also what will be gained/lose or unchanged by
        //getting an armor/weapon. 
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
                //if an item in the list is equipped the player, its noted as equipped after its listing
                if (items[j].name == hero.helmet || items[j].name == hero.shoulder || items[j].name == hero.chestArmor || items[j].name == hero.gloves || items[j].name == hero.legs || items[j].name == hero.boots || items[j].name == hero.weapon)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" - Equipped");
                    Console.ResetColor();
                }
                int itermId = 0;
                if (equipment.Any(s => s.itemType.Equals(items[j].itemType)))
                {
                    //locate the type of equipment type ex "helmet" "weapon". 
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
                        Console.Write($" Attack power: ");
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
        //Depending on value the color of the text will change for the attribute. positive = green, negative = red, unchanged = yellow
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

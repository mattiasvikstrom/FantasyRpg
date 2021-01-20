﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FantasyRpg.Player;

namespace FantasyRpg.Shop
{
    class Merchant : Hero
    {
        public string itemType;

        public Merchant()
        {

        }
        public static void ItemShop(Hero hero, List<Merchant> items, List<Merchant> armor, List<Merchant> weapon, List<Merchant> startArmor)
        {

            Console.Clear();
            Console.WriteLine("*******************************\n" +
                              "* Welcome to the item shop!\n" +
                              "* What do you want to buy?\n" +
                             $"* You have {hero.gold} gold.\n" +
                              "*******************************\n" +
                             $"1. Items\n" +
                             $"2. Armor\n" +
                             $"3. Weapons\n" +
                             $"******************************");
            Console.Write(">>");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string input = Console.ReadLine(); //Validation. ha menyn i loop och menyval för exit shop?
            Console.ResetColor();
            switch (input)
            {
                case "1":
                    ListItems(items, hero);
                    ValidatePurchase(hero, items, startArmor);
                    break;
                case "2":
                    ListItems(armor, hero);

                    ValidatePurchase(hero, armor, startArmor);
                    break;
                case "3":
                    ListItems(weapon, hero);
                    ValidatePurchase(hero, weapon, startArmor);
                    break;
                default:
                    break;
            }
        }
        private static string ValidatePurchase(Hero hero, List<Merchant> itemsx, List<Merchant> startArmor) //bättre namngivning på itemsx för generell lista.
        {
            string input;
            int intInput;
            input = Console.ReadLine();

            if (Int32.TryParse(input, out intInput) && intInput <= itemsx.Count && intInput > 0)
            {
                if (hero.gold >= itemsx[intInput - 1].gold)
                {
                    Merchant.BuyItem(itemsx, startArmor, hero, intInput);
                    hero.gold -= itemsx[intInput - 1].gold;
                }
                else
                {
                    Console.WriteLine("You do not have enough gold to purchase this");
                }
            }
            return input;
        }
        public static void BuyItem(List<Merchant> itemsx, List<Merchant> startArmor, Hero hero, int intInput)
        {
            //which item to equip
            var itemType = itemsx[intInput - 1].itemType;

            //vilken item är equipped innan jag tar på mig den nya........
            //var itemId = itemsx[intInput - 1].itemId;
            //int index = items.FindIndex(a => a.itemId == itemId);

            //All "equippment slots" so that they can be tracked. This definition is also carried on to compare which item is currently in that itemslot
            //because we need to remove it and its added attributes to our hero. Only applied to equipment rather than items(permanent buffs) in the shop

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            switch (itemType)
            {
                case "helmet":
                    itemType = hero.helmet;
                    RemoveAttributes(itemsx, startArmor, hero, intInput, itemType);
                    hero.helmet = itemsx[intInput - 1].name;
                    Console.WriteLine($"You equipped {itemsx[intInput - 1].name}");
                    break;
                case "shoulder":
                    itemType = hero.shoulder;
                    RemoveAttributes(itemsx, startArmor, hero, intInput, itemType);
                    Console.WriteLine($"Unequipped {hero.shoulder}");
                    hero.shoulder = itemsx[intInput - 1].name;
                    Console.WriteLine($"You equipped {itemsx[intInput - 1].name}");
                    break;
                case "chestplate":
                    itemType = hero.chestArmor;
                    RemoveAttributes(itemsx, startArmor, hero, intInput, itemType);
                    Console.WriteLine($"Unequipped {hero.chestArmor}");
                    hero.chestArmor = itemsx[intInput - 1].name;
                    Console.WriteLine($"You equipped {itemsx[intInput - 1].name}");
                    break;
                case "gloves":
                    itemType = hero.gloves;
                    RemoveAttributes(itemsx, startArmor, hero, intInput, itemType);
                    Console.WriteLine($"Unequipped {hero.gloves}");
                    hero.gloves = itemsx[intInput - 1].name;
                    Console.WriteLine($"You equipped {itemsx[intInput - 1].name}");
                    break;
                case "legs":
                    itemType = hero.legs;
                    RemoveAttributes(itemsx, startArmor, hero, intInput, itemType);
                    Console.WriteLine($"Unequipped {hero.legs}");
                    hero.legs = itemsx[intInput - 1].name;
                    Console.WriteLine($"You equipped {itemsx[intInput - 1].name}");
                    break;
                case "boots":
                    itemType = hero.boots;
                    RemoveAttributes(itemsx, startArmor, hero, intInput, itemType);
                    Console.WriteLine($"Unequipped {hero.boots}");
                    hero.boots = itemsx[intInput - 1].name;
                    Console.WriteLine($"You equipped {itemsx[intInput - 1].name}");
                    break;
                case "weapon":
                    itemType = hero.weapon;
                    RemoveAttributes(itemsx, startArmor, hero, intInput, itemType);
                    Console.WriteLine($"Unequipped {hero.weapon}");
                    hero.weapon = itemsx[intInput - 1].name;
                    Console.WriteLine($"You equipped {itemsx[intInput - 1].name}");
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
        }
        private static void RemoveAttributes(List<Merchant> itemsx, List<Merchant> startArmor, Hero hero, int intInput, string itemType)
        {
            //compares what the hero is currently wearing. Since the equipped item has a string we referens it below to locate the items position in the list
            //which allows us to remove its attributes from the hero when item is removed.

            //with the new addition of. startArmor ... this statement first checks for the itemtype in startArmor, if it matches it will switch list
            if (startArmor.Any(s => s.name.Contains(itemType)))
            {
                itemsx = startArmor;
                intInput = startArmor.FindIndex(item => item.name == itemType);
            }

            if (itemsx[intInput].def != 0)
            {
                hero.def -= itemsx[intInput].def;
                Console.WriteLine($"Removed {itemsx[intInput].def} def");
            }
            if (itemsx[intInput].str != 0)
            {
                hero.str -= itemsx[intInput].str;
                Console.WriteLine($"Removed {itemsx[intInput].str} str");
            }
            if (itemsx[intInput].crit != 0)
            {
                hero.crit -= itemsx[intInput].crit;
                Console.WriteLine($"Removed {itemsx[intInput].crit} crit");

            }
            if (itemsx[intInput].dmg != 0)
            {
                hero.dmg -= itemsx[intInput].dmg;
                Console.WriteLine($"Removed {itemsx[intInput].dmg} damage");

            }
            if (itemsx[intInput].block != 0)
            {
                hero.block -= itemsx[intInput].block;
                Console.WriteLine($"Removed {itemsx[intInput].block} block");

            }
            if (itemsx[intInput].weaponDamage != 0)
            {
                hero.weaponDamage -= itemsx[intInput].weaponDamage;
                Console.WriteLine($"Removed {itemsx[intInput].weaponDamage} damage");

            }
            else
            {
                Console.WriteLine("no attributes were lost");
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
            if (items[intInput - 1].block != 0)
            {
                hero.block += items[intInput - 1].block;
                Console.WriteLine($"added {items[intInput - 1].block} block");
                if (hero.block >= 75)
                {
                    Console.ResetColor();
                    Console.WriteLine("You have reached the cap for block, any stat above cap will not aid");
                }
            }
            Console.ResetColor();
        }
        public static void ListItems(List<Merchant> items, Hero hero)
        {
            //hero equipped items reference for comparision
            string helm = hero.helmet;
            string shoulder = hero.shoulder;
            string chest = hero.chestArmor;
            string gloves = hero.gloves;
            string legs = hero.legs;
            string boots = hero.boots;
            string weapon = hero.weapon;


            int i = 1;
            int j = 0;
            foreach (var item in items)
            {

                Console.Write($"{i++}. Itemtype: {items[j].itemType}: {items[j].name} Cost: {items[j].gold} gold");
                //if item in list is on the player, its noted as equipped after its listing
                if (items[j].name == helm || items[j].name == shoulder || items[j].name == chest || items[j].name == gloves || items[j].name == legs || items[j].name == boots || items[j].name == weapon)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" - Equipped");
                    Console.ResetColor();
                }
                Console.WriteLine();
                j++;
            }
        }
    }
}

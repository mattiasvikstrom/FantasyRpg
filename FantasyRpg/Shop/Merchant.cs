using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Console.WriteLine("Enter number of item to buy" +
                              "[Q] to exit shop" +
                              ">>" );
            input = Console.ReadLine();

            if (Int32.TryParse(input, out intInput) && intInput <= itemsx.Count && intInput > 0)
            {
                if (hero.gold >= itemsx[intInput - 1].gold)
                {
                    Merchant.BuyItem(itemsx, equipment, hero, intInput);
                    hero.gold -= itemsx[intInput - 1].gold;
                }
                else
                {
                    Console.WriteLine("You do not have enough gold to purchase this");
                }
            }
            return input;
        }
        public static void BuyItem(List<Merchant> itemsx, List<Merchant> equipment, Hero hero, int intInput)
        {
            //which item to equip
            var itemType = itemsx[intInput - 1].itemType;
            var removeItem = 0; //TEST VARIABLE

            //List<Merchant> testList = new List<Merchant>();
            //vilken item är equipped innan jag tar på mig den nya........
            //var itemId = itemsx[intInput - 1].itemId;
            //int index = items.FindIndex(a => a.itemId == itemId);

            //All "equippment slots" so that they can be tracked. This definition is also carried on to compare which item is currently in that itemslot
            //because we need to remove it and its added attributes to our hero. Only applied to equipment rather than items(permanent buffs) in the shop

            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            switch (itemType)
            {
                case "helmet":
                    if (equipment.Any(s => s.itemType.Contains("helmet"))) //verkar fungera
                    {
                        removeItem = equipment.FindIndex(item => item.itemType == "helmet");
                        Console.WriteLine("testar ta bort item.....");
                        RemoveAttributes(equipment, hero, removeItem, itemType);
                    }
                    equipment.Add(itemsx[intInput - 1]); //test...
                    itemType = hero.helmet;

                    Console.WriteLine($"Unequipped {hero.helmet}");
                    hero.helmet = itemsx[intInput - 1].name;
                    Console.WriteLine($"You equipped {itemsx[intInput - 1].name}");
                    break;
                //case "helmet":
                //    testList.Add(itemsx[intInput - 1]); //test...
                //    itemType = hero.helmet;
                //    RemoveAttributes(itemsx, startArmor, hero, intInput, itemType);
                //    hero.helmet = itemsx[intInput - 1].name;
                //    Console.WriteLine($"You equipped {itemsx[intInput - 1].name}");
                //    break;
                case "shoulder":
                    if (equipment.Any(s => s.itemType.Contains("shoulder"))) //verkar fungera
                    {
                        removeItem = equipment.FindIndex(item => item.itemType == "shoulder");
                        Console.WriteLine("testar ta bort item.....");
                        RemoveAttributes(equipment, hero, removeItem, itemType);
                    }
                    itemType = hero.shoulder;
                    
                    Console.WriteLine($"Unequipped {hero.shoulder}");
                    hero.shoulder = itemsx[intInput - 1].name;
                    equipment.Add(itemsx[intInput - 1]);
                    Console.WriteLine($"You equipped {itemsx[intInput - 1].name}");
                    break;
                case "chestplate":
                    if (equipment.Any(s => s.itemType.Contains("chestplate"))) //verkar fungera
                    {
                        removeItem = equipment.FindIndex(item => item.itemType == "chestplate");
                        Console.WriteLine("testar ta bort item.....");
                        RemoveAttributes(equipment, hero, removeItem, itemType);
                    }
                    itemType = hero.chestArmor;
                    Console.WriteLine($"Unequipped {hero.chestArmor}");
                    hero.chestArmor = itemsx[intInput - 1].name;
                    equipment.Add(itemsx[intInput - 1]);
                    Console.WriteLine($"You equipped {itemsx[intInput - 1].name}");
                    break;
                case "gloves":
                    if (equipment.Any(s => s.itemType.Contains("gloves"))) //verkar fungera
                    {
                        removeItem = equipment.FindIndex(item => item.itemType == "gloves");
                        Console.WriteLine("testar ta bort item.....");
                        RemoveAttributes(equipment, hero, removeItem, itemType);
                    }
                    itemType = hero.gloves;
                    Console.WriteLine($"Unequipped {hero.gloves}");
                    hero.gloves = itemsx[intInput - 1].name;
                    equipment.Add(itemsx[intInput - 1]);
                    Console.WriteLine($"You equipped {itemsx[intInput - 1].name}");
                    break;
                case "legs":
                    if (equipment.Any(s => s.itemType.Contains("legs"))) //verkar fungera
                    {
                        removeItem = equipment.FindIndex(item => item.itemType == "legs");
                        Console.WriteLine("testar ta bort item.....");
                        RemoveAttributes(equipment, hero, removeItem, itemType);
                    }
                    itemType = hero.legs;
                    Console.WriteLine($"Unequipped {hero.legs}");
                    hero.legs = itemsx[intInput - 1].name;
                    equipment.Add(itemsx[intInput - 1]);
                    Console.WriteLine($"You equipped {itemsx[intInput - 1].name}");
                    break;
                case "boots":
                    if (equipment.Any(s => s.itemType.Contains("boots"))) //verkar fungera
                    {
                        removeItem = equipment.FindIndex(item => item.itemType == "boots");
                        Console.WriteLine("testar ta bort item.....");
                        RemoveAttributes(equipment, hero, removeItem, itemType);
                    }
                    itemType = hero.boots;
                    Console.WriteLine($"Unequipped {hero.boots}");
                    //hero.boots = itemsx[intInput - 1].name;
                    equipment.Add(itemsx[intInput - 1]);
                    Console.WriteLine($"You equipped {itemsx[intInput - 1].name}");
                    break;
                case "weapon":
                    if (equipment.Any(s => s.itemType.Contains("weapon"))) //verkar fungera
                    {
                        removeItem = equipment.FindIndex(item => item.itemType == "weapon");
                        Console.WriteLine("testar ta bort item.....");
                        RemoveAttributes(equipment, hero, removeItem, itemType);
                    }
                    itemType = hero.weapon;
                    Console.WriteLine($"Unequipped {hero.weapon}");
                    hero.weapon = itemsx[intInput - 1].name;
                    equipment.Add(itemsx[intInput - 1]);
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
            HeroMethods.Updating(hero);
        }
        private static void RemoveAttributes(List<Merchant> equipment, Hero hero, int intInput, string itemType)
        {
            //compares what the hero is currently wearing. Since the equipped item has a string we referens it below to locate the items position in the list
            //which allows us to remove its attributes from the hero when item is removed.
            var test = intInput;
            //with the new addition of. startArmor ... this statement first checks for the itemtype in startArmor, if it matches it will switch list
            
            //TEMPORÄRT UTKOMMENTERAT------------------------------------------------------------------------
            //if (startArmor.Any(s => s.name.Contains(itemType)))
            //{
            //    itemsx = startArmor;
            //    intInput = startArmor.FindIndex(item => item.name == itemType);
            //}
            //else if (itemsx.Any(s => s.name.Contains(itemType)))
            //{
            //    intInput = itemsx.FindIndex(item => item.name == itemType);
            //}
            

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
            //hero equipped items reference for comparision
            string helm = hero.helmet;
            string shoulder = hero.shoulder;
            string chest = hero.chestArmor;
            string gloves = hero.gloves;
            string legs = hero.legs;
            string boots = hero.boots;
            string weapon = hero.weapon;
            /*
            Om jag skapar en lista för all equipment hero har.  
            */
            /*om jag tar in startArmor listan och kan ta fram attributen för dom
            LIST first item
            OM itemtype stämmer med equipped item, kanske måste vara i uppdaterad lista
            SÅ jämför attribut mot item som listas
            SÅ ta Listad -= equipped
            GÖR cw(+attribut) OM positivt
            ANNARS cw(-attribut) OM negativt
            */
            int i = 1;
            int j = 0;
            Console.Write("Color explaning: ");
            Console.ForegroundColor = ConsoleColor.Green; Console.Write($"[IMPROVEMENT] "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow; Console.Write($" [NO CHANGE] "); Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red; Console.Write($" [DOWNGRADE] \n"); Console.ResetColor();
            foreach (var item in items)
            {
                
                Console.Write($"{i++}. || {items[j].itemType} || {items[j].name} Cost: {items[j].gold} gold");
                //if item in list is on the player, its noted as equipped after its listing
                if (items[j].name == helm || items[j].name == shoulder || items[j].name == chest || items[j].name == gloves || items[j].name == legs || items[j].name == boots || items[j].name == weapon)
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
                    Console.Write("\nChange if bought: ");
                    var myItem = equipment.FindIndex(equip => equip.itemId == itermId);
                    if (equipment[myItem].weaponDamage != 0 || items[j].weaponDamage != 0)
                    {
                        var wepdamage = items[j].weaponDamage - equipment[myItem].weaponDamage;
                        if (wepdamage < 0)
                        {
                            Console.Write($"Weapon damage: ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(wepdamage);
                            Console.ResetColor();
                        }
                        else if(wepdamage > 0)
                        {
                            Console.Write($"Weapon damage: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(wepdamage);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write($"Weapon damage: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(wepdamage);
                            Console.ResetColor();
                        }
                    }
                    if (equipment[myItem].attackPower != 0 || items[j].attackPower != 0)
                    {
                        var attpower = items[j].attackPower - equipment[myItem].attackPower;
                        if (attpower < 0)
                        {
                            Console.Write($"Weapon damage: ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(attpower);
                            Console.ResetColor();
                        }
                        else if(attpower > 0)
                        {
                            Console.Write($"Attackpower: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(attpower);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write($"Attackpower: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(attpower);
                            Console.ResetColor();
                        }
                        
                    }
                    if (equipment[myItem].str != 0 || items[j].str != 0)
                    {
                        var strength = items[j].str - equipment[myItem].str;
                        if (strength < 0)
                        {
                            Console.Write($"Strength: ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(strength);
                            Console.ResetColor();
                        }
                        else if(strength > 0)
                        {
                            Console.Write($"Strength: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(strength);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write($"Strength: ");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(strength);
                            Console.ResetColor();
                        }
                        
                    }
                    if (equipment[myItem].crit != 0 || items[j].crit != 0)
                    {
                        var critical = items[j].crit - equipment[myItem].crit;
                        if (critical < 0)
                        {
                            Console.Write($"Critical: ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(critical);
                            Console.ResetColor();
                        }
                        else if(critical > 0)
                        {
                            Console.Write($"Critical: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(critical);
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.Write($"Critical: \n");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(critical);
                            Console.ResetColor();
                        }
                    }
                }
                Console.WriteLine();
                j++;
            }
        }
        public static void CompareItemsTest()
        {
            //get values from equipped items
            //get values from possible items
            //compare equippable items
            //display possible gain value from the items in the shop
            /*
            Itemtype: Weapon, Name: Buster Sword - Equipped 
            [Weapon damage: +18, Strength: +5, Attackpower: 38]
             */


        }
    }
}

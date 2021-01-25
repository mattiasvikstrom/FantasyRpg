using System;
using System.Collections.Generic;
using System.Text;
using FantasyRpg.Player;

namespace FantasyRpg.Shop
{
    class Armor : Merchant
    {
        public static List<Merchant> StarterArmor()
        {
            List<Merchant> equipment = new List<Merchant>();
            equipment.Add(new Merchant
            {
                name = "Iron cap",
                itemType = "helmet",
                gold = 25,
                def = 3,
            });
            equipment.Add(new Merchant
            {
                name = "Iron Chestplate",
                itemType = "chestplate",
                gold = 25,
                def = 2,
            });
            equipment.Add(new Merchant
            {
                name = "Defenders gauntlets",
                itemType = "gloves",
                gold = 25,
                str = 2,
            });
            equipment.Add(new Merchant
            {
                name = "Plated shoulderpads",
                itemType = "shoulder",
                gold = 25,
                str = 5,
                def = 3,
            });
            equipment.Add(new Merchant
            {
                name = "Iron leggings",
                itemType = "legs",
                gold = 25,
                str = 10,
                def = 5,
            });
            equipment.Add(new Merchant
            {
                name = "Steel boots",
                itemType = "boots",
                gold = 25,
                crit = 10,
                def = 5,
            });
            equipment.Add(new Merchant
            {
                name = "Short sword",
                itemType = "weapon",
                itemId = 1011,
                gold = 25,
                weaponDamage = 25,
                str = 1,
            });


            return equipment;
        }
        public static List<Merchant> AddArmor()
        {
            List<Merchant> armor = new List<Merchant>();
            
            armor.Add(new Merchant
            {
                name = "Stealskull",
                itemType = "helmet",
                gold = 250,
                def = 5,
                crit = 5,

            });
            armor.Add(new Merchant
            {
                name = "Vampire Gaze",
                itemType = "helmet",
                gold = 1000,
                def = 5,
                str = 5,
                crit = 5,

            });
            armor.Add(new Merchant
            {
                name = "Harlequin Crest",
                itemType = "helmet",
                gold = 2500,
                def = 15,
                str = 10,
                crit = 10,

            });

            armor.Add(new Merchant
            {
                name = "Pauldrons of the Skeleton King",
                itemType = "shoulder",
                gold = 250,
                str = 5,
                def = 10,
            });
            armor.Add(new Merchant
            {
                name = "Corruption",
                itemType = "shoulder",
                gold = 1000,
                str = 10,
                crit = 5,
                def = 10,
            });
            armor.Add(new Merchant
            {
                name = "The Shadow's Burden",
                itemType = "shoulder",
                gold = 2500,
                str = 25,
                def = 25,
                maxHp = 100,
            });

            armor.Add(new Merchant
            {
                name = "Rockfleece",
                itemType = "chestplate",
                gold = 250,
                def = 10,
                crit = 5,
                maxHp = 50,
            });
            armor.Add(new Merchant
            {
                name = "Shaftstop",
                itemType = "chestplate",
                gold = 1000,
                def = 15,
                crit = 10,
                maxHp = 100,
            });
            armor.Add(new Merchant
            {
                name = "Arkaine's Valor",
                itemType = "chestplate",
                gold = 2500,
                def = 30,
                crit = 20,
                str = 15,
                maxHp = 250,
            });

            armor.Add(new Merchant
            {
                name = "Bloodfist",
                itemType = "gloves",
                gold = 250,
                def = 10,
                str = 5,
            });
            armor.Add(new Merchant
            {
                name = "Hellmouth",
                itemType = "gloves",
                gold = 1000,
                def = 15,
                str = 20,
            });
            armor.Add(new Merchant
            {
                name = "Steelrend",
                itemType = "gloves",
                gold = 2500,
                str = 50,
                crit = 10,
                maxHp = 100,
            });

            armor.Add(new Merchant
            {
                name = "Death's Bargain",
                itemType = "legs",
                gold = 250,
                str = 10,
                def = 5,
            });
            armor.Add(new Merchant
            {
                name = "Skelon's Deceit",
                itemType = "legs",
                gold = 1000,
                str = 5,
                def = 35,
                maxHp = 150,
            });
            armor.Add(new Merchant
            {
                name = "Immortal King's Stature",
                itemType = "legs",
                gold = 2500,
                str = 40,
                def = 45,

            });

            armor.Add(new Merchant
            {
                name = "Gorefoot",
                itemType = "boots",
                gold = 250,
                crit = 2,
                str = 5,
                def = 10,
            });
            armor.Add(new Merchant
            {
                name = "War Traveler",
                itemType = "boots",
                gold = 1000,
                crit = 5,
                def = 15,
                str = 10,
            });
            armor.Add(new Merchant
            {
                name = "Shadow Dancer",
                itemType = "boots",
                gold = 2500,
                crit = 10,
                def = 25,
                str = 20,
                maxHp = 100,
            });
            return armor;
        }
    }
}

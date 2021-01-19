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
            List<Merchant> startArmor = new List<Merchant>();
            startArmor.Add(new Merchant
            {
                name = "Iron cap",
                itemType = "helmet",
                gold = 25,
                def = 3,
            });
            startArmor.Add(new Merchant
            {
                name = "Iron Chestplate",
                itemType = "chestplate",
                gold = 25,
                def = 2,
            });
            startArmor.Add(new Merchant
            {
                name = "Defenders gauntlets",
                itemType = "gloves",
                gold = 25,
                str = 2,
            });
            startArmor.Add(new Merchant
            {
                name = "Plated shoulderpads",
                itemType = "shoulder",
                gold = 25,
                str = 5,
                def = 3,
            });
            startArmor.Add(new Merchant
            {
                name = "Iron leggings",
                itemType = "legs",
                gold = 25,
                str = 10,
                def = 5,
            });
            startArmor.Add(new Merchant
            {
                name = "Steel boots",
                itemType = "boots",
                gold = 25,
                crit = 10,
                def = 5,
            });
            startArmor.Add(new Merchant
            {
                name = "Short sword",
                itemType = "weapon",
                gold = 25,
                weaponDamage = 25,
                
                str = 1,
            });


            return startArmor;
        }
        public static List<Merchant> AddArmor()
        {
            List<Merchant> armor = new List<Merchant>();
            
            armor.Add(new Merchant
            {
                name = "Helm of Chaos",
                itemType = "helmet",
                gold = 250,
                def = 5,
                crit = 5,

            });
            armor.Add(new Merchant
            {
                name = "Warlords chestplate",
                itemType = "chestplate",
                gold = 250,
                def = 10,
                crit = 18,
            }); ;
            
            
            armor.Add(new Merchant
            {
                name = "Hand of midas",
                itemType = "gloves",
                gold = 250,
                str = 5,
            });
            
            armor.Add(new Merchant
            {
                name = "Skullders Ire",
                itemType = "shoulder",
                gold = 250,
                str = 5,
                def = 3,
            });
            
            armor.Add(new Merchant
            {
                name = "Merciless Gladiator's Plate Legguards",
                itemType = "legs",
                gold = 250,
                str = 10,
                def = 5,
            });
            
            armor.Add(new Merchant
            {
                name = "Water walkers",
                itemType = "boots",
                gold = 250,
                crit = 10,
                def = 5,
            });
            return armor;
        }
    }
}

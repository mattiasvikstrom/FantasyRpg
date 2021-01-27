using System.Collections.Generic;


namespace FantasyRpg.Shop
{
    class Armor : Merchant
    {
        //List that contains what the hero initially is wearing
        public static List<Merchant> StarterArmor()
        {
            List<Merchant> equipment = new List<Merchant>();
            equipment.Add(new Merchant
            {
                name = "Iron cap",
                itemType = "helmet",
                itemId = 1110,
                gold = 25,
                def = 3,
            });
            equipment.Add(new Merchant
            {
                name = "Iron Chestplate",
                itemType = "chestplate",
                itemId = 1111,
                gold = 25,
                def = 2,
            });
            equipment.Add(new Merchant
            {
                name = "Defenders gauntlets",
                itemType = "gloves",
                itemId = 1112,
                gold = 25,
                str = 2,
            });
            equipment.Add(new Merchant
            {
                name = "Plated shoulderpads",
                itemType = "shoulder",
                itemId = 1113,
                gold = 25,
                str = 5,
                def = 3,
            });
            equipment.Add(new Merchant
            {
                name = "Iron leggings",
                itemType = "legs",
                itemId = 1114,
                gold = 25,
                str = 10,
                def = 5,
            });
            equipment.Add(new Merchant
            {
                name = "Steel boots",
                itemType = "boots",
                itemId = 1115,
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
        //List with the Hero armor that can be purchaced in the shop
        public static List<Merchant> AddArmor()
        {
            List<Merchant> armor = new List<Merchant>();
            
            armor.Add(new Merchant
            {
                name = "Stealskull",
                itemType = "helmet",
                itemId = 1120,
                gold = 250,
                def = 5,
                crit = 5,

            });
            armor.Add(new Merchant
            {
                name = "Vampire Gaze",
                itemType = "helmet",
                itemId = 1121,
                gold = 1000,
                def = 5,
                str = 5,
                crit = 5,

            });
            armor.Add(new Merchant
            {
                name = "Harlequin Crest",
                itemType = "helmet",
                itemId = 1122,
                gold = 2500,
                def = 15,
                str = 10,
                vit = 10,
                crit = 10,

            });

            armor.Add(new Merchant
            {
                name = "Pauldrons of the Skeleton King",
                itemType = "shoulder",
                itemId = 1123,
                gold = 250,
                str = 5,
                def = 10,
            });
            armor.Add(new Merchant
            {
                name = "Corruption",
                itemType = "shoulder",
                itemId = 1124,
                gold = 1000,
                str = 10,
                crit = 5,
                def = 10,
            });
            armor.Add(new Merchant
            {
                name = "The Shadow's Burden",
                itemType = "shoulder",
                itemId = 1125,
                gold = 2500,
                str = 25,
                def = 25,
                vit = 15,
                maxHp = 100,
            });

            armor.Add(new Merchant
            {
                name = "Rockfleece",
                itemType = "chestplate",
                itemId = 1126,
                gold = 250,
                def = 10,
                crit = 5,
                vit = 5,
                maxHp = 50,
            });
            armor.Add(new Merchant
            {
                name = "Shaftstop",
                itemType = "chestplate",
                itemId = 1127,
                gold = 1000,
                def = 15,
                vit = 20,
                crit = 10,
                maxHp = 100,
            });
            armor.Add(new Merchant
            {
                name = "Arkaine's Valor",
                itemType = "chestplate",
                itemId = 1128,
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
                itemId = 1129,
                gold = 250,
                def = 10,
                str = 5,
            });
            armor.Add(new Merchant
            {
                name = "Hellmouth",
                itemType = "gloves",
                itemId = 1130,
                gold = 1000,
                def = 15,
                str = 20,
            });
            armor.Add(new Merchant
            {
                name = "Steelrend",
                itemType = "gloves",
                itemId = 1131,
                gold = 2500,
                str = 50,
                crit = 10,
                vit = 25,
                maxHp = 100,
            });

            armor.Add(new Merchant
            {
                name = "Death's Bargain",
                itemType = "legs",
                itemId = 1132,
                gold = 250,
                str = 10,
                def = 5,
            });
            armor.Add(new Merchant
            {
                name = "Skelon's Deceit",
                itemType = "legs",
                itemId = 1133,
                gold = 1000,
                str = 5,
                vit = 10,
                def = 35,
                maxHp = 150,
            });
            armor.Add(new Merchant
            {
                name = "Immortal King's Stature",
                itemType = "legs",
                itemId = 1134,
                gold = 2500,
                str = 40,
                def = 45,
                vit = 30,

            });

            armor.Add(new Merchant
            {
                name = "Gorefoot",
                itemType = "boots",
                itemId = 1135,
                gold = 250,
                crit = 2,
                str = 5,
                vit = 5,
                def = 10,
            });
            armor.Add(new Merchant
            {
                name = "War Traveler",
                itemType = "boots",
                itemId = 1136,
                gold = 1000,
                crit = 5,
                def = 15,
                vit = 10,
                str = 10,
            });
            armor.Add(new Merchant
            {
                name = "Shadow Dancer",
                itemType = "boots",
                itemId = 1137,
                gold = 2500,
                crit = 10,
                def = 25,
                vit = 15,
                str = 20,
                maxHp = 100,
            });
            return armor;
        }
    }
}

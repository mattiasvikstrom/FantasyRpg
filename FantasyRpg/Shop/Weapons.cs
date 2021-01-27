using System.Collections.Generic;

namespace FantasyRpg.Shop
{
    class Weapons : Merchant
    {
        //Adding of all the avaliable weapons avaliable to be purchased at the shop
        public static List<Merchant> AddWeapon()
        {
            List<Merchant> weapon = new List<Merchant>();

            weapon.Add(new Merchant
            {
                name = "Buster sword",
                itemType = "weapon",
                itemId = 1012,
                gold = 500,
                weaponDamage = 18,
                attackPower = 38,
                crit = 4,
                str = 5,
            });
            weapon.Add(new Merchant
            {
                name = "Mythril Saber",
                itemType = "weapon",
                itemId = 1013,
                gold = 650,
                weaponDamage = 23,
                attackPower = 40,
                crit = 10,
                str = 5,
            });
            weapon.Add(new Merchant
            {
                name = "Hardedge",
                itemType = "weapon",
                itemId = 1014,
                gold = 800,
                weaponDamage = 32,
                attackPower = 42,
                crit = 15,
                str = 3,
            });
            weapon.Add(new Merchant
            {
                name = "Butterfly Edge",
                itemType = "weapon",
                itemId = 1015,
                gold = 950,
                weaponDamage = 39,
                attackPower = 44,
                crit = 5,
                str = 5,
            });
            weapon.Add(new Merchant
            {
                name = "Enhance Sword",
                itemType = "weapon",
                itemId = 1016,
                gold = 1150,
                weaponDamage = 43,
                attackPower = 46,
                crit = 8,
                str = 4,
            });
            weapon.Add(new Merchant
            {
                name = "Organics",
                itemType = "weapon",
                itemId = 1017,
                gold = 1300,
                weaponDamage = 62,
                attackPower = 48,
                crit = 10,
                def = 5,
                str = 7,
            });
            weapon.Add(new Merchant
            {
                name = "Crystal Sword",
                itemType = "weapon",
                itemId = 1018,
                gold = 1450,
                weaponDamage = 66,
                attackPower = 50,
                crit = 10,
                str = 7,
            });
            weapon.Add(new Merchant
            {
                name = "Force Stealer",
                itemType = "weapon",
                itemId = 1019,
                gold = 1600,
                weaponDamage = 70,
                attackPower = 52,
                crit = 12,
                maxHp = 50,
                str = 2,
            });
            weapon.Add(new Merchant
            {
                name = "Rune Blade",
                itemType = "weapon",
                itemId = 1020,
                gold = 1750,
                weaponDamage = 73,
                attackPower = 50,
                crit = 10,
                def = 5,
                str = 7,
            });
            weapon.Add(new Merchant
            {
                name = "Murasame",
                itemType = "weapon",
                itemId = 1021,
                gold = 1900,
                weaponDamage = 76,
                attackPower = 50,
                crit = 10,
                vit = 5,
                str = 7,
            });
            weapon.Add(new Merchant
            {
                name = "Nail Bat",
                itemType = "weapon",
                itemId = 1022,
                gold = 2050,
                weaponDamage = 80,
                attackPower = 50,
                crit = 7,
                str = 6,
            });
            weapon.Add(new Merchant
            {
                name = "Yoshiyuki",
                itemType = "weapon",
                itemId = 1023,
                gold = 2300,
                weaponDamage = 84,
                attackPower = 50,
                crit = 10,
                str = 10,
            });
            weapon.Add(new Merchant
            {
                name = "Apocalypse",
                itemType = "weapon",
                itemId = 1024,
                gold = 2450,
                weaponDamage = 88,
                attackPower = 50,
                crit = 30,
            });
            weapon.Add(new Merchant
            {
                name = "Heaven's Cloud",
                itemType = "weapon",
                itemId = 1025,
                gold = 2600,
                weaponDamage = 93,
                attackPower = 50,
                crit = 10,
                vit = 20,
                str = 6,
            });
            weapon.Add(new Merchant
            {
                name = "Ragnarok",
                itemType = "weapon",
                itemId = 1026,
                gold = 2750,
                weaponDamage = 97,
                attackPower = 50,
                crit = 11,
                str = 7,
            });
            weapon.Add(new Merchant
            {
                name = "Ultima Weapon",
                itemType = "weapon",
                itemId = 1027,
                gold = 3500,
                weaponDamage = 100,
                attackPower = 120,
                maxHp = 100,
                crit = 12,
                str = 8,
            });
            return weapon;
        }
    }
}

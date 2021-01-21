using System;
using System.Collections.Generic;
using System.Text;
using FantasyRpg.Player;

namespace FantasyRpg.Shop
{
    class Weapons : Merchant
    {
        
        public static List<Merchant> AddWeapon()
        {
            List<Merchant> weapon = new List<Merchant>();
            
            // Possible Stats on weapons
            // WeaponDamage, Str, Attackpower, crit, maxHp
            //

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
                //description = $"Weapondmg {weaponDamage}",

            });
            weapon.Add(new Merchant
            {
                name = "Mythril Saber",
                itemType = "weapon",
                itemId = 1013,
                gold = 1000,
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
                gold = 600,
                weaponDamage = 32,
                attackPower = 42,
                crit = 10,
                str = 7,
            });
            weapon.Add(new Merchant
            {
                name = "Butterfly Edge",
                itemType = "weapon",
                itemId = 1015,
                gold = 600,
                weaponDamage = 39,
                attackPower = 44,
                crit = 10,
                str = 7,
            });
            weapon.Add(new Merchant
            {
                name = "Enhance Sword",
                itemType = "weapon",
                itemId = 1016,
                gold = 600,
                weaponDamage = 43,
                attackPower = 46,
                crit = 10,
                str = 7,
            });
            weapon.Add(new Merchant
            {
                name = "Organics",
                itemType = "weapon",
                itemId = 1017,
                gold = 600,
                weaponDamage = 62,
                attackPower = 48,
                crit = 10,
                str = 7,
            });
            weapon.Add(new Merchant
            {
                name = "Crystal Sword",
                itemType = "weapon",
                itemId = 1018,
                gold = 600,
                weaponDamage = 76,
                attackPower = 50,
                crit = 10,
                str = 7,
            });
            weapon.Add(new Merchant
            {
                name = "Force Stealer",
                itemType = "weapon",
                itemId = 1019,
                gold = 600,
                weaponDamage = 71,
                attackPower = 52,
                crit = 10,
                str = 7,
            });
            weapon.Add(new Merchant
            {
                name = "Rune Blade",
                itemType = "weapon",
                itemId = 1020,
                gold = 600,
                weaponDamage = 71,
                attackPower = 50,
                crit = 10,
                str = 7,
            });
            weapon.Add(new Merchant
            {
                name = "Murasame",
                itemType = "weapon",
                itemId = 1021,
                gold = 600,
                weaponDamage = 71,
                attackPower = 50,
                crit = 10,
                str = 7,
            });
            weapon.Add(new Merchant
            {
                name = "Nail Bat",
                itemType = "weapon",
                itemId = 1022,
                gold = 600,
                weaponDamage = 71,
                attackPower = 50,
                crit = 10,
                str = 7,
            });
            weapon.Add(new Merchant
            {
                name = "Yoshiyuki",
                itemType = "weapon",
                itemId = 1023,
                gold = 600,
                weaponDamage = 71,
                attackPower = 50,
                crit = 10,
                str = 7,
            });
            weapon.Add(new Merchant
            {
                name = "Apocalypse",
                itemType = "weapon",
                itemId = 1024,
                gold = 600,
                weaponDamage = 88,
                attackPower = 50,
                crit = 10,
                str = 7,
            });
            weapon.Add(new Merchant
            {
                name = "Heaven's Cloud",
                itemType = "weapon",
                itemId = 1025,
                gold = 600,
                weaponDamage = 93,
                attackPower = 50,
                crit = 10,
                str = 7,
            });
            weapon.Add(new Merchant
            {
                name = "Ragnarok",
                itemType = "weapon",
                itemId = 1026,
                gold = 600,
                weaponDamage = 97,
                attackPower = 50,
                crit = 10,
                str = 7,
            });
            weapon.Add(new Merchant
            {
                name = "Ultima Weapon",
                itemType = "weapon",
                itemId = 1027,
                gold = 600,
                weaponDamage = 100,
                attackPower = 120,
                crit = 10,
                str = 7,
            });
            return weapon;
        }
    }
}

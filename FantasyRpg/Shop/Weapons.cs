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
            
            weapon.Add(new Merchant
            {
                name = "Buster sword",
                itemType = "weapon",
                gold = 500,
                weaponDamage = 50,
                attackPower = 50,
                str = 5,
            });
            weapon.Add(new Merchant
            {
                name = "Ragnarok",
                itemType = "weapon",
                gold = 550,
                weaponDamage = 60,
                attackPower = 40,
                str = 5,
                crit = 10,
            });
            weapon.Add(new Merchant
            {
                name = "Excalibur II",
                itemType = "weapon",
                gold = 600,
                weaponDamage = 71,
                attackPower = 50,
                crit = 10,
                str = 7,
            });
            return weapon;
        }
    }
}

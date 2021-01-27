using System;
using System.Collections.Generic;
using System.Text;
using FantasyRpg.Player;

namespace FantasyRpg.Shop
{
    class Items : Merchant
    {
        public static List<Merchant> AddItems()
        {
            List<Merchant> items = new List<Merchant>();

            items.Add(new Merchant
            {
                name = "Redbull of Defense",
                itemType = "Potion/buff",
                gold = 500,
                def = 5,
            });
            items.Add(new Merchant
            {
                name = "Redbull of Strength",
                itemType = "Potion/buff",
                gold = 500,
                str = 5,
            });
            items.Add(new Merchant
            {
                name = "Redbull of Critical strike",
                itemType = "Amulet",
                gold = 500,
                crit = 5,
            });
            items.Add(new Merchant
            {
                name = "Amulet of Mastering",
                itemType = "Amulet",
                gold = 800,
                crit = 4,
                str = 4,
            });
            items.Add(new Merchant
            {
                name = "Amulet of fury",
                itemType = "Amulet",
                gold = 400,
                attackPower = 20,
            });
            return items;
        }
    }
}

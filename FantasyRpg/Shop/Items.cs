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
                gold = 250,
                def = 3,
            });
            items.Add(new Merchant
            {
                name = "Redbull of Strength",
                itemType = "Potion/buff",
                gold = 275,
                str = 5,
            });
            items.Add(new Merchant
            {
                name = "Amulet of Critical",
                itemType = "Amulet",
                gold = 300,
                crit = 5,
            });
            items.Add(new Merchant
            {
                name = "Amulet of Masterness",
                itemType = "Amulet",
                gold = 400,
                crit = 5,
                str = 5,
            });
            items.Add(new Merchant
            {
                name = "Amulet of Shieldwall",
                itemType = "Amulet",
                gold = 400,
                block = 5,
            });
            items.Add(new Merchant
            {
                name = "Uber of this",
                itemType = "potion",
                gold = 400,
                block = 5,
                crit = 10,
                str = 3,
                def = 3,
            });


            return items;
        }
    }
}

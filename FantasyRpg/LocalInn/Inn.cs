using System;
using System.Collections.Generic;
using FantasyRpg.Player;
using FantasyRpg.Shop;
using System.Threading;

namespace FantasyRpg.LocalInn
{ 
    class Inn : Merchant
    {
        //Main menu for the Inn where the hero can rest for the night or eat a meal
        public static void VisitInn(Hero hero, List<Merchant> food)
        {
            Console.Clear();
            const float gold = 500;
            Console.WriteLine($"1. Spend the night at the Inn? {gold} gold per night\n" +
                              "2. Eat something\n" +
                              "press [Q] to exit Inn");
            Console.WriteLine(">>");
            string input = Console.ReadLine();
            int intInput;
                switch (input)
                {
                    case "1":
                        if (hero.gold >= gold)
                        {
                            hero.gold -= gold;
                            Console.WriteLine("You enjoy a good nights rest and heal up to full health");
                            hero.hp = hero.maxHp;
                        }
                        else
                        {
                            Console.WriteLine("You do not have enough gold..");
                        }
                        break;
                    case "2":
                        ListEnhancements(food);
                        Console.Write("\nWhat would you like to eat?\n" +
                                      ">>");
                        input = (Console.ReadLine());
                        if (Int32.TryParse(input, out intInput) && intInput <= food.Count && intInput > 0)
                        {
                        EatFood(food, hero, intInput);
                        Merchant.AddAttributes(food, hero, intInput);
                        Thread.Sleep(1000);
                        }
                    else if (input == "q" || input == "Q")
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice");
                        }
                        break;
                    case "q":
                        break;
                }
        }
        //used to display attribute gains on food and items that are not equipped(think consumables or enhancements) its a flat gain
        //so it is slightly different than the ListItems() method.
        public static void ListEnhancements(List<Merchant> food)
        {
            int i = 1;
            int j = 0;
            //loop through food and what additions it adds to player
            foreach (var item in food)
            {
                Console.WriteLine($"\n{i++}. {food[j].name} Cost: {food[j].gold} gold");
                if(food[j].str != 0)
                {
                var str = food[j].str;
                Console.Write($" Str: {str}");
                }
                if (food[j].def != 0)
                {
                var def = food[j].def;
                    Console.Write($" Def: {def}");
                }
                if (food[j].crit != 0)
                {
                var crit = food[j].crit;
                    Console.Write($" Crit: {crit}");
                }
                if (food[j].attackPower != 0)
                {
                    var ap = food[j].attackPower;
                    Console.Write($" Attackpower: {ap}");
                }
                if (food[j].hp != 0)
                {
                    var ap = food[j].hp;
                    Console.Write($" Healing: {ap}");
                }
                j++;
            }
            
        }
        //Handles the eating of purchased food item, check if criteria for gold is met by the hero
        public static void EatFood(List<Merchant> food, Hero hero, int intInput)
        {
            if (hero.gold >= food[intInput - 1].gold)
            {
                var toEat = food[intInput - 1].name;
                Console.WriteLine($"You ate {toEat}");
            }
            else
            {
                Console.WriteLine("You do not have enough gold..");
            }
        }
        //List of available food to be purchased at the inn
        public static List<Merchant> AddFood()
        {
            List<Merchant> food = new List<Merchant>();

            food.Add(new Merchant
            {
                name = "Harty stew",
                itemType = "food",
                gold = 250,
                hp = 50,
                def = 2,
                vit = 2,
            });
            food.Add(new Merchant
            {
                name = "Moonberry cake",
                itemType = "food",
                gold = 250,
                hp = 50,
                str = 2,
                crit = 2,
            });
            food.Add(new Merchant
            {
                name = "Roasted Quail",
                itemType = "food",
                gold = 350,
                hp = 100,
                def = 2,
                maxHp = 30,
            });
            food.Add(new Merchant
            {
                name = "Homemade Cherry Pie",
                itemType = "food",
                gold = 550,
                hp = 200,
                attackPower = 20,
                str = 4,
            });
            return food;
        }
    }
}

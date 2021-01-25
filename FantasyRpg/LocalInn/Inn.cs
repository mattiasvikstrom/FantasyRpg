using System;
using System.Collections.Generic;
using FantasyRpg.Player;
using FantasyRpg.Shop;

namespace FantasyRpg.LocalInn
{
    class Inn : Merchant
    {
        public static void VisitInn(Hero hero, List<Merchant> food)
        {
            Console.Clear();
            //validering och metod ska göras
            //kunna äta mat och få bonus? dyrare att sova över.
            Console.WriteLine("1. Spend the night at the Inn? 100gold per night\n" +
                              "2. Eat something\n" +
                              "press [Q] to exit Inn\n" +
                              ">>");
            string input = Console.ReadLine();
            int intInput;
            float gold = 500;
            do
            {
                switch (input)
                {
                    case "1":
                        if (hero.gold >= gold)
                        {
                            hero.gold -= 100;
                            Console.WriteLine("You enjoy a good nights rest and heal up to full health");
                            hero.hp = hero.maxHp;
                        }
                        else
                        {
                            Console.WriteLine("You do not have enough gold..");
                        }
                        break;
                    case "2":
                        ListFood(food);
                        Console.Write("\nWhat would you like to eat?\n" +
                                      ">>");
                        intInput = Convert.ToInt32(Console.ReadLine());
                        EatFood(food, hero, intInput);
                        Merchant.AddAttributes(food, hero, intInput);
                        break;
                }

            }while(Console.ReadKey().Key != ConsoleKey.Q);
        }
        private static void ListFood(List<Merchant> food)
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
                j++;
            }
            
        }
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
        public static List<Merchant> AddFood()
        {
            List<Merchant> food = new List<Merchant>();

            food.Add(new Merchant
            {
                name = "Harty stew",
                itemType = "food",
                gold = 250,
                def = 1,
                crit = 1,
            });
            food.Add(new Merchant
            {
                name = "Moonberry cake",
                itemType = "food",
                gold = 350,
                def = 2,
                str = 2,
            });
            return food;
        }
    }
}

using System;
using System.Collections.Generic;
using FantasyRpg.Player;
using FantasyRpg.Shop;
using System.Threading;


namespace FantasyRpg.LocalInn
{
    class Inn : Merchant
    {
        //Mainmenu for the Inn where the hero can rest for the night or eat a meal
        public static void VisitInn(Hero hero, List<Merchant> food)
        {
            Console.Clear();
            float gold = 500;
            //validering och metod ska göras
            //kunna äta mat och få bonus? dyrare att sova över.
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
                        ListEnhancements(food); //backa i meny för mat.
                        Console.Write("\nWhat would you like to eat?\n" +
                                      ">>");
                        input = (Console.ReadLine());
                        if (Int32.TryParse(input, out intInput) && intInput <= food.Count && intInput > 0)
                        {
                            EatFood(food, hero, intInput);
                            Merchant.AddAttributes(food, hero, intInput);
                            Thread.Sleep(1000);
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
        //used to display attributegains on food and items that are not equipped(think consumables or enhancements) its a flat gain
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
                j++;
            }
            
        }
        //Handles the eating of purchased food item, checka if criteria for gold is met by the hero
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
        //List of avaliable food to be purchased at the inn
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

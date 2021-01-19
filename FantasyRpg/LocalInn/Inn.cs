using System;
using System.Collections.Generic;
using System.Text;
using FantasyRpg.Player;

namespace FantasyRpg.LocalInn
{
    class Inn
    {
        public static void VisitInn(Hero hero)
        {
            Console.Clear();
            //validering och metod ska göras
            Console.WriteLine("1. Spend the night at the Inn? 100gold per night\n" +
                              "2. Back\n" +
                              ">>");

            string input = Console.ReadLine();
            float gold = 100;
            if (input == "1")
            {
                if (hero.gold >= gold)
                {
                    hero.gold -= 100;
                    Console.WriteLine("You enjoy a good nights rest and heal up to full health");
                    hero.hp = hero.maxHp;
                }
            }
            else if (input == "2")
            {
                Console.WriteLine("Maybe come back when you can pay for it");
                return;
            }
        } //mer hemma i Game?
    }
}

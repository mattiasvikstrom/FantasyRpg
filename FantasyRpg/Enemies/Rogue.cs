using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRpg.Enemies
{
    class Rogue : Monster
    {
       
        public Rogue()
        {

        }

        public Rogue(string _name)
        {
            name = _name;
            NameRare = "Rogue Specialist";
            hp = 800;
            damage = 20;
            minDamage = 15;
            maxDamage = 30;
            gold = 200;
            exp = 52;
        }

        /*
        //public int Attack() 
        //{
        //    int mobDamage = Game.RandomAttackDamage(minDamage, maxDamage);
        //    return mobDamage;
        //}
        
        public void AttackSpecial() { } A signature attack ex, Backstab
        
         
         
         
         
         */
        //maybe void.... or find neat way to hand over gold to hero.
        public override int GiveGold()
        {

            return gold;
        }
        //Chance to face a power powerful monster.
        public override void Specialist()
        {
            name = NameRare;
            hp *= 10 / 5;
            minDamage *= 10 / 8;
            maxDamage *= 10 / 8;
        }
        //keep for test printing and stats check
        public override string ToString()
        {
            return $"Heeeeloo {name}\n" +
                   $"HP {hp}\n" +
                   $"DAMAGE {damage}\n" +
                   $"MIN {minDamage}\n" +
                   $"MAX {maxDamage}\n" +
                   $"GOLD {gold}\n" +
                   $"EXP {exp}\n";
        }
    }
}

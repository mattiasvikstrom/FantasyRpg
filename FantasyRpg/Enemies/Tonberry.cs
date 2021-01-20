﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRpg.Enemies
{
    class Tonberry : Monster
    {
        public Tonberry()
        {

        }
        public Tonberry(string _name)
        {
            name = _name;
            NameRare = "Golden Tonberry";
            hp = 200;
            damage = 220;
            minDamage = 20;
            maxDamage = 55;
            gold = 2200;
            exp = 150;
        }
        public override float MonsterAttackBasic(float mobDamage)
        {
            Console.WriteLine($"{name} strikes you with its weapon!");
            return mobDamage;
        }
        public override float MonsterAttackNormal(float mobDamage)
        {
            Console.WriteLine($"{name} shoots a mass of slime!");
            mobDamage *= 1.2f;
            return mobDamage;
        }
        public override float MonsterAttackSpecial(float mobDamage)
        {
            Console.WriteLine($"{name} starts glowing, and casts Fira magic on you!");
            mobDamage *= 2;
            return mobDamage;
        }
    }
}

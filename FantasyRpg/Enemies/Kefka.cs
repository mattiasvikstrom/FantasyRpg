﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRpg.Enemies
{
    class Kefka : Monster
    {
        public Kefka()
        {

        }
        public Kefka(string _name)
        {
            name = _name;
            NameRare = "Kefka, God of magic";
            hp = 8000;
            damage = 220;
            minDamage = 40;
            maxDamage = 100;
            gold = 2200;
            exp = 150;
        }
        public override float MonsterAttackBasic(float mobDamage)
        {
            Console.WriteLine($"{name} cases Blizzard");
            return mobDamage;
        }
        public override float MonsterAttackNormal(float mobDamage)
        {
            Console.WriteLine($"{name} uses Havoc Wing!");
            mobDamage *= 1.2f;
            return mobDamage;
        }
        public override float MonsterAttackSpecial(float mobDamage)
        {
            Console.WriteLine($"{name} casts Meteor!!");
            mobDamage *= 2;
            return mobDamage;
        }
    }
}

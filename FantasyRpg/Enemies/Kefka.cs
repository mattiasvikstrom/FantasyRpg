﻿using System;

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
            hp = 1500;
            minDamage = 40;
            maxDamage = 100;
            gold = 1000;
            exp = 350;
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
            mobDamage *= 3;
            return mobDamage;
        }
    }
}

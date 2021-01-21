﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FantasyRpg.Enemies
{
    class Kuja : Monster
    {
        public Kuja()
        {

        }
        public Kuja(string _name)
        {
            name = _name;
            NameRare = "Tranced Kuja";
            hp = 1300;
            minDamage = 45;
            maxDamage = 70;
            gold = 590;
            exp = 275;
        }
        public override float MonsterAttackBasic(float mobDamage)
        {
            Console.WriteLine($"{name} casts Flare star!");
            return mobDamage;
        }
        public override float MonsterAttackNormal(float mobDamage)
        {
            Console.WriteLine($"{name} casts Holy!");
            mobDamage *= 1.2f;
            return mobDamage;
        }
        public override float MonsterAttackSpecial(float mobDamage)
        {
            Console.WriteLine($"{name} lifts from the ground, you sense imminent darkness .. Ultima is cast on you!");
            mobDamage *= 3;
            return mobDamage;
        }
    }
}

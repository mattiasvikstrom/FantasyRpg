﻿using System;
using System.Collections.Generic;
using System.Text;
using FantasyRpg.Player;

namespace FantasyRpg.Enemies
{
    interface IMonster
    {
        string name { get; }
        float hp { get; set; }
        int damage { get; set; }
        int minDamage { get; set; }
        int maxDamage { get; set; }
        int exp { get; set; }
        int gold { get; set; }
        float dodge { get; set; }
        float crit { get; set; }
        int lvl { get; set; }
        int def { get; set; }

        void MonsterCombat(Hero hero,List<Monster> mob,int b);
        public virtual int MonsterAttackBasic()
        {
            return damage;
        }
        public virtual int MonsterAttackNormal()
        {
            return damage;
        }
        public virtual int MonsterAttackSpecial()
        {
            return damage;
        }
        
        //int GiveGold();
    }
}

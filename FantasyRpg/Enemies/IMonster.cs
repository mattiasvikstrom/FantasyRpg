using System;
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

        bool Attack(Hero hero,List<Monster> mob,int b, bool defend);
        //int GiveGold();
    }
}

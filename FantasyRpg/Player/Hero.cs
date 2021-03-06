﻿using System;

namespace FantasyRpg.Player
{
    class Hero
    {
        public string name { get; set; }
        public float dmg { get; set; }
        public float hp { get; set; }
        public float maxHp { get; set; }
        public float str { get; set; }
        public float def { get; set; }
        public float gold { get; set; }
        public float crit { get; set; }
        public float exp { get; set; }
        public float maxExp { get; set; }
        public float vit { get; set; }
        public int lvl { get; set; }
        public string className { get; set; }
        public int strModifier { get; set; }
        public int maxHpModifier { get; set; }

        //Hero equipment
        public string helmet { get; set; }
        public string shoulder { get; set; }
        public string chestArmor { get; set; }
        public string gloves { get; set; }
        public string legs { get; set; }
        public string boots { get; set; }
        public string weapon { get; set; }

        //New stats for hero
        public float weaponDamage { get; set; }
        public float attackPower { get; set; }
        public float minDamage { get; set; }
        public float maxDamage { get; set; }

        public Hero()
        {
        }
        public Hero(string heroName)
        {
            name = heroName;
            className = "Warrior";
            lvl = 1; 
            hp = 300;
            maxHp = 300;
            str = 28;
            def = 20;
            vit = 20;
            crit = 10;
            exp = 0;
            gold = 2000;
            maxExp = 150;

            //hero stat modifiers
            strModifier = 2; //modified to 4 when becoming a DeathKnight
            maxHpModifier = 2;//modified to 4 when becoming a DeathKnight

            //Hero damage stats
            weaponDamage = 0;
            attackPower = 0;
            minDamage = 0;
            maxDamage = 0;

            //Equipment
            helmet = "Iron cap";
            shoulder = "Plated shoulderpads";
            chestArmor = "Iron Chestplate";
            gloves = "Defenders gauntlets";
            legs = "Iron leggings";
            boots = "Steel boots";
            weapon = "Short sword";
        }
        public float WeaponDamage { get { return weaponDamage; } set { weaponDamage = weaponDamage; } } //should be == equipped weapon
        public float Str { get { return str; } set { str += lvl * strModifier; } } // calculates hero strength
        public float AttackPower { get { return attackPower; } set { attackPower += str * 2; } }
        public float MinDamage { get{ return minDamage; } set { minDamage = weaponDamage * attackPower / 32; } } //minimum damage to calculate random between min -> max.
        public float MaxDamage { get { return maxDamage; } set { maxDamage = weaponDamage * attackPower / 24; } }
        public float MaxHp { get { return maxHp; } set { maxHp += vit * lvl * maxHpModifier; } } //calculates hero maximum health
        public float MaxExp { get { return maxExp; } set { maxExp += 250 / 2; } } //calculates amount needed to level up 150 for first level up and 750 for last
        public float Def { get { return def; } set { def = value; } }
        public int Lvl { get { return lvl; } set { lvl = value; } }
        public override string ToString()
        {
            Console.Clear();
            return $"********************\n" +
                   $"* Hero\n" +
                   $"* Name: {name}\n" +
                   $"* Class: {className}\n" +
                   $"* Lvl: {lvl}\n" +
                   $"* Damage: {(int)Math.Round(minDamage)} - {(int)Math.Round(maxDamage)}\n" +
                   $"* AttackPower: {attackPower}\n" +
                   $"* Hp: {hp} / {maxHp}\n" +
                   $"* Def: {def}\n" +
                   $"* Str: {str}\n" +
                   $"* Crit: {crit}\n" +
                   $"* Vit: {vit}\n" +
                   $"********************\n" +
                   $"* Equipment\n" +
                   $"* Helm: {helmet} \n" +
                   $"* Shoulder: {shoulder} \n" +
                   $"* Chest armor: {chestArmor}\n" +
                   $"* Gloves: {gloves} \n" +
                   $"* Leg Armor: {legs} \n" +
                   $"* Boots: {boots} \n" +
                   $"* Weapon: {weapon}, Weapon damage: {weaponDamage}\n" +
                   $"********************\n" +
                   $"* Exp: {exp} / {maxExp}\n" +
                   $"* Gold: {gold}\n" +
                    "********************";
        }
    }
}

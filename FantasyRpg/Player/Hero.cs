using System;
using System.Collections.Generic;
using System.Text;

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
        public float block { get; set; }
        public string className { get; set; }
        public int strModifier { get; set; }
        public int maxHpModifier { get; set; }

        //EQUIPMENT TEST! hur kan jag lösa vad jag faktiskt har equippat. 
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
            lvl = 1; //uses
            //dmg = 25; // Maybe not use damage. have weapondamage instead. maybe Avg damage... simplified min + max / 2. 150 + 200 / 2 = 175
            hp = 200; //uses
            maxHp = 200; //uses
            str = 28; //uses
            def = 20; //uses
            vit = 20; //uses 
            crit = 10; //uses
            exp = 0; //uses
            gold = 2000; //uses
            maxExp = 150; //uses

            strModifier = 2; //modified to 4 when becomming a DeathKnight
            maxHpModifier = 2;//modified to 4 when becomming a DeathKnight

            //new stats test
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
        //reconcider float on some . or add rounding of numbers to display no decimals.
        public float WeaponDamage { get { return weaponDamage; }set { weaponDamage = weaponDamage; } } //should be == equipped weapon
        public float Str { get { return str; } set { str += lvl * strModifier; } } // calculates hero strength
        public float AttackPower { get { return attackPower; } set { attackPower = attackPower + str * 2; } }
        public float MinDamage { get{ return minDamage; }set { minDamage = weaponDamage * attackPower / 32; } } //minimum damage to calculate random between min -> max.
        public float MaxDamage { get { return maxDamage; } set { maxDamage = weaponDamage * attackPower / 24; } }
         //kika genom värden för AP så det inte är för sjukt.
        
        public float MaxHp { get { return maxHp; } set { maxHp += vit * lvl * maxHpModifier; } } //calculates hero maximum health
        //public float Dmg { get { return dmg; } set { dmg = dmg + str * 2; } } // calculates player damage
        public float MaxExp { get { return maxExp; } set { maxExp = maxExp + 150 / 2f; } } //calculates amount needed to level up 150 for first level up and 750 for last
        public float Def { get { return def; } set { def = value; } }
        public int Lvl { get { return lvl; } set { lvl = value; } } //test
        public override string ToString()
        {
            Console.Clear();
            return $"********************\n" +
                   $"* Hero\n" +
                   $"* Name: {name}\n" +
                   $"* Class: {className}\n" +
                   $"* Damage: {(int)Math.Round(minDamage)} - {(int)Math.Round(maxDamage)}\n" +
                   $"* Hp: {hp} / {maxHp}\n" +
                   $"* Def: {def}\n" +
                   $"* Gold: {gold}\n" +
                   $"* Exp: {exp} / {maxExp}\n" +
                   $"* Str: {str}\n" +
                   $"* AttackPower: {attackPower}\n" +
                   $"* Crit: {crit}\n" +
                   $"* Vit: {vit}\n" +
                   $"* Lvl: {lvl}\n" +
                   $"* Weapon name: {weapon}, Weapon damage: {weaponDamage}\n" +
                   $"********************\n" +
                   $"* Equipment\n" +
                   $"* Helm: {helmet} \n" +
                   $"* Shoulder: {shoulder} \n" +
                   $"* Chest armor: {chestArmor}\n" +
                   $"* Gloves: {gloves} \n" +
                   $"* Leg Armor: {legs} \n" +
                   $"* Boots: {boots} \n" +
                   $"* Weapon: {weapon}\n" +
                   $"********************";
        }
    }
}

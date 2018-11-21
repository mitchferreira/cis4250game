using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructsClass : MonoBehaviour {

    public struct Character
    {
        public string name;
        public string charClass;
        public int level;
        public int exp;
        public int str;
        public int dex;
        public int con;
        public int inte;
        public int wis;
        public int chr;

        public int hitDiceValue;
        public int maxHealth;
        public int currentHealth;

        //public string statusEffects;

        public Weapon weapon;
        public Armor armor;

        public Ability[] actions;
    }

    //To clarify the variables
    // diceType = number sided dice (4-sided, 6-sided...)
    // numOfDice = number of the diceType used
    // modifier = a stat modifier to add to the attack
    // a normal attack may be 1 6-sided dice with a strength modifier giving it plus 2 damage
    public struct Weapon
    {
        public string name;
        public int diceType;
        public int numOfDice;
        public string modifier;
        public string damageType;
    }

    public struct Armor
    {
        public string name;
        public int armorValue;
        public string damageResist;
    }

    public struct Ability
    {
        public string name;
        public int cost;
        public int diceType;
        public int numOfDice;
        public string modifier;
        public string damageType;

    }


    public struct Enemy
    {
        public string name;
        public int str;
        public int dex;
        public int con;
        public int inte;
        public int wis;
        public int chr;

        public int health;
        public int armor;
        public int rewardExp;
        public int rewardGold;

        public string[] weaknesses;
        public string[] resistances;
        public string[] immunities;

        public EnemyAbility[] actions;
    }

    public struct EnemyAbility
    {
        public string name;
        public int diceType;
        public int numOfDice;
        public int addedHit;
        public int addedDamage;
        public string damageType;

    }


    public struct InitiativeArray
    {
        public StructsClass.Character[] characters;
        public StructsClass.Enemy[] enemies;
    }

}

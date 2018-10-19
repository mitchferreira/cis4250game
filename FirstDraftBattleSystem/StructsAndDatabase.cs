using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StructsAndDatabase : MonoBehaviour {

    // im considering re-using this for the enemies
    //hard coding thier weapons and armors to be their attacks and natural resistences
    struct Character
    {
        public string name;
        public string charClass;
        public int level;
        public int str;
        public int dex;
        public int con;
        public int inte;
        public int wis;
        public int chr;

        public int hitDiceValue;
        public int maxHealth;

        public string statusEffects;

        public Weapon weapon;
        public Armor armor;

        public Action[] actions;
    }

    //To clarify the variables
    // diceType = number sided dice (4-sided, 6-sided...)
    // numOfDice = number of the diceType used
    // modifier = a stat modifier to add to the attack
    // a normal attack may be 1 6-sided dice with a strength modifier giving it plus 2 damage
    struct Weapon
    {
        public string name;
        public int diceType;
        public int numOfDice;
        public string modifier;
        public string damageType;
    }

    struct Armor
    {
        public string name;
        public int armorValue;
        public string damageResist;
    }

    struct Action
    {
        public string name;
        public int cost;
        public int diceType;
        public int numOfDice;
        public string modifier;
        public string damageType;

    }











    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        GUILayout.Label("cat");
        GUILayout.Label("dog");
        GUILayout.Label("bird");
    }
}

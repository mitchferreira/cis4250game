using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBattle : MonoBehaviour {

    void Start()
    {
        
        initUnits();
    }

    public void initUnits()
    {
        StructsClass.Character Warrior;
        StructsClass.Character Rogue;
        StructsClass.Character Wizard;
        StructsClass.Character Cleric;

        StructsClass.Enemy Goblin1;
        StructsClass.Enemy Goblin2;

        print("testing init");

        int i, j = 0;

        Warrior = Definitions.defineStartingWarrior();
        Rogue = Definitions.defineStartingRogue();
        Wizard = Definitions.defineStartingWizard();
        Cleric = Definitions.defineStartingCleric();

        Goblin1 = Enemies.defineGoblin();
        Goblin2 = Enemies.defineGoblin();

        Goblin1.name = "Goblin1";
        Goblin2.name = "Goblin2";



Items.defineWeapons();
        Warrior.weapon = Items.Longsword;
        Rogue.weapon = Items.Dagger;
        Wizard.weapon = Items.Staff;
        Cleric.weapon = Items.Mace;

        Enemies.defineEnemyActions();

        Goblin1.actions[0] = Enemies.SwordAttack;
        Goblin2.actions[0] = Enemies.SwordAttack;


        print(Goblin1.actions[0].name);
        print(Goblin1.actions[0].diceType);
        print(Goblin1.str);



        simulateBattle(Warrior,Rogue,Wizard,Cleric,Goblin1,Goblin2);
    }


    public void simulateBattle(StructsClass.Character Warrior, StructsClass.Character Rogue, StructsClass.Character Wizard, StructsClass.Character Cleric,
        StructsClass.Enemy Goblin1, StructsClass.Enemy Goblin2)
    {
        int i, j = 0;
        int enemySelector = 0;
        int hitStatus = 0;
        int damage = 0;


        int numAlivePlayers = 0;
        int numAliveEnemies = 0;


        string[] initiativeReferenceArray = new string[6];

        System.Random rand = new System.Random();

        

        initiativeReferenceArray[0] = "Kent";
        initiativeReferenceArray[1] = "Joseph";
        initiativeReferenceArray[2] = "Scott";
        initiativeReferenceArray[3] = "Mitchell";
        initiativeReferenceArray[4] = "Goblin1";
        initiativeReferenceArray[5] = "Goblin2";

        StructsClass.InitiativeArray initA;
        initA.characters = new StructsClass.Character[4];
        initA.enemies = new StructsClass.Enemy[2];

        initA.characters[0] = Warrior;
        initA.characters[1] = Rogue;
        initA.characters[2] = Wizard;
        initA.characters[3] = Cleric;

        initA.enemies[0] = Goblin1;
        initA.enemies[1] = Goblin2;

        for (i = 0; i < initiativeReferenceArray.Length; i++)
        {
            for (j = 0; j < initA.characters.Length; j++)
            {
                if (initA.characters[j].name == initiativeReferenceArray[i])
                {
                    //print(initA.characters[j].name + " found at position " + i);
                }
            }

        }

        for (i = 0; i < initiativeReferenceArray.Length; i++)
        {
            for (j = 0; j < initA.enemies.Length; j++)
            {
                if (initA.enemies[j].name == initiativeReferenceArray[i])
                {
                    //print(initA.enemies[j].name + " found at position " + i);
                }
            }

        }

        initiativeReferenceArray = Calculations.determineInitiative(initA);

        print("The initiative order for test battle is:");
        for (i = 0; i < initiativeReferenceArray.Length; i++)
        {
            print(i+1 + " " + initiativeReferenceArray[i]);
        }


        numAlivePlayers = 4;
        numAliveEnemies = 2;

        while ((numAliveEnemies > 0) && (numAlivePlayers > 0))
        {

            for (i = 0; i < initiativeReferenceArray.Length; i++)
            {

                for (j = 0; j < initA.characters.Length; j++)
                {
                    if ((initA.characters[j].name == initiativeReferenceArray[i]) && (initA.characters[j].currentHealth != 0))
                    {
                        print(initiativeReferenceArray[i] + " attacks");
                        enemySelector = (rand.Next(0, initA.enemies.Length));
                        hitStatus = Calculations.CalculatePlayerWeaponHit(initA.characters[j], initA.enemies[enemySelector]);

                        if (hitStatus != 0)
                        {
                            print("hit status = " + hitStatus);
                            damage = Calculations.WeaponAttack(initA.characters[j], hitStatus, initA.enemies[enemySelector]);
                            print(initA.characters[j].name + " hit for " + damage + " damage");

                            initA.enemies[enemySelector].health = initA.enemies[enemySelector].health - damage;
                            if (initA.enemies[enemySelector].health < 0)
                            {
                                initA.enemies[enemySelector].health = 0;
                                numAliveEnemies = numAliveEnemies - 1;
                                print("XXXXX " + initA.enemies[enemySelector].name + " has died");
                            }
                        }
                        else
                        {
                            print(initA.characters[j].name + " missed " + initA.enemies[enemySelector].name);
                        }

                        break;
                    }
                }



                for (j = 0; j < initA.enemies.Length; j++)
                {
                    if ((initA.enemies[j].name == initiativeReferenceArray[i]) && (initA.enemies[j].health != 0))
                    {
                        print(initiativeReferenceArray[i] + " attacks");
                        enemySelector = (rand.Next(0, initA.characters.Length));
                        hitStatus = Calculations.CalculateEnemyHit(initA.characters[j], Enemies.SwordAttack);
                        if (hitStatus != 0)
                        {
                            print("hit status = " + hitStatus);
                            damage = Calculations.CalculateEnemyDamage(Enemies.SwordAttack, hitStatus);
                            print(initA.enemies[j].name + " hit for " + damage + " damage");

                            initA.characters[enemySelector].currentHealth = initA.characters[enemySelector].currentHealth - damage;
                            if (initA.characters[enemySelector].currentHealth < 0)
                            {
                                initA.characters[enemySelector].currentHealth = 0;
                                numAlivePlayers = numAlivePlayers - 1;
                            }
                        }
                        else
                        {
                            print(initA.enemies[j].name + " missed " + initA.characters[enemySelector].name);
                            print("XXXXX " + initA.characters[enemySelector].name + " has died");
                        }

                        break;
                    }
                }
            }
        }

        if(numAliveEnemies == 0)
        {
            print("PLAYERS WIN");
        }
        else
        {
            print("ENEMIES WIN");
        }



        //start of battle
        //generate encounter from pre-made lists of enemies

        //roll for initiaive (turn order)


        //generate the initiative for the enemies
        //put initiative in list, use Array.Sort() to sort them
        //maybe use a table and key system to keep track of which number refers to each combatant

        //select move
        //select target
        //if player use Calculations.CalculatePlayerHit(), then Calculations.CalculatePlayerDamage()
        //if enemy use Calculations.CalculateEnemyHit(), then Calculations.CalculateEnemyDamage()
        //once attack if done, check if all of one group is dead
        //move down the initiative order

    }















    public void printStats(StructsClass.Character Player)
    {
        string level = Player.level.ToString();
        string health = Player.currentHealth.ToString() + " / " + Player.maxHealth.ToString();
        string str = Player.str.ToString();
        string dex = Player.dex.ToString();
        string con = Player.con.ToString();
        string inte = Player.inte.ToString();
        string wis = Player.wis.ToString();
        string cha = Player.chr.ToString();

        GUILayout.Label("Name: " + Player.name);
        GUILayout.Label("Class: " + Player.charClass);
        GUILayout.Label("Level: " + level);
        GUILayout.Label("Health: " + health);
        GUILayout.Label("Strength: " + str);
        GUILayout.Label("Dexterity: " + dex);
        GUILayout.Label("Constitution: " + con);
        GUILayout.Label("Intelligence: " + inte);
        GUILayout.Label("Wisdom: " + wis);
        GUILayout.Label("Charisma " + cha);
        GUILayout.Label("");
    }



}

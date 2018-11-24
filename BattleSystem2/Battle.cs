﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour {

    public static int playerGold;
    public static int playerExp;
    public static int playerAttack;

    public Text outputText;

    public static int whoseTurnIsIt;


    /*

    // This Start() function makes a test battle against two goblins
     void Start()
     {
         int i,j = 0;

        // define the different static public variables needed
         Items.defineWeapons();
         Items.defineArmor();
         Enemies.defineEnemies();
         Enemies.defineEnemyActions();
         Abilities.defineActions();

        // create the four characters
         StructsClass.Character Warrior;
         StructsClass.Character Rogue;
         StructsClass.Character Wizard;
         StructsClass.Character Cleric;

         StructsClass.Enemy Goblin1;
         StructsClass.Enemy Goblin2;

        // define their starting stats and equipment
         Warrior = Definitions.defineStartingWarrior();
         Rogue = Definitions.defineStartingRogue();
         Wizard = Definitions.defineStartingWizard();
         Cleric = Definitions.defineStartingCleric();
         Warrior.weapon = Items.ILongsword;
         Warrior.armor = Items.Leather;
         Rogue.weapon = Items.IDagger;
         Rogue.armor = Items.Leather;
         Wizard.weapon = Items.OStaff;
         Wizard.armor = Items.Leather;
         Cleric.weapon = Items.IMace;
         Cleric.armor = Items.Leather;

        // define enemy goblin stats and abilities
         Goblin1 = Enemies.Goblin;
         Goblin2 = Enemies.Goblin;

         Goblin1.name = "Goblin1";
         Goblin2.name = "Goblin2";
         Goblin1.actions[0] = Enemies.SwordAttack;
         Goblin2.actions[0] = Enemies.SwordAttack;

        // create a struct for all battle participants
         StructsClass.InitiativeArray initA;
         initA.characters = new StructsClass.Character[4];
         initA.enemies = new StructsClass.Enemy[2];

         initA.characters[0] = Warrior;
         initA.characters[1] = Rogue;
         initA.characters[2] = Wizard;
         initA.characters[3] = Cleric;

         initA.enemies[0] = Goblin1;
         initA.enemies[1] = Goblin2;







        // start the battle simulation
         StartCoroutine(simulateBattle(initA.characters, initA.enemies));
     }

        */

// this function is used in the main program to run actual battles against generated enemies

    void Start() {
        GameObject player = GameObject.Find("player");

        StartCoroutine(simulateBattle(player.GetComponent<Movement>().players, player.GetComponent<Movement>().enemies));
    }



    // This function manages every part of the battle loop
    public IEnumerator simulateBattle(StructsClass.Character[] players, StructsClass.Enemy[] enemies)
    {
        int i, j = 0;
        int enemySelector = 0;
        int hitStatus = 0;
        int damage = 0;

        whoseTurnIsIt = 0;

        // create a struct containing all battle participants
        StructsClass.InitiativeArray initA;
        initA.characters = new StructsClass.Character[4];
        initA.enemies = new StructsClass.Enemy[enemies.Length];

        // create variables to check if all enemies are dead or if the player is
        int numAlivePlayers = initA.characters.Length;
        int numAliveEnemies = initA.enemies.Length;

        System.Random rand = new System.Random();

        // assign the participants to the struct
        initA.characters[0] = players[0];
        initA.characters[1] = players[1];
        initA.characters[2] = players[2];
        initA.characters[3] = players[3];

        for(i=0; i<enemies.Length; i++)
        {
            initA.enemies[i] = enemies[i];
        }

        // copy the participants to an array which will determine the order of turns
        string[] initiativeReferenceArray = new string[4 + initA.enemies.Length];
        initiativeReferenceArray[0] = "Kent";
        initiativeReferenceArray[1] = "Joseph";
        initiativeReferenceArray[2] = "Scott";
        initiativeReferenceArray[3] = "Mitchell";

        for (i = 4; i < initiativeReferenceArray.Length; i++)
        {
            initiativeReferenceArray[i] = initA.enemies[j].name;
            j = j + 1;
        }

        // send the array of all participants though a calculator to determine turn order
        initiativeReferenceArray = Calculations.determineInitiative(initA);


        //the code breaks if an enemy goes first for some reason, this prevents it
        // rouge goes first because rouges are sneaky
        if ( (initiativeReferenceArray[0] != "Kent") &&
            (initiativeReferenceArray[0] != "Joseph") &&
            (initiativeReferenceArray[0] != "Scott") &&
            (initiativeReferenceArray[0] != "Mitchell") )
        {
            for (i=0; i<initiativeReferenceArray.Length; i++)
            {
                if(initiativeReferenceArray[i] == "Joseph")
                {
                    initiativeReferenceArray[i] = initiativeReferenceArray[0];
                    initiativeReferenceArray[0] = "Joseph";
                }
            }
        }














        
        outputText.text = ("Beginning Battle.\n");
        outputText.text += ("The initiative order for the battle is:\n");

        // output the turn order for the player to see
        for (i = 0; i < initiativeReferenceArray.Length; i++)
        {
            outputText.text += (i+1 + " " + initiativeReferenceArray[i] + "\n");
        }

        // continue battleing until all of one side is dead
        while ((numAliveEnemies > 0) && (numAlivePlayers > 0))
        {
            // loop through all participants
            for (i = 0; i < initiativeReferenceArray.Length; i++)
            {
                // loop through all player characters
                for (j = 0; j < initA.characters.Length; j++)
                {
                    // if it is that player character's turn and they are not dead, commence their turn
                    if ((initA.characters[j].name == initiativeReferenceArray[i]) && (initA.characters[j].currentHealth != 0))
                    {
                        if(initA.characters[j].charClass == "Warrior")
                        {
                            whoseTurnIsIt = 1;
                        }
                        if (initA.characters[j].charClass == "Rogue")
                        {
                            whoseTurnIsIt = 2;
                        }
                        if (initA.characters[j].charClass == "Wizard")
                        {
                            whoseTurnIsIt = 3;
                        }
                        if (initA.characters[j].charClass == "Cleric")
                        {
                            whoseTurnIsIt = 4;
                        }



                        // if this character was blocking, they stop blocking
                        initA.characters[j].blocking = 0;

                        if(initA.characters[j].attackBuff > 0)
                        {
                            initA.characters[j].attackBuff = initA.characters[j].attackBuff - 1;
                        }
                        if (initA.characters[j].defenceBuff > 0)
                        {
                            initA.characters[j].defenceBuff = initA.characters[j].defenceBuff - 1;
                        }

                        //due to the simplicity of the current code, the target enemy is selected randomly
                        enemySelector = (rand.Next(0, initA.enemies.Length));


                        outputText.text +=("It's " + initiativeReferenceArray[i] + "'s turn.\n");

                        // loop until the player decides an action
                        playerAttack = -1;
                        while (playerAttack == -1)
                        {
                            // causes the loop
                            yield return null;

                            // the player decided to block
                            if(playerAttack == 0)
                            {
                                initA.characters[j].blocking = 1;
                            }

                            // special action for the cleric's healing skill, as it involves a different function
                            else if(playerAttack == 14)
                            {
                                initA.characters = Calculations.CureWounds(initA.characters);
                            }

                            // the player has done a basic attack with their weapon
                            else if(playerAttack == 2)
                            {

                                if (initA.characters[j].charClass == "Warrior")
                                {
                                    damage = Calculations.DeterminePlayerAction(2, initA.characters[j], initA.enemies[enemySelector]);
                                }
                                if (initA.characters[j].charClass == "Rogue")
                                {
                                    damage = Calculations.DeterminePlayerAction(5, initA.characters[j], initA.enemies[enemySelector]);
                                }
                                if (initA.characters[j].charClass == "Wizard")
                                {
                                    damage = Calculations.DeterminePlayerAction(9, initA.characters[j], initA.enemies[enemySelector]);
                                }
                                if (initA.characters[j].charClass == "Cleric")
                                {
                                    damage = Calculations.DeterminePlayerAction(13, initA.characters[j], initA.enemies[enemySelector]);
                                }

                            }

                            // the player has used an ability, consult the chart in Calculations
                            else
                            {
                                damage = Calculations.DeterminePlayerAction(playerAttack, initA.characters[j], initA.enemies[enemySelector]);
                            }


                            // if the player tries to use an ability but doesn't have enough mp to use it
                            if ((damage == -1) && (playerAttack != -1))
                            {
                                playerAttack = 0;
                                outputText.text += ("Not Enough MP, please select a different attack.\n");
                            }

                        }




                        // subtract damage from enemy health and determine if it is dead
                        initA.enemies[enemySelector].health = initA.enemies[enemySelector].health - damage;
                        if (initA.enemies[enemySelector].health < 0)
                        {
                            initA.enemies[enemySelector].health = 0;
                            numAliveEnemies = numAliveEnemies - 1;
                            outputText.text += (initA.enemies[enemySelector].name + " has died\n");
                        }

                        // the participant in the turn order completed their turn, progress to the next participant
                        whoseTurnIsIt = 0;
                        break;
                    }
                }


                // go through the list of enemies
                for (j = 0; j < initA.enemies.Length; j++)
                {
                    // if it is the enemies's turn and they are not dead
                    if ((initA.enemies[j].name == initiativeReferenceArray[i]) && (initA.enemies[j].health != 0))
                    {
                        // if enemies are stunned, they become unstunned and lose their turn
                        if(initA.enemies[j].stun == 1)
                        {
                            initA.enemies[j].stun = 0;
                            outputText.text += (initiativeReferenceArray[i] + " is stunned\n");
                            break;
                        }

                        outputText.text += (initiativeReferenceArray[i] + " attacks\n");

                        // enemy selects a character to attack
                        enemySelector = (rand.Next(0, initA.characters.Length));

                        if (initA.characters[enemySelector].currentHealth == 0)
                        {
                            while (initA.characters[enemySelector].currentHealth == 0)
                            {
                                enemySelector = ((enemySelector + 1) % initA.characters.Length);
                            }
                        }

                        // calculate if the enemy hits
                        hitStatus = Calculations.CalculateEnemyHit(initA.characters[enemySelector], Enemies.SwordAttack);

                        // if the enemy hit, calculate damage
                        if (hitStatus != 0)
                        {
                            damage = Calculations.CalculateEnemyDamage(Enemies.SwordAttack, hitStatus);

                            // determine if a player character died
                            initA.characters[enemySelector].currentHealth = initA.characters[enemySelector].currentHealth - damage;
                            if (initA.characters[enemySelector].currentHealth < 0)
                            {
                                initA.characters[enemySelector].currentHealth = 0;
                                numAlivePlayers = numAlivePlayers - 1;
                                outputText.text += (initA.characters[enemySelector].name + " has died\n");
                            }
                        }


                        break;
                    }
                }

                // if either all enemies or the player is dead, end the battle
                if ((numAliveEnemies == 0) || (numAlivePlayers == 0))
                {
                    break;
                }

            }
        }

        // if the player won
        if(numAliveEnemies == 0)
        {
            outputText.text += ("PLAYERS WIN\n");

            // give the player gold
            outputText.text += ("You obtained " + Calculations.calculateGold(initA.enemies) + " gold.\n");
            playerGold = playerGold + Calculations.calculateGold(initA.enemies);

            // give the players experience points
            playerExp = Calculations.calculateExperience(initA.enemies);
            outputText.text += ("You obtained " + playerExp + " experience points.\n");

            initA.characters[0].exp = initA.characters[0].exp + playerExp;
            initA.characters[1].exp = initA.characters[1].exp + playerExp;
            initA.characters[2].exp = initA.characters[2].exp + playerExp;
            initA.characters[3].exp = initA.characters[3].exp + playerExp;

            // check if they level up
            initA.characters = Calculations.levelUp(initA.characters);

            GameObject player = GameObject.Find("player");
            player.GetComponent<PartyScript>().LevelUpParty(initA.characters);

        }
        // the enemies won
        else
        {
            outputText.text += ("ENEMIES WIN\n");
        }


    }



}
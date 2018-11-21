using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour {

    public static int playerGold;
    public static int playerExp;
    public static int playerAttack;

    void Start()
    {
        int i,j = 0;

        Items.defineWeapons();
        Items.defineArmor();
        Enemies.defineEnemyActions();

        StructsClass.Character Warrior;
        StructsClass.Character Rogue;
        StructsClass.Character Wizard;
        StructsClass.Character Cleric;

        StructsClass.Enemy Goblin1;
        StructsClass.Enemy Goblin2;

        Warrior = Definitions.defineStartingWarrior();
        Rogue = Definitions.defineStartingRogue();
        Wizard = Definitions.defineStartingWizard();
        Cleric = Definitions.defineStartingCleric();
        Warrior.weapon = Items.Longsword;
        Warrior.armor = Items.Leather;
        Rogue.weapon = Items.Dagger;
        Rogue.armor = Items.Leather;
        Wizard.weapon = Items.Staff;
        Wizard.armor = Items.Leather;
        Cleric.weapon = Items.Mace;
        Cleric.armor = Items.Leather;

        Goblin1 = Enemies.defineGoblin();
        Goblin2 = Enemies.defineGoblin();

        Goblin1.name = "Goblin1";
        Goblin2.name = "Goblin2";
        Goblin1.actions[0] = Enemies.SwordAttack;
        Goblin2.actions[0] = Enemies.SwordAttack;


        StructsClass.InitiativeArray initA;
        initA.characters = new StructsClass.Character[4];
        initA.enemies = new StructsClass.Enemy[2];

        initA.characters[0] = Warrior;
        initA.characters[1] = Rogue;
        initA.characters[2] = Wizard;
        initA.characters[3] = Cleric;

        initA.enemies[0] = Goblin1;
        initA.enemies[1] = Goblin2;








        StartCoroutine(simulateBattle(initA.characters, initA.enemies));
    }


    public IEnumerator simulateBattle(StructsClass.Character[] players, StructsClass.Enemy[] enemies)
    {
        int i, j = 0;
        int enemySelector = 0;
        int hitStatus = 0;
        int damage = 0;

        StructsClass.InitiativeArray initA;
        initA.characters = new StructsClass.Character[4];
        initA.enemies = new StructsClass.Enemy[enemies.Length];

        int numAlivePlayers = initA.characters.Length;
        int numAliveEnemies = initA.enemies.Length;

        System.Random rand = new System.Random();


        initA.characters[0] = players[0];
        initA.characters[1] = players[1];
        initA.characters[2] = players[2];
        initA.characters[3] = players[3];

        for(i=0; i<enemies.Length; i++)
        {
            initA.enemies[i] = enemies[i];
        }

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


        initiativeReferenceArray = Calculations.determineInitiative(initA);











        print("Beginning Battle.");

        print("The initiative order for the battle is:");
        for (i = 0; i < initiativeReferenceArray.Length; i++)
        {
            print(i+1 + " " + initiativeReferenceArray[i]);
        }

        while ((numAliveEnemies > 0) && (numAlivePlayers > 0))
        {

            for (i = 0; i < initiativeReferenceArray.Length; i++)
            {

                for (j = 0; j < initA.characters.Length; j++)
                {
                    if ((initA.characters[j].name == initiativeReferenceArray[i]) && (initA.characters[j].currentHealth != 0))
                    {
                        
                        enemySelector = (rand.Next(0, initA.enemies.Length));
                        print("It's " + initiativeReferenceArray[i] + "'s turn.");

                        playerAttack = 0;
                        while (playerAttack == 0)
                        {
                            yield return null;

                            damage = Calculations.DeterminePlayerAction(playerAttack, initA.characters[j], initA.enemies[enemySelector]);

                            if(playerAttack == 14)
                            {
                                initA.characters = Calculations.CureWounds(initA.characters);
                            }

                            if ((damage == -1) && (playerAttack != 0))
                            {
                                playerAttack = 0;
                                print("Not Enough MP, please select a different attack.");
                            }

                        }



                        

                        initA.enemies[enemySelector].health = initA.enemies[enemySelector].health - damage;
                        if (initA.enemies[enemySelector].health < 0)
                        {
                            initA.enemies[enemySelector].health = 0;
                            numAliveEnemies = numAliveEnemies - 1;
                            print(initA.enemies[enemySelector].name + " has died");
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

                        if(initA.characters[enemySelector].currentHealth == 0)
                        {
                            while(initA.characters[enemySelector].currentHealth == 0)
                            {
                                enemySelector = ((enemySelector + 1) % initA.characters.Length);
                            }
                        }

                        hitStatus = Calculations.CalculateEnemyHit(initA.characters[j], Enemies.SwordAttack);
                        if (hitStatus != 0)
                        {
                            damage = Calculations.CalculateEnemyDamage(Enemies.SwordAttack, hitStatus);
                            //print(initA.enemies[j].name + " hit for " + damage + " damage");

                            initA.characters[enemySelector].currentHealth = initA.characters[enemySelector].currentHealth - damage;
                            if (initA.characters[enemySelector].currentHealth < 0)
                            {
                                initA.characters[enemySelector].currentHealth = 0;
                                numAlivePlayers = numAlivePlayers - 1;
                                print(initA.characters[enemySelector].name + " has died");
                            }
                        }
                        

                        break;
                    }
                }

                if ((numAliveEnemies == 0) || (numAlivePlayers == 0))
                {
                    break;
                }

            }
        }

        if(numAliveEnemies == 0)
        {
            print("PLAYERS WIN");

            print("You obtained " + Calculations.calculateGold(initA.enemies) + " gold.");
            playerGold = playerGold + Calculations.calculateGold(initA.enemies);


            playerExp = Calculations.calculateExperience(initA.enemies);
            print("You obtained " + playerExp + " experience points.");

            initA.characters[0].exp = initA.characters[0].exp + playerExp;
            initA.characters[1].exp = initA.characters[1].exp + playerExp;
            initA.characters[2].exp = initA.characters[2].exp + playerExp;
            initA.characters[3].exp = initA.characters[3].exp + playerExp;


            initA.characters = Calculations.levelUp(initA.characters);

        }
        else
        {
            print("ENEMIES WIN");
        }


    }



}

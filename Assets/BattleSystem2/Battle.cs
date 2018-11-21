using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour {

    public static int playerGold;
    public static int playerExp;
    public static int playerAttack;
    static Battle instance;
    public Text healthBar1;
    public Text healthBar2;
    public Text healthBar3;
    public Text healthBar4;
    //public Text damageText;

    public Text outputText;

    // void Start()
    // {
    //     int i,j = 0;

    //     Items.defineWeapons();
    //     Items.defineArmor();
    //     Enemies.defineEnemyActions();
    //     Abilities.defineActions();

    //     StructsClass.Character Warrior;
    //     StructsClass.Character Rogue;
    //     StructsClass.Character Wizard;
    //     StructsClass.Character Cleric;

    //     StructsClass.Enemy Goblin1;
    //     StructsClass.Enemy Goblin2;

    //     Warrior = Definitions.defineStartingWarrior();
    //     Rogue = Definitions.defineStartingRogue();
    //     Wizard = Definitions.defineStartingWizard();
    //     Cleric = Definitions.defineStartingCleric();
    //     Warrior.weapon = Items.Longsword;
    //     Warrior.armor = Items.Leather;
    //     Rogue.weapon = Items.Dagger;
    //     Rogue.armor = Items.Leather;
    //     Wizard.weapon = Items.Staff;
    //     Wizard.armor = Items.Leather;
    //     Cleric.weapon = Items.Mace;
    //     Cleric.armor = Items.Leather;

    //     Goblin1 = Enemies.defineGoblin();
    //     Goblin2 = Enemies.defineGoblin();

    //     Goblin1.name = "Goblin1";
    //     Goblin2.name = "Goblin2";
    //     Goblin1.actions[0] = Enemies.SwordAttack;
    //     Goblin2.actions[0] = Enemies.SwordAttack;


    //     StructsClass.InitiativeArray initA;
    //     initA.characters = new StructsClass.Character[4];
    //     initA.enemies = new StructsClass.Enemy[2];

    //     initA.characters[0] = Warrior;
    //     initA.characters[1] = Rogue;
    //     initA.characters[2] = Wizard;
    //     initA.characters[3] = Cleric;

    //     initA.enemies[0] = Goblin1;
    //     initA.enemies[1] = Goblin2;








    //     StartCoroutine(simulateBattle(initA.characters, initA.enemies));
    // }
    
    void Start() {
        GameObject player = GameObject.Find("player");

        StartCoroutine(simulateBattle(player.GetComponent<Movement>().players, player.GetComponent<Movement>().enemies));
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

        //print("Beginning Battle.");
        outputText.text = ("Beginning Battle.\n");
        outputText.text += ("The initiative order for the battle is:\n");

        //print("The initiative order for the battle is:");
        for (i = 0; i < initiativeReferenceArray.Length; i++)
        {
            outputText.text += (i+1 + " " + initiativeReferenceArray[i] + "\n");
        }

        while ((numAliveEnemies > 0) && (numAlivePlayers > 0))
        {

            for (i = 0; i < initiativeReferenceArray.Length; i++)
            {

                for (j = 0; j < initA.characters.Length; j++)
                {
                    healthBar1.text = initA.characters[0].currentHealth + "/" + initA.characters[0].maxHealth;
                    healthBar2.text = initA.characters[1].currentHealth + "/" + initA.characters[1].maxHealth;
                    healthBar3.text = initA.characters[2].currentHealth + "/" + initA.characters[2].maxHealth;
                    healthBar4.text = initA.characters[3].currentHealth + "/" + initA.characters[3].maxHealth;

                    if ((initA.characters[j].name == initiativeReferenceArray[i]) && (initA.characters[j].currentHealth != 0))
                    {

                        enemySelector = (rand.Next(0, initA.enemies.Length));
                        outputText.text +=("It's " + initiativeReferenceArray[i] + "'s turn.\n");

                        playerAttack = 0;
                        while (playerAttack == 0)
                        {
                            yield return null;


                            if(playerAttack == 14)
                            {
                                initA.characters = Calculations.CureWounds(initA.characters);
                            }

                            else if(playerAttack == 2)
                            {

                                if (initA.characters[j].charClass == "Warrior")
                                {
                                    damage = Calculations.DeterminePlayerAction(2, initA.characters[j], initA.enemies[enemySelector]);
                                    //damageText.text = "Kent does " + damage + "damage";
                                }
                                if (initA.characters[j].charClass == "Rogue")
                                {
                                    damage = Calculations.DeterminePlayerAction(5, initA.characters[j], initA.enemies[enemySelector]);
                                    //damageText.text = "Joseph does " + damage + "damage";
                                }
                                if (initA.characters[j].charClass == "Wizard")
                                {
                                    damage = Calculations.DeterminePlayerAction(9, initA.characters[j], initA.enemies[enemySelector]);
                                    //damageText.text = "Scott does " + damage + "damage";
                                }
                                if (initA.characters[j].charClass == "Cleric")
                                {
                                    damage = Calculations.DeterminePlayerAction(13, initA.characters[j], initA.enemies[enemySelector]);
                                    //damageText.text = "Mitchell does " + damage + "damage";
                                }

                            }

                            else
                            {
                                damage = Calculations.DeterminePlayerAction(playerAttack, initA.characters[j], initA.enemies[enemySelector]);
                            }



                            if ((damage == -1) && (playerAttack != 0))
                            {
                                playerAttack = 0;
                                outputText.text += ("Not Enough MP, please select a different attack.\n");
                            }

                        }





                        initA.enemies[enemySelector].health = initA.enemies[enemySelector].health - damage;
                        if (initA.enemies[enemySelector].health < 0)
                        {
                            initA.enemies[enemySelector].health = 0;
                            numAliveEnemies = numAliveEnemies - 1;
                            outputText.text += (initA.enemies[enemySelector].name + " has died\n");
                        }


                        break;
                    }
                    
                }



                for (j = 0; j < initA.enemies.Length; j++)
                {
                    if ((initA.enemies[j].name == initiativeReferenceArray[i]) && (initA.enemies[j].health != 0))
                    {
                        outputText.text += (initiativeReferenceArray[i] + " attacks\n");
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
                                outputText.text += (initA.characters[enemySelector].name + " has died\n");
                            }
                            //healthBar.UpdateBar(initA.characters[j].currentHealth,initA.characters[j].maxHealth);
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
            outputText.text += ("PLAYERS WIN\n");

            outputText.text += ("You obtained " + Calculations.calculateGold(initA.enemies) + " gold.\n");
            playerGold = playerGold + Calculations.calculateGold(initA.enemies);


            playerExp = Calculations.calculateExperience(initA.enemies);
            outputText.text += ("You obtained " + playerExp + " experience points.\n");

            initA.characters[0].exp = initA.characters[0].exp + playerExp;
            initA.characters[1].exp = initA.characters[1].exp + playerExp;
            initA.characters[2].exp = initA.characters[2].exp + playerExp;
            initA.characters[3].exp = initA.characters[3].exp + playerExp;


            initA.characters = Calculations.levelUp(initA.characters);

            GameObject player = GameObject.Find("player");
            player.GetComponent<PartyScript>().LevelUpParty(initA.characters);

            string enemyName = player.GetComponent<Movement>().encounteredEnemy;
            GameObject.Find(enemyName).GetComponent<EnemyScript>().defeated = true;
            GameObject.Find("_mysql").GetComponent<DatabaseHandler>().SaveGame();

        }
        else
        {
            outputText.text += ("ENEMIES WIN\n");
        }


    }



}

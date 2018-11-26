using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour {

    public static int playerGold;
    public static int playerExp;
    public static int playerAttack;
    public static int flag;
    public static int enemySelector = 0;

    public Text outputText;

    public Text victoryText;
    public Text healthBar1;
    public Text healthBar2;
    public Text healthBar3;
    public Text healthBar4;


    public Button warriorSkill1;
    public Button warriorSkill2;
    public Button warriorSkill3;
    public Button warriorSkill4;
    public Button rogueSkill1;
    public Button rogueSkill2;
    public Button rogueSkill3;
    public Button rogueSkill4;
    public Button wizardSkill1;
    public Button wizardSkill2;
    public Button wizardSkill3;
    public Button wizardSkill4;
    public Button wizardSkill5;
    public Button clericSkill1;
    public Button clericSkill2;
    public Button clericSkill3;

	public GameObject warrior_skill_panel;
    public GameObject rogue_skill_panel;
    public GameObject wizard_skill_panel;
    public GameObject cleric_skill_panel;
    public GameObject victory_panel;
    public GameObject defeated_panel;

    public SimpleHealthBar c1health;
    public SimpleHealthBar c2health;
    public SimpleHealthBar c3health;
    public SimpleHealthBar c4health;

    public static int whoseTurnIsIt;


    /*

    // This Start() function makes a test battle against two goblins
     void Start()
     {

        testGobKing();
        testGobKing();
        testGobKing();

    }

    void testGobKing()
    {
        int i, j = 0;

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

        StructsClass.Enemy GoblinKing;
        StructsClass.Enemy Goblin;

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
        GoblinKing = Enemies.GobKing;
        Goblin = Enemies.Goblin;

        GoblinKing.actions[0] = Enemies.LongswordAttack;
        Goblin.actions[0] = Enemies.SwordAttack;

        // create a struct for all battle participants
        StructsClass.InitiativeArray initA;
        initA.characters = new StructsClass.Character[4];
        initA.enemies = new StructsClass.Enemy[2];

        initA.characters[0] = Warrior;
        initA.characters[1] = Rogue;
        initA.characters[2] = Wizard;
        initA.characters[3] = Cleric;

        initA.enemies[0] = GoblinKing;
        initA.enemies[1] = Goblin;







        // start the battle simulation
        StartCoroutine(simulateBattle(initA.characters, initA.enemies));
    }

    */


    // this function is used in the main program to run actual battles against generated enemies

        void Start() {
            GameObject player = GameObject.Find("player");

            StartCoroutine(simulateBattle(player.GetComponent<Movement>().players, player.GetComponent<Movement>().enemies));
        }

    public void showSP(){
        // Add checking for skills based on level
        if(whoseTurnIsIt == 1){
            Debug.Log("warrior");
            warrior_skill_panel.SetActive(true);
            rogue_skill_panel.SetActive(false);
            wizard_skill_panel.SetActive(false);
            cleric_skill_panel.SetActive(false);
        }else if(whoseTurnIsIt == 2){
            Debug.Log("Rogue");
            warrior_skill_panel.SetActive(false);
            rogue_skill_panel.SetActive(true);
            wizard_skill_panel.SetActive(false);
            cleric_skill_panel.SetActive(false);
        }else if(whoseTurnIsIt == 3){
            Debug.Log("Wizard");
            warrior_skill_panel.SetActive(false);
            rogue_skill_panel.SetActive(false);
            wizard_skill_panel.SetActive(true);
            cleric_skill_panel.SetActive(false);
        }else if(whoseTurnIsIt == 4){
            Debug.Log("Cleric");
            warrior_skill_panel.SetActive(false);
            rogue_skill_panel.SetActive(false);
            wizard_skill_panel.SetActive(false);
            cleric_skill_panel.SetActive(true);
        }
		//skills_panel.SetActive(true);
	}

    public void hideSkills(){
            warrior_skill_panel.SetActive(false);
            rogue_skill_panel.SetActive(false);
            wizard_skill_panel.SetActive(false);
            cleric_skill_panel.SetActive(false);
    }

    // This function manages every part of the battle loop
    public IEnumerator simulateBattle(StructsClass.Character[] players, StructsClass.Enemy[] enemies)
    {
        int i, j = 0;
        int hitStatus = 0;
        int damage = 0;
        int dice = 0;

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


	if(initA.enemies[0].name == initA.enemies[1].name)
        {
            initA.enemies[0].name = initA.enemies[0].name + " 1";
            initA.enemies[1].name = initA.enemies[1].name + " 2";
        }


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




        for (i=0; i<initA.characters.Length; i++)
        {
            if(initA.characters[i].charClass == "Warrior")
            {
                for (j=0; j<initA.characters[i].actions.Length; j++)
                {
                    if(initA.characters[i].actions[j].name == "Thrust")
                    {
                        initA.characters[i].actions[j].finalDescription = initA.characters[i].actions[j].baseDescription + initA.characters[i].actions[j].numOfDice + "d" + initA.characters[i].weapon.diceType + 2;
                    }
                    if (initA.characters[i].actions[j].name == "Power Slash")
                    {
                        initA.characters[i].actions[j].finalDescription = initA.characters[i].actions[j].baseDescription + initA.characters[i].actions[j].numOfDice + "d" + initA.characters[i].weapon.diceType + 4;
                    }

                }
            }

            if (initA.characters[i].charClass == "Rogue")
            {
                for (j = 0; j < initA.characters[i].actions.Length; j++)
                {
                    if ((initA.characters[i].actions[j].name == "Swift Cut") || (initA.characters[i].actions[j].name == "Poison Knife") || (initA.characters[i].actions[j].name == "Multi-Stab"))
                    {
                        initA.characters[i].actions[j].finalDescription = initA.characters[i].actions[j].baseDescription + initA.characters[i].actions[j].numOfDice + "d" + initA.characters[i].weapon.diceType + 2;
                    }

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
                    healthBar1.text = initA.characters[0].currentHealth + "/" + initA.characters[0].maxHealth;
                    healthBar2.text = initA.characters[1].currentHealth + "/" + initA.characters[1].maxHealth;
                    healthBar3.text = initA.characters[2].currentHealth + "/" + initA.characters[2].maxHealth;
                    healthBar4.text = initA.characters[3].currentHealth + "/" + initA.characters[3].maxHealth;

                    c1health.UpdateBar(initA.characters[0].currentHealth, initA.characters[0].maxHealth);
                    c2health.UpdateBar(initA.characters[1].currentHealth, initA.characters[1].maxHealth);
                    c3health.UpdateBar(initA.characters[2].currentHealth, initA.characters[2].maxHealth);
                    c4health.UpdateBar(initA.characters[3].currentHealth, initA.characters[3].maxHealth);

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

                        if(initA.characters[j].burn > 0)
                        {
                            initA.characters[j].burn = initA.characters[j].burn - 1;
                            initA.characters[j].currentHealth = initA.characters[j].currentHealth - 2;
                            outputText.text = (initA.characters[j].name + " was burned.\n");

			    if(initA.characters[j].currentHealth <= 0)
                            {
                                outputText.text += (initA.enemies[enemySelector].name + " has died\n");
                                break;
                            }
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
				    break;
                            }

                            // special action for the cleric's healing skill, as it involves a different function
                            else if(playerAttack == 16)
                            {
                                initA.characters = Calculations.CureWounds(initA.characters);
				    break;
                            }



                            enemySelector = 0;
                            flag = 0;
                            while (flag == 0)
                            {
                                // causes the loop
                                yield return null;


                                // the player has done a basic attack with their weapon
                                if ((playerAttack == 1) && (flag != 0))
                                {
                                    damage = Calculations.DeterminePlayerAction(1, initA.characters[j], initA.enemies[enemySelector]);
                                    /*
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
                                    */

                                }

                                // the player has used an ability, consult the chart in Calculations
                                else if (flag != 0)
                                {
                                    damage = Calculations.DeterminePlayerAction(playerAttack, initA.characters[j], initA.enemies[enemySelector]);
                                    initA.characters[j].currentMagicPoints = initA.characters[j].currentMagicPoints - 1;
				}
                            }


                            // if the player tries to use an ability but doesn't have enough mp to use it
                            if ((damage == -1) && (playerAttack != -1))
                            {
                                playerAttack = -1;
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

                //// enemy attack ////

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


                        dice = rand.Next(0, initA.enemies[j].actions.Length);

                        // calculate if the enemy hits
                        hitStatus = Calculations.CalculateEnemyHit(initA.characters[enemySelector], initA.enemies[j].actions[dice]);

                        // if the enemy hit, calculate damage
                        if (hitStatus != 0)
                        {
                            damage = Calculations.CalculateEnemyDamage(initA.enemies[j].actions[dice], hitStatus);

                            if(initA.enemies[j].actions[dice].name == "Flame Touch")
                            {
                                dice = rand.Next(0, 4);
                                if(dice == 4)
                                {
                                    initA.characters[enemySelector].burn = 3;
                                }
                            }

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

            victory_panel.SetActive(true);
            Debug.Log("WOOOOOOOO");
            GameObject.Find("player").GetComponent<Movement>().encounteredEnemy.GetComponent<EnemyScript>().defeated = true;
            GameObject.Find("_mysql").GetComponent<DatabaseHandler>().SaveGame();
        }
        // the enemies won
        else
        {
            GameObject.Find("DefeatScreen").SetActive(true);
            outputText.text += ("ENEMIES WIN\n");
        }
    }

}

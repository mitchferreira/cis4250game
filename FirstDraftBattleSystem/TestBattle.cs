using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBattle : MonoBehaviour {

    public void simulateBattle(StructsClass.Character warrior, StructsClass.Character rogue, StructsClass.Character wizard, StructsClass.Character cleric)
    {
        //start of battle
        //generate encounter from pre-made lists of enemies

        //roll for initiaive (turn order)
        int dice = 0;
        int[] playerInit = new int[4];
        System.Random rand = new System.Random();

        playerInit[0] = (rand.Next(1, 20)) + Calculations.getModifier("dexterity", warrior);
        playerInit[1] = (rand.Next(1, 20)) + Calculations.getModifier("dexterity", rogue);
        playerInit[2] = (rand.Next(1, 20)) + Calculations.getModifier("dexterity", wizard);
        playerInit[3] = (rand.Next(1, 20)) + Calculations.getModifier("dexterity", cleric);

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

}

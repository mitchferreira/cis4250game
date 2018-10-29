using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calculations : MonoBehaviour
{

    public static int numberConvert(int number)
    {
        switch (number)
        {
            case 1:
                return -5;
            case 2:
                return -4;
            case 3:
                return -4;
            case 4:
                return -3;
            case 5:
                return -3;
            case 6:
                return -2;
            case 7:
                return -2;
            case 8:
                return -1;
            case 9:
                return -1;
            case 10:
                return 0;
            case 11:
                return 0;
            case 12:
                return 1;
            case 13:
                return 1;
            case 14:
                return 2;
            case 15:
                return 2;
            case 16:
                return 3;
            case 17:
                return 3;
            case 18:
                return 4;
            case 19:
                return 4;
            case 20:
                return 5;
            case 21:
                return 5;
            case 22:
                return 6;
            case 23:
                return 6;
            case 24:
                return 7;
            case 25:
                return 7;
            case 26:
                return 8;
            case 27:
                return 8;
            case 28:
                return 9;
            case 29:
                return 9;
            case 30:
                return 10;
        }

        return 0;
    }


    public static int getModifier(String modifier, StructsClass.Character player)
    {
        int modValue = 0;

        switch (modifier)
        {
            case "strength":
                modValue = numberConvert(player.str);
                return modValue;
            case "dexterity":
                modValue = numberConvert(player.dex);
                return modValue;
            case "constitution":
                modValue = numberConvert(player.con);
                return modValue;
            case "intelligence":
                modValue = numberConvert(player.inte);
                return modValue;
            case "wisdom":
                modValue = numberConvert(player.wis);
                return modValue;
            case "charisma":
                modValue = numberConvert(player.chr);
                return modValue;
        }

        return modValue;
    }


    public static int CalculatePlayerHit(StructsClass.Character player, StructsClass.Enemy enemy, StructsClass.Ability attack)
    {
        int dice = 0;

        System.Random rand = new System.Random();

        dice = (rand.Next(1, 20));

        if(dice == 20)
        {
            return 2;
        }

        if (dice == 1)
        {
            return -1;
        }

        dice = dice + getModifier(attack.modifier, player);

        if (dice >= enemy.armor)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }


    public static int CalculatePlayerWeaponHit(StructsClass.Character player, StructsClass.Enemy enemy)
    {
        int dice = 0;

        System.Random rand = new System.Random();

        dice = (rand.Next(1, 20));

        if (dice == 20)
        {
            return 2;
        }

        if (dice == 1)
        {
            return -1;
        }

        dice = dice + getModifier(player.weapon.modifier, player);

        if (dice >= enemy.armor)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }



    public static int CalculateEnemyHit(StructsClass.Character player, StructsClass.EnemyAbility attack)
    {
        int dice = 0;

        System.Random rand = new System.Random();

        dice = (rand.Next(1, 20));

        if (dice == 20)
        {
            return 2;
        }

        if (dice == 1)
        {
            return -1;
        }

        dice = dice + attack.addedHit;

        if (dice >= player.armor.armorValue)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }



    public static int CalculatePlayerDamage(StructsClass.Ability attack, int crit, StructsClass.Enemy enemy)
    {
        int damage = 0;
        int i = 0;

        if (crit == 2)
        {
            damage = 2 * (attack.diceType * attack.numOfDice);
        }
        else if (crit == -1)
        {
            return 0;
        }

        else
        {
            System.Random rand = new System.Random();
            damage = ((rand.Next(1, attack.diceType)) * attack.numOfDice);
        }

        for (i = 0; i < enemy.weaknesses.Length; i++)
        {
            if (attack.damageType == enemy.weaknesses[i])
            {
                damage = damage * 2;
            }
        }

        for (i = 0; i < enemy.resistances.Length; i++)
        {
            if (attack.damageType == enemy.resistances[i])
            {
                damage = damage / 2;
            }
        }

        for (i = 0; i < enemy.immunities.Length; i++)
        {
            if (attack.damageType == enemy.immunities[i])
            {
                damage = 0;
            }
        }

        return damage;
    }


    public static int WeaponAttack(StructsClass.Character player, int crit, StructsClass.Enemy enemy)
    {
        int damage = 0;
        int i = 0;
        int forVar = 0;
        System.Random rand = new System.Random();

        if (crit == 2)
        {
            damage = 2 * (player.weapon.diceType * player.weapon.numOfDice);
        }
        else if (crit == -1)
        {
            return 0;
        }

        else
        {
            damage = (rand.Next(1, player.weapon.diceType));
            damage = damage * player.weapon.numOfDice;
        }

        forVar = enemy.weaknesses.Length;
        if (forVar != 0)
        {
            for (i = 0; i < forVar; i++)
            {
                if (player.weapon.damageType == enemy.weaknesses[i])
                {
                    damage = damage * 2;
                }
            }
        }

        for (i = 0; i < enemy.resistances.Length; i++)
        {
            if (player.weapon.damageType == enemy.resistances[i])
            {
                damage = damage / 2;
            }
        }
        for (i = 0; i < enemy.immunities.Length; i++)
        {
            if (player.weapon.damageType == enemy.immunities[i])
            {
                damage = 0;
            }
        }
        return damage;
    }


    public static int CalculateEnemyDamage(StructsClass.EnemyAbility attack, int crit)
    {
        int damage = 0;
        int i = 0;

        if (crit == 2)
        {
            damage = 2 * (attack.diceType * attack.numOfDice);
        }
        else if (crit == -1)
        {
            return 0;
        }
        else
        {
            System.Random rand = new System.Random();
            damage = ((rand.Next(1, attack.diceType)) * attack.numOfDice) + attack.addedDamage;
        }

        return damage;
    }




    public static string[] determineInitiative(StructsClass.InitiativeArray initA)
    {
        int i, j = 0;
        int initiative;
        int totalParticipants = 0;


        totalParticipants = initA.characters.Length + initA.enemies.Length;

        int[] initNumArray = new int[totalParticipants];
        string[] initiativeReferenceArray = new string[totalParticipants];

        System.Random rand = new System.Random();


        for (i = 0; i < initA.characters.Length; i++)
        {
            initiativeReferenceArray[j] = initA.characters[i].name;
            initiative = (rand.Next(1, 20)) + Calculations.numberConvert(initA.characters[i].dex);
            initNumArray[j] = initiative;

            j = j + 1;
        }
        for (i = 0; i < initA.enemies.Length; i++)
        {
            initiativeReferenceArray[j] = initA.enemies[i].name;
            initiative = (rand.Next(1, 20)) + Calculations.numberConvert(initA.enemies[i].dex);
            initNumArray[j] = initiative;

            j = j + 1;
        }

        Array.Sort(initNumArray, initiativeReferenceArray);

        return initiativeReferenceArray;
    }



}






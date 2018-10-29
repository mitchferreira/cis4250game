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
            print("Critical Hit!");
            return 2;
        }

        if (dice == 1)
        {
            print("Critical Miss.");
            return -1;
        }

        

        print("You hit a " + dice + " + " + getModifier(attack.modifier, player) + " against " + enemy.name + "'s armor of " + enemy.armor);

        dice = dice + getModifier(attack.modifier, player);

        if (dice >= enemy.armor)
        {
            print("You hit.");
            return 1;
        }
        else
        {
            print("You Miss.");
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
            print("Critical Hit!");
            return 2;
        }

        if (dice == 1)
        {
            print("Critical Miss.");
            return -1;
        }

       

        print("You hit a " + dice + " + " + getModifier(player.weapon.modifier, player) + " against " + enemy.name + "'s armor of " + enemy.armor);

        dice = dice + getModifier(player.weapon.modifier, player);

        if (dice >= enemy.armor)
        {
            print("You hit.");
            return 1;
        }
        else
        {
            print("You Miss.");
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
            print("Critical Hit!");
            return 2;
        }

        if (dice == 1)
        {
            print("Critical Miss.");
            return -1;
        }

        print("The enemy hit a " + dice + " + " + attack.addedHit + " against " + player.name + "'s armor of " + player.armor.armorValue);

        dice = dice + attack.addedHit;

        if (dice >= player.armor.armorValue)
        {
            print("They hit.");
            return 1;
        }
        else
        {
            print("They Missed.");
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
            print("You did 0 damage.");
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
                print(enemy.name + " is weak to " + attack.damageType);
                damage = damage * 2;
            }
        }

        for (i = 0; i < enemy.resistances.Length; i++)
        {
            if (attack.damageType == enemy.resistances[i])
            {
                print(enemy.name + " is resistant to " + attack.damageType);
                damage = damage / 2;
            }
        }

        for (i = 0; i < enemy.immunities.Length; i++)
        {
            if (attack.damageType == enemy.immunities[i])
            {
                print(enemy.name + " is immune to " + attack.damageType);
                damage = 0;
            }
        }

        print("You did " + damage + " damage.");
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
            print("You did 0 damage.");
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
                    print(enemy.name + " is weak to " + player.weapon.damageType);
                    damage = damage * 2;
                }
            }
        }

        for (i = 0; i < enemy.resistances.Length; i++)
        {
            if (player.weapon.damageType == enemy.resistances[i])
            {
                print(enemy.name + " is resistant to " + player.weapon.damageType);
                damage = damage / 2;
            }
        }
        for (i = 0; i < enemy.immunities.Length; i++)
        {
            if (player.weapon.damageType == enemy.immunities[i])
            {
                print(enemy.name + " is immune to " + player.weapon.damageType);
                damage = 0;
            }
        }

        print("You did " + damage + " damage.");
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
            print("They did 0 damage.");
            return 0;
        }
        else
        {
            System.Random rand = new System.Random();
            damage = ((rand.Next(1, attack.diceType)) * attack.numOfDice) + attack.addedDamage;
        }


        print("They did " + damage + " damage.");
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


    public static int calculateGold(StructsClass.Enemy[] enemies)
    {
        int i = 0;
        int totalGold = 0;

        for (i = 0; i < enemies.Length; i++)
        {
            totalGold = totalGold + enemies[i].rewardGold;
        }

        return totalGold;
    }

    public static int calculateExperience(StructsClass.Enemy[] enemies)
    {
        int i = 0;
        int totalExp = 0;

        for (i=0; i<enemies.Length; i++)
        {
            totalExp = totalExp + enemies[i].rewardExp;
        }

        return totalExp;
    }


    public static StructsClass.Character[] levelUp(StructsClass.Character[] players)
    {
        int i = 0;
        
        for (i=0; i<players.Length; i++)
        {
            
            if (players[i].charClass == "Warrior")
            {
                if ((players[i].level == 1) && (players[i].exp >= 200))
                {
                    players[i] = Definitions.levelTwoWarrior(players[i]);
                }
                else if ((players[i].level == 2) && (players[i].exp >= 500))
                {
                    players[i] = Definitions.levelThreeWarrior(players[i]);
                }
            }


            if (players[i].charClass == "Rogue")
            {
                if ((players[i].level == 1) && (players[i].exp >= 200))
                {
                    players[i] = Definitions.levelTwoRogue(players[i]);
                }
                else if ((players[i].level == 2) && (players[i].exp >= 500))
                {
                    players[i] = Definitions.levelThreeRogue(players[i]);
                }
            }

            if (players[i].charClass == "Wizard")
            {
                if ((players[i].level == 1) && (players[i].exp >= 200))
                {
                    players[i] = Definitions.levelTwoWizard(players[i]);
                }
                else if ((players[i].level == 2) && (players[i].exp >= 500))
                {
                    players[i] = Definitions.levelThreeWizard(players[i]);
                }
            }

            if (players[i].charClass == "Cleric")
            {
                if ((players[i].level == 1) && (players[i].exp >= 200))
                {
                    players[i] = Definitions.levelTwoCleric(players[i]);
                }
                else if ((players[i].level == 2) && (players[i].exp >= 500))
                {
                    players[i] = Definitions.levelThreeCleric(players[i]);
                }
            }

            
        }
        

        return players;
    }










    public static int DeterminePlayerAction(int action, StructsClass.Character player, StructsClass.Enemy enemy)
    {
        int damage = -1;
        int hitStatus = 0;

        if(Abilities.ShieldBash.cost <= player.magicPoints)
        {

        }


        switch (action)
        {
            // Normal Attack
            case 1:
                print(player.name + " attacks with their " + player.weapon.name);
                hitStatus = Calculations.CalculatePlayerWeaponHit(player, enemy);
                if (hitStatus == 0)
                {
                    return 0;
                }
                damage = Calculations.WeaponAttack(player, hitStatus, enemy);
                return damage;

            // Warrior Skills
            case 2:
                if (Abilities.ShieldBash.cost <= player.magicPoints)
                {
                    print(player.name + " uses Shield Bash");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.ShieldBash);
                    if (hitStatus == 0)
                    {
                        return 0;
                    }
                    damage = CalculatePlayerDamage(Abilities.ShieldBash, hitStatus, enemy);
                }
                return damage;

            case 3:
                if (Abilities.Thrust.cost <= player.magicPoints)
                {
                    print(player.name + " uses Thrust");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.Thrust);
                    if (hitStatus == 0)
                    {
                        return 0;
                    }
                    damage = CalculatePlayerDamage(Abilities.Thrust, hitStatus, enemy);
                }
                return damage;

            case 4:
                if (Abilities.PowerSlash.cost <= player.magicPoints)
                {
                    print(player.name + " uses Power Slash");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.PowerSlash);
                    if (hitStatus == 0)
                    {
                        return 0;
                    }
                    damage = CalculatePlayerDamage(Abilities.PowerSlash, hitStatus, enemy);
                }
                return damage;

            // Rogue Skills
            case 5:
                if (Abilities.SwiftCut.cost <= player.magicPoints)
                {
                    print(player.name + " uses Swift Cut");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.SwiftCut);
                    if (hitStatus == 0)
                    {
                        return 0;
                    }
                    damage = CalculatePlayerDamage(Abilities.SwiftCut, hitStatus, enemy);
                }
                return damage;

            case 6:
                if (Abilities.PoisonKnife.cost <= player.magicPoints)
                {
                    print(player.name + " uses Poison Knife");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.PoisonKnife);
                    if (hitStatus == 0)
                    {
                        return 0;
                    }
                    damage = CalculatePlayerDamage(Abilities.PoisonKnife, hitStatus, enemy);
                }
                return damage;

            case 7:
                if (Abilities.MultiStab.cost <= player.magicPoints)
                {
                    print(player.name + " uses Multi-Stab");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.MultiStab);
                    if (hitStatus == 0)
                    {
                        return 0;
                    }
                    damage = CalculatePlayerDamage(Abilities.MultiStab, hitStatus, enemy);
                }
                return damage;

            // Wizard Skills
            case 8:
                if (Abilities.AcidSplash.cost <= player.magicPoints)
                {
                    print(player.name + " uses Acid Splash");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.AcidSplash);
                    if (hitStatus == 0)
                    {
                        return 0;
                    }
                    damage = CalculatePlayerDamage(Abilities.AcidSplash, hitStatus, enemy);
                }
                return damage;

            case 9:
                if (Abilities.EldritchBlast.cost <= player.magicPoints)
                {
                    print(player.name + " uses Eldritch Blash");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.EldritchBlast);
                    if (hitStatus == 0)
                    {
                        return 0;
                    }
                    damage = CalculatePlayerDamage(Abilities.EldritchBlast, hitStatus, enemy);
                }
                return damage;

            case 10:
                if (Abilities.PoisonSpray.cost <= player.magicPoints)
                {
                    print(player.name + " uses Poison Spray");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.PoisonSpray);
                    if (hitStatus == 0)
                    {
                        return 0;
                    }
                    damage = CalculatePlayerDamage(Abilities.PoisonSpray, hitStatus, enemy);
                }
                return damage;

            case 11:
                if (Abilities.MagicMissile.cost <= player.magicPoints)
                {
                    print(player.name + " uses Magic Missile");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.MagicMissile);
                    // Magic Missile always hits
                    if (hitStatus == 0)
                    {
                        hitStatus = 1;
                    }
                    damage = CalculatePlayerDamage(Abilities.MagicMissile, hitStatus, enemy);
                }
                return damage;

            case 12:
                if (Abilities.FlamingSphere.cost <= player.magicPoints)
                {
                    print(player.name + " uses Flaming Sphere");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.FlamingSphere);
                    if (hitStatus == 0)
                    {
                        return 0;
                    }
                    damage = CalculatePlayerDamage(Abilities.FlamingSphere, hitStatus, enemy);
                }
                return damage;

            // Cleric Skills
            case 13:
                if (Abilities.SacredFlame.cost <= player.magicPoints)
                {
                    print(player.name + " uses Sacred Flame");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.SacredFlame);
                    if (hitStatus == 0)
                    {
                        return 0;
                    }
                    damage = CalculatePlayerDamage(Abilities.SacredFlame, hitStatus, enemy);
                }
                return damage;

            case 14:
                if (Abilities.CureWounds.cost <= player.magicPoints)
                {
                    print(player.name + " uses Cure Wounds");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.CureWounds);
                    if (hitStatus == 0)
                    {
                        return 0;
                    }
                    damage = CalculatePlayerDamage(Abilities.CureWounds, hitStatus, enemy);
                }
                return damage;

            case 15:
                if (Abilities.SpiritualWeapon.cost <= player.magicPoints)
                {
                    print(player.name + " uses Spiritual Weapon");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.SpiritualWeapon);
                    if (hitStatus == 0)
                    {
                        return 0;
                    }
                    damage = CalculatePlayerDamage(Abilities.SpiritualWeapon, hitStatus, enemy);
                }
                return damage;
        }


        return damage;
    }


    public static StructsClass.Character[] CureWounds(StructsClass.Character[] players)
    {
        int i = 0;
        for(i=0; i<players.Length; i++)
        {
            players[i].currentHealth = players[i].maxHealth;
        }

        return players;
    }



}





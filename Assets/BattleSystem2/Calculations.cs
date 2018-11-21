using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Calculations : MonoBehaviour
{
    // creates an instance of the battle so the functions can be used for it
    public static Battle battle = new Battle();

    public void Update()
    {
        battle.outputText = GameObject.Find("BattleText").GetComponent<Text>();
    }

    // takes in a stat numbers and gives a bonus number used in several calculations
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

    // calls number convert with reference to the stat the bonus is being calculated from
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
    
    // calculate whether the player hits with an ability
    public static int CalculatePlayerHit(StructsClass.Character player, StructsClass.Enemy enemy, StructsClass.Ability attack)
    {
        int dice = 0;

        System.Random rand = new System.Random();

        dice = (rand.Next(1, 20));

        if(dice == 20)
        {
            battle.outputText.text += ("Critical Hit!\n");
            return 2;
        }

        if (dice == 1)
        {
            battle.outputText.text += ("Critical Miss.\n");
            return -1;
        }



        battle.outputText.text += ("You hit a " + dice + " + " + getModifier(attack.modifier, player) + " against " + enemy.name + "'s armor of " + enemy.armor + "\n");

        dice = dice + getModifier(attack.modifier, player);

        if (dice >= enemy.armor)
        {
            battle.outputText.text += ("You hit.\n");
            return 1;
        }
        else
        {
            battle.outputText.text += ("You Miss.\n");
            return 0;
        }
    }

    // calculate if a player hits with a weapon
    public static int CalculatePlayerWeaponHit(StructsClass.Character player, StructsClass.Enemy enemy)
    {
        int dice = 0;

        System.Random rand = new System.Random();

        dice = (rand.Next(1, 20));

        if (dice == 20)
        {
            battle.outputText.text += ("Critical Hit!\n");
            return 2;
        }

        if (dice == 1)
        {
            battle.outputText.text += ("Critical Miss.\n");
            return -1;
        }



        battle.outputText.text += ("You hit a " + dice + " + " + getModifier(player.weapon.modifier, player) + " against " + enemy.name + "'s armor of " + enemy.armor + "\n");

        dice = dice + getModifier(player.weapon.modifier, player);

        if (dice >= enemy.armor)
        {
            battle.outputText.text += ("You hit.\n");
            return 1;
        }
        else
        {
            battle.outputText.text += ("You Miss.\n");
            return 0;
        }
    }


    // calculate if an enemy attack hits
    public static int CalculateEnemyHit(StructsClass.Character player, StructsClass.EnemyAbility attack)
    {

        int dice = 0;

        System.Random rand = new System.Random();

        dice = (rand.Next(1, 20));

        if (dice == 20)
        {
            battle.outputText.text += ("Critical Hit!\n");
            return 2;
        }

        if (dice == 1)
        {
            battle.outputText.text += ("Critical Miss.\n");
            return -1;
        }

        battle.outputText.text += ("The enemy hit a " + dice + " + " + attack.addedHit + " against " + player.name + "'s armor of " + player.armor.armorValue + "\n");

        dice = dice + attack.addedHit;



        if (dice >= player.armor.armorValue)
        {
            battle.outputText.text += ("They hit.\n");

            if ((dice < player.armor.armorValue + 3) && (player.blocking == 1))
            {
                battle.outputText.text += ("The attack was blocked.\n");
                return 0;
            }

            return 1;
        }
        else
        {
            battle.outputText.text += ("They Missed.\n");
            return 0;
        }
    }


    // calculate player ability damage
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
            battle.outputText.text += ("You did 0 damage.\n");
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
                battle.outputText.text += (enemy.name + " is weak to " + attack.damageType + "\n");
                damage = damage * 2;
            }
        }

        for (i = 0; i < enemy.resistances.Length; i++)
        {
            if (attack.damageType == enemy.resistances[i])
            {
                battle.outputText.text += (enemy.name + " is resistant to " + attack.damageType + "\n");
                damage = damage / 2;
            }
        }

        for (i = 0; i < enemy.immunities.Length; i++)
        {
            if (attack.damageType == enemy.immunities[i])
            {
                battle.outputText.text += (enemy.name + " is immune to " + attack.damageType + "\n");
                damage = 0;
            }
        }

        battle.outputText.text += ("You did " + damage + " damage.\n");
        return damage;
    }

    // calculate player weapon attack damage
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
            battle.outputText.text += ("You did 0 damage.\n");
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
                    battle.outputText.text += (enemy.name + " is weak to " + player.weapon.damageType + "\n");
                    damage = damage * 2;
                }
            }
        }

        for (i = 0; i < enemy.resistances.Length; i++)
        {
            if (player.weapon.damageType == enemy.resistances[i])
            {
                battle.outputText.text += (enemy.name + " is resistant to " + player.weapon.damageType + "\n");
                damage = damage / 2;
            }
        }
        for (i = 0; i < enemy.immunities.Length; i++)
        {
            if (player.weapon.damageType == enemy.immunities[i])
            {
                battle.outputText.text += (enemy.name + " is immune to " + player.weapon.damageType + "\n");
                damage = 0;
            }
        }

        battle.outputText.text += ("You did " + damage + " damage.\n");
        return damage;
    }

    // calculate enemy attack damage
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
            battle.outputText.text += ("They did 0 damage.\n");
            return 0;
        }
        else
        {
            System.Random rand = new System.Random();
            damage = ((rand.Next(1, attack.diceType)) * attack.numOfDice) + attack.addedDamage;
        }


        battle.outputText.text += ("They did " + damage + " damage.\n");
        return damage;
    }



    // determine turn order
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

    // calculate victory gold
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

    // calculate victory experience
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

    // level up characters
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









    // determines what calculations to run for every player action
    public static int DeterminePlayerAction(int action, StructsClass.Character player, StructsClass.Enemy enemy)
    {
        int damage = -1;
        int hitStatus = 0;
        int dice = 0;

        System.Random rand = new System.Random();

        dice = (rand.Next(1, 20));

        switch (action)
        {
            // Normal Attack
            case 1:
                battle.outputText.text += (player.name + " attacks with their " + player.weapon.name + "\n");
                hitStatus = Calculations.CalculatePlayerWeaponHit(player, enemy);
                damage = Calculations.WeaponAttack(player, hitStatus, enemy);
                return damage;

            // Warrior Skills
            case 2:
                if (Abilities.ShieldBash.cost <= player.magicPoints)
                {
                    battle.outputText.text += (player.name + " uses Shield Bash\n");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.ShieldBash);
                    damage = CalculatePlayerDamage(Abilities.ShieldBash, hitStatus, enemy);

                    dice = (rand.Next(1,4));
                    if(dice == 4)
                    {
                        enemy.stun = 1;
                    }
                }
                return damage;

            case 201:
                if (Abilities.AttackStance.cost <= player.magicPoints)
                {
                    player.attackBuff = 4;
                }
                return 0;


            case 3:
                if (Abilities.Thrust.cost <= player.magicPoints)
                {
                    battle.outputText.text += (player.name + " uses Thrust\n");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.Thrust);
                    damage = CalculatePlayerDamage(Abilities.Thrust, hitStatus, enemy);
                }
                return damage;

            case 4:
                if (Abilities.PowerSlash.cost <= player.magicPoints)
                {
                    battle.outputText.text += (player.name + " uses Power Slash\n");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.PowerSlash);
                    damage = CalculatePlayerDamage(Abilities.PowerSlash, hitStatus, enemy);
                }
                return damage;

            // Rogue Skills
            case 5:
                if (Abilities.SwiftCut.cost <= player.magicPoints)
                {
                    battle.outputText.text += (player.name + " uses Swift Cut\n");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.SwiftCut);

                    if(hitStatus == 1)
                    {
                        dice = (rand.Next(1, 2));
                        if (dice == 2)
                        {
                            hitStatus = 2;
                        }
                    }

                    damage = CalculatePlayerDamage(Abilities.SwiftCut, hitStatus, enemy);
                }
                return damage;


            case 202:
                if (Abilities.EvasiveStance.cost <= player.magicPoints)
                {
                    player.defenceBuff = 4;
                }
                return 0;


            case 6:
                if (Abilities.PoisonKnife.cost <= player.magicPoints)
                {
                    battle.outputText.text += (player.name + " uses Poison Knife\n");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.PoisonKnife);
                    damage = CalculatePlayerDamage(Abilities.PoisonKnife, hitStatus, enemy);
                }
                return damage;

            case 7:
                if (Abilities.MultiStab.cost <= player.magicPoints)
                {
                    battle.outputText.text += (player.name + " uses Multi-Stab\n");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.MultiStab);
                    damage = CalculatePlayerDamage(Abilities.MultiStab, hitStatus, enemy);
                }
                return damage;

            // Wizard Skills
            case 8:
                if (Abilities.AcidSplash.cost <= player.magicPoints)
                {
                    battle.outputText.text += (player.name + " uses Acid Splash\n");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.AcidSplash);
                    damage = CalculatePlayerDamage(Abilities.AcidSplash, hitStatus, enemy);
                }
                return damage;

            case 9:
                if (Abilities.EldritchBlast.cost <= player.magicPoints)
                {
                    battle.outputText.text += (player.name + " uses Eldritch Blash\n");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.EldritchBlast);
                    damage = CalculatePlayerDamage(Abilities.EldritchBlast, hitStatus, enemy);
                }
                return damage;

            case 10:
                if (Abilities.PoisonSpray.cost <= player.magicPoints)
                {
                    battle.outputText.text += (player.name + " uses Poison Spray\n");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.PoisonSpray);
                    damage = CalculatePlayerDamage(Abilities.PoisonSpray, hitStatus, enemy);
                }
                return damage;

            case 11:
                if (Abilities.MagicMissile.cost <= player.magicPoints)
                {
                    battle.outputText.text += (player.name + " uses Magic Missile\n");
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
                    battle.outputText.text += (player.name + " uses Flaming Sphere\n");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.FlamingSphere);
                    damage = CalculatePlayerDamage(Abilities.FlamingSphere, hitStatus, enemy);
                }
                return damage;

            // Cleric Skills
            case 13:
                if (Abilities.SacredFlame.cost <= player.magicPoints)
                {
                    battle.outputText.text += (player.name + " uses Sacred Flame\n");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.SacredFlame);
                    damage = CalculatePlayerDamage(Abilities.SacredFlame, hitStatus, enemy);
                }
                return damage;

            case 14:
                if (Abilities.CureWounds.cost <= player.magicPoints)
                {
                    battle.outputText.text += (player.name + " uses Cure Wounds\n");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.CureWounds);
                    damage = CalculatePlayerDamage(Abilities.CureWounds, hitStatus, enemy);
                }
                return damage;

            case 15:
                if (Abilities.SpiritualWeapon.cost <= player.magicPoints)
                {
                    battle.outputText.text += (player.name + " uses Spiritual Weapon\n");
                    hitStatus = CalculatePlayerHit(player, enemy, Abilities.SpiritualWeapon);
                    damage = CalculatePlayerDamage(Abilities.SpiritualWeapon, hitStatus, enemy);
                }
                return damage;
        }


        return damage;
    }

    // unique function for cleric healing ability
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






using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    public static StructsClass.Enemy Goblin;
    public static StructsClass.Enemy Hobgoblin;
    public static StructsClass.Enemy Ghoul;
    public static StructsClass.Enemy MinotaurSkeleton;

    public static StructsClass.EnemyAbility SwordAttack;
    public static StructsClass.EnemyAbility LongswordAttack;
    public static StructsClass.EnemyAbility GhoulClaws;
    public static StructsClass.EnemyAbility Greataxe;
    public static StructsClass.EnemyAbility Horns;

    public static StructsClass.Enemy defineGoblin()
    {
        StructsClass.Enemy GoblinVar;

        GoblinVar.name = "Goblin";
        GoblinVar.str = 8;
        GoblinVar.dex = 14;
        GoblinVar.con = 10;
        GoblinVar.inte = 10;
        GoblinVar.wis = 8;
        GoblinVar.chr = 8;

        GoblinVar.health = 7;
        GoblinVar.armor = 13;
        GoblinVar.rewardExp = 100;
        GoblinVar.rewardGold = 100;

        GoblinVar.weaknesses = new string[1];
        GoblinVar.resistances = new string[1];
        GoblinVar.immunities = new string[1];

        GoblinVar.weaknesses[0] = "none";
        GoblinVar.resistances[0] = "none";
        GoblinVar.immunities[0] = "none";

        GoblinVar.actions = new StructsClass.EnemyAbility[1];
        GoblinVar.actions[0] = SwordAttack;

        return GoblinVar;
    }

    public static void defineEnemies()
    {
        Goblin.name = "Goblin";
        Goblin.str = 8;
        Goblin.dex = 14;
        Goblin.con = 10;
        Goblin.inte = 10;
        Goblin.wis = 8;
        Goblin.chr = 8;

        Goblin.health = 7;
        Goblin.armor = 13;
        Goblin.rewardExp = 100;
        Goblin.rewardGold = 100;

        Goblin.weaknesses = new string[1];
        Goblin.resistances = new string[1];
        Goblin.immunities = new string[1];

        Goblin.weaknesses[0] = "none";
        Goblin.resistances[0] = "none";
        Goblin.immunities[0] = "none";

        Goblin.actions = new StructsClass.EnemyAbility[1];
        Goblin.actions[0] = SwordAttack;




        Hobgoblin.name = "Hobgoblin";
        Hobgoblin.str = 13;
        Hobgoblin.dex = 12;
        Hobgoblin.con = 12;
        Hobgoblin.inte = 10;
        Hobgoblin.wis = 10;
        Hobgoblin.chr = 9;

        Hobgoblin.health = 11;
        Hobgoblin.armor = 15;
        Hobgoblin.rewardExp = 100;
        Hobgoblin.rewardGold = 100;

        Hobgoblin.weaknesses = new string[1];
        Hobgoblin.resistances = new string[1];
        Hobgoblin.immunities = new string[1];

        Hobgoblin.weaknesses[0] = "none";
        Hobgoblin.resistances[0] = "none";
        Hobgoblin.immunities[0] = "none";

        Hobgoblin.actions = new StructsClass.EnemyAbility[1];
        Hobgoblin.actions[0] = LongswordAttack;



        Ghoul.name = "Ghoul";
        Ghoul.str = 13;
        Ghoul.dex = 15;
        Ghoul.con = 10;
        Ghoul.inte = 7;
        Ghoul.wis = 10;
        Ghoul.chr = 6;

        Ghoul.health = 22;
        Ghoul.armor = 15;
        Ghoul.rewardExp = 100;
        Ghoul.rewardGold = 100;

        Ghoul.weaknesses = new string[1];
        Ghoul.resistances = new string[1];
        Ghoul.immunities = new string[1];

        Ghoul.weaknesses[0] = "holy";
        Ghoul.resistances[0] = "none";
        Ghoul.immunities[0] = "none";

        Ghoul.actions = new StructsClass.EnemyAbility[1];
        Ghoul.actions[0] = GhoulClaws;



        MinotaurSkeleton.name = "Ghoul";
        MinotaurSkeleton.str = 18;
        MinotaurSkeleton.dex = 11;
        MinotaurSkeleton.con = 15;
        MinotaurSkeleton.inte = 6;
        MinotaurSkeleton.wis = 8;
        MinotaurSkeleton.chr = 5;

        MinotaurSkeleton.health = 67;
        MinotaurSkeleton.armor = 12;
        MinotaurSkeleton.rewardExp = 100;
        MinotaurSkeleton.rewardGold = 100;

        MinotaurSkeleton.weaknesses = new string[2];
        MinotaurSkeleton.resistances = new string[1];
        MinotaurSkeleton.immunities = new string[1];

        MinotaurSkeleton.weaknesses[0] = "holy";
        MinotaurSkeleton.weaknesses[1] = "bash";
        MinotaurSkeleton.resistances[0] = "none";
        MinotaurSkeleton.immunities[0] = "poison";

        MinotaurSkeleton.actions = new StructsClass.EnemyAbility[2];
        MinotaurSkeleton.actions[0] = Greataxe;
        MinotaurSkeleton.actions[1] = Horns;


    }










    public static void defineEnemyActions()
    {
        SwordAttack.name = "Sword Attack";
        SwordAttack.diceType = 6;
        SwordAttack.numOfDice = 1;
        SwordAttack.addedHit = 4;
        SwordAttack.addedDamage = 2;
        SwordAttack.damageType = "slashing";

        LongswordAttack.name = "Longsword Attack";
        LongswordAttack.diceType = 10;
        LongswordAttack.numOfDice = 1;
        LongswordAttack.addedHit = 3;
        LongswordAttack.addedDamage = 1;
        LongswordAttack.damageType = "slashing";

        GhoulClaws.name = "Claws Attack";
        GhoulClaws.diceType = 6;
        GhoulClaws.numOfDice = 2;
        GhoulClaws.addedHit = 4;
        GhoulClaws.addedDamage = 2;
        GhoulClaws.damageType = "slashing";

        Greataxe.name = "Greataxe Attack";
        Greataxe.diceType = 12;
        Greataxe.numOfDice = 2;
        Greataxe.addedHit = 6;
        Greataxe.addedDamage = 4;
        Greataxe.damageType = "slashing";

        Horns.name = "Horn Attack";
        Horns.diceType = 8;
        Horns.numOfDice = 2;
        Horns.addedHit = 6;
        Horns.addedDamage = 4;
        Horns.damageType = "piercing";
    }



}
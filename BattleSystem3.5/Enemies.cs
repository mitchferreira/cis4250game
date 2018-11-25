using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    public static StructsClass.Enemy Goblin;
    public static StructsClass.Enemy Hobgoblin;
    public static StructsClass.Enemy GobKing;

    public static StructsClass.Enemy Ghast;
    public static StructsClass.Enemy MinotaurSkeleton;
    public static StructsClass.Enemy Wight;

    public static StructsClass.Enemy HeckHound;
    public static StructsClass.Enemy Nightmare;
    public static StructsClass.Enemy FlameE;

    public static StructsClass.EnemyAbility SwordAttack;
    public static StructsClass.EnemyAbility LongswordAttack;

    public static StructsClass.EnemyAbility GhoulClaws;
    public static StructsClass.EnemyAbility Greataxe;
    public static StructsClass.EnemyAbility Horns;
    public static StructsClass.EnemyAbility WLongswordAttack;

    public static StructsClass.EnemyAbility HeckBite;
    public static StructsClass.EnemyAbility HoofStomp;
    public static StructsClass.EnemyAbility FlameTouch;



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

        Goblin.poison = 0;
        Goblin.stun = 0;

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

        Hobgoblin.poison = 0;
        Hobgoblin.stun = 0;

        Hobgoblin.actions = new StructsClass.EnemyAbility[1];
        Hobgoblin.actions[0] = LongswordAttack;


        GobKing.name = "Yeemik, The Goblin King";
        GobKing.str = 15;
        GobKing.dex = 13;
        GobKing.con = 15;
        GobKing.inte = 10;
        GobKing.wis = 10;
        GobKing.chr = 9;

        GobKing.health = 40;
        GobKing.armor = 15;
        GobKing.rewardExp = 100;
        GobKing.rewardGold = 100;

        GobKing.weaknesses = new string[1];
        GobKing.resistances = new string[1];
        GobKing.immunities = new string[1];

        GobKing.weaknesses[0] = "none";
        GobKing.resistances[0] = "none";
        GobKing.immunities[0] = "none";

        GobKing.poison = 0;
        GobKing.stun = 0;

        GobKing.actions = new StructsClass.EnemyAbility[1];
        GobKing.actions[0] = LongswordAttack;



        Ghast.name = "Ghast";
        Ghast.str = 16;
        Ghast.dex = 17;
        Ghast.con = 10;
        Ghast.inte = 11;
        Ghast.wis = 10;
        Ghast.chr = 8;

        Ghast.health = 22;
        Ghast.armor = 13;
        Ghast.rewardExp = 100;
        Ghast.rewardGold = 100;

        Ghast.weaknesses = new string[1];
        Ghast.resistances = new string[1];
        Ghast.immunities = new string[1];

        Ghast.weaknesses[0] = "holy";
        Ghast.resistances[0] = "none";
        Ghast.immunities[0] = "poison";

        Ghast.poison = 0;
        Ghast.stun = 0;

        Ghast.actions = new StructsClass.EnemyAbility[1];
        Ghast.actions[0] = GhoulClaws;



        MinotaurSkeleton.name = "Minotaur Skeleton";
        MinotaurSkeleton.str = 18;
        MinotaurSkeleton.dex = 11;
        MinotaurSkeleton.con = 15;
        MinotaurSkeleton.inte = 6;
        MinotaurSkeleton.wis = 8;
        MinotaurSkeleton.chr = 5;

        MinotaurSkeleton.health = 37;
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

        MinotaurSkeleton.poison = 0;
        MinotaurSkeleton.stun = 0;

        MinotaurSkeleton.actions = new StructsClass.EnemyAbility[2];
        MinotaurSkeleton.actions[0] = Greataxe;
        MinotaurSkeleton.actions[1] = Horns;






        Wight.name = "The White Wight";
        Wight.str = 15;
        Wight.dex = 14;
        Wight.con = 16;
        Wight.inte = 10;
        Wight.wis = 13;
        Wight.chr = 15;

        Wight.health = 50;
        Wight.armor = 13;
        Wight.rewardExp = 100;
        Wight.rewardGold = 100;

        Wight.weaknesses = new string[2];
        Wight.resistances = new string[3];
        Wight.immunities = new string[1];

        Wight.weaknesses[0] = "holy";
        Wight.weaknesses[1] = "magic";
        Wight.resistances[0] = "slashing";
        Wight.resistances[1] = "piercing";
        Wight.resistances[2] = "bashing";
        Wight.immunities[0] = "poison";

        Wight.poison = 0;
        Wight.stun = 0;

        Wight.actions = new StructsClass.EnemyAbility[1];
        Wight.actions[0] = WLongswordAttack;










        HeckHound.name = "Heck Hound";
        HeckHound.str = 17;
        HeckHound.dex = 12;
        HeckHound.con = 14;
        HeckHound.inte = 6;
        HeckHound.wis = 13;
        HeckHound.chr = 6;

        HeckHound.health = 30;
        HeckHound.armor = 15;
        HeckHound.rewardExp = 100;
        HeckHound.rewardGold = 100;

        HeckHound.weaknesses = new string[1];
        HeckHound.resistances = new string[1];
        HeckHound.immunities = new string[1];

        HeckHound.weaknesses[0] = "holy";
        HeckHound.resistances[0] = "none";
        HeckHound.immunities[0] = "fire";

        HeckHound.poison = 0;
        HeckHound.stun = 0;

        HeckHound.actions = new StructsClass.EnemyAbility[1];
        HeckHound.actions[0] = HeckBite;


        // like a evil horse
        Nightmare.name = "Night-mare";
        Nightmare.str = 18;
        Nightmare.dex = 15;
        Nightmare.con = 16;
        Nightmare.inte = 10;
        Nightmare.wis = 13;
        Nightmare.chr = 15;

        Nightmare.health = 40;
        Nightmare.armor = 13;
        Nightmare.rewardExp = 100;
        Nightmare.rewardGold = 100;

        Nightmare.weaknesses = new string[1];
        Nightmare.resistances = new string[1];
        Nightmare.immunities = new string[1];

        Nightmare.weaknesses[0] = "holy";
        Nightmare.resistances[0] = "none";
        Nightmare.immunities[0] = "fire";

        Nightmare.poison = 0;
        Nightmare.stun = 0;

        Nightmare.actions = new StructsClass.EnemyAbility[1];
        Nightmare.actions[0] = HoofStomp;


        FlameE.name = "Lord of Fire and Flames";
        FlameE.str = 10;
        FlameE.dex = 17;
        FlameE.con = 16;
        FlameE.inte = 6;
        FlameE.wis = 10;
        FlameE.chr = 7;

        FlameE.health = 70;
        FlameE.armor = 13;
        FlameE.rewardExp = 100;
        FlameE.rewardGold = 100;

        FlameE.weaknesses = new string[1];
        FlameE.resistances = new string[3];
        FlameE.immunities = new string[2];

        FlameE.weaknesses[0] = "none";
        FlameE.resistances[0] = "slashing";
        FlameE.resistances[1] = "piercing";
        FlameE.resistances[2] = "bashing";
        FlameE.immunities[0] = "fire";
        FlameE.immunities[0] = "poison";

        FlameE.poison = 0;
        FlameE.stun = 0;

        FlameE.actions = new StructsClass.EnemyAbility[1];
        FlameE.actions[0] = FlameTouch;

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
        LongswordAttack.diceType = 8;
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
        Greataxe.numOfDice = 1;
        Greataxe.addedHit = 2;
        Greataxe.addedDamage = 4;
        Greataxe.damageType = "slashing";

        Horns.name = "Horn Attack";
        Horns.diceType = 8;
        Horns.numOfDice = 1;
        Horns.addedHit = 6;
        Horns.addedDamage = 4;
        Horns.damageType = "piercing";

        WLongswordAttack.name = "Longsword Attack";
        WLongswordAttack.diceType = 12;
        WLongswordAttack.numOfDice = 1;
        WLongswordAttack.addedHit = 3;
        WLongswordAttack.addedDamage = 3;
        WLongswordAttack.damageType = "slashing";



        HeckBite.name = "Bite";
        HeckBite.diceType = 6;
        HeckBite.numOfDice = 3;
        HeckBite.addedHit = 5;
        HeckBite.addedDamage = 3;
        HeckBite.damageType = "piercing";

        HoofStomp.name = "Hoof Stomp";
        HoofStomp.diceType = 8;
        HoofStomp.numOfDice = 2;
        HoofStomp.addedHit = 6;
        HoofStomp.addedDamage = 2;
        HoofStomp.damageType = "bashing";


        FlameTouch.name = "Flame Touch";
        FlameTouch.diceType = 6;
        FlameTouch.numOfDice = 2;
        FlameTouch.addedHit = 6;
        FlameTouch.addedDamage = 2;
        FlameTouch.damageType = "fire";
    }



}
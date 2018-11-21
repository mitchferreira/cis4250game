using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    public static StructsClass.Weapon ILongsword;
    public static StructsClass.Weapon IDagger;
    public static StructsClass.Weapon OStaff;
    public static StructsClass.Weapon IMace;

    public static StructsClass.Weapon SLongsword;
    public static StructsClass.Weapon SDagger;
    public static StructsClass.Weapon MStaff;
    public static StructsClass.Weapon SMace;

    public static StructsClass.Weapon MLongsword;
    public static StructsClass.Weapon MDagger;
    public static StructsClass.Weapon WStaff;
    public static StructsClass.Weapon MMace;

    public static StructsClass.Armor Leather;
    public static StructsClass.Armor Chainmail;
    public static StructsClass.Armor Mythril;



    public static void defineWeapons()
    {
        ILongsword.name = "Iron Longsword";
        ILongsword.diceType = 8;
        ILongsword.numOfDice = 1;
        ILongsword.modifier = "strength";
        ILongsword.damageType = "slashing";
        ILongsword.isEquiped = 0;

        IDagger.name = "Iron Dagger";
        IDagger.diceType = 4;
        IDagger.numOfDice = 2;
        IDagger.modifier = "dexterity";
        IDagger.damageType = "piercing";
        IDagger.isEquiped = 0;

        OStaff.name = "Oak Staff";
        OStaff.diceType = 6;
        OStaff.numOfDice = 1;
        OStaff.modifier = "strength";
        OStaff.damageType = "bashing";
        OStaff.isEquiped = 0;

        IMace.name = "Iron Mace";
        IMace.diceType = 8;
        IMace.numOfDice = 1;
        IMace.modifier = "strength";
        IMace.damageType = "bashing";
        IMace.isEquiped = 0;



        SLongsword.name = "Steel Longsword";
        SLongsword.diceType = 10;
        SLongsword.numOfDice = 1;
        SLongsword.modifier = "strength";
        SLongsword.damageType = "slashing";
        SLongsword.isEquiped = 0;

        SDagger.name = "Steel Dagger";
        SDagger.diceType = 6;
        SDagger.numOfDice = 2;
        SDagger.modifier = "dexterity";
        SDagger.damageType = "piercing";
        SDagger.isEquiped = 0;

        MStaff.name = "Mahogany Staff";
        MStaff.diceType = 8;
        MStaff.numOfDice = 1;
        MStaff.modifier = "strength";
        MStaff.damageType = "bashing";
        MStaff.isEquiped = 0;

        SMace.name = "Steel Mace";
        SMace.diceType = 10;
        SMace.numOfDice = 1;
        SMace.modifier = "strength";
        SMace.damageType = "bashing";
        SMace.isEquiped = 0;




        MLongsword.name = "Mythril Longsword";
        MLongsword.diceType = 12;
        MLongsword.numOfDice = 1;
        MLongsword.modifier = "strength";
        MLongsword.damageType = "slashing";
        MLongsword.isEquiped = 0;

        MDagger.name = "Mythril Dagger";
        MDagger.diceType = 8;
        MDagger.numOfDice = 2;
        MDagger.modifier = "dexterity";
        MDagger.damageType = "piercing";
        MDagger.isEquiped = 0;

        WStaff.name = "Wizard Staff";
        WStaff.diceType = 10;
        WStaff.numOfDice = 1;
        WStaff.modifier = "strength";
        WStaff.damageType = "bashing";
        WStaff.isEquiped = 0;

        MMace.name = "Mythril Mace";
        MMace.diceType = 12;
        MMace.numOfDice = 1;
        MMace.modifier = "strength";
        MMace.damageType = "bashing";
        MMace.isEquiped = 0;
    }

    public static void defineArmor()
    {
        Leather.name = "Leather Armor";
        Leather.armorValue = 11;
        Leather.damageResist = "none";
        Leather.isEquiped = 0;

        Chainmail.name = "Chainmail";
        Chainmail.armorValue = 13;
        Chainmail.damageResist = "none";
        Chainmail.isEquiped = 0;

        Mythril.name = "Mythril Armor";
        Mythril.armorValue = 16;
        Mythril.damageResist = "none";
        Mythril.isEquiped = 0;
    }
}

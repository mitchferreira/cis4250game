using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour {

    public static StructsClass.Weapon Longsword;
    public static StructsClass.Weapon Dagger;
    public static StructsClass.Weapon Staff;
    public static StructsClass.Weapon Mace;

    public static StructsClass.Armor Leather;



    public static void defineWeapons()
    {
        Longsword.name = "Longsword";
        Longsword.diceType = 8;
        Longsword.numOfDice = 1;
        Longsword.modifier = "strength";
        Longsword.damageType = "slashing";

        Dagger.name = "Dagger";
        Dagger.diceType = 4;
        Dagger.numOfDice = 2;
        Dagger.modifier = "dexterity";
        Dagger.damageType = "piercing";

        Staff.name = "Staff";
        Staff.diceType = 6;
        Staff.numOfDice = 1;
        Staff.modifier = "strength";
        Staff.damageType = "bash";

        Mace.name = "Mace";
        Mace.diceType = 6;
        Mace.numOfDice = 1;
        Mace.modifier = "strength";
        Mace.damageType = "bash";
    }

    public static void defineArmor()
    {
        Leather.name = "Leather Armor";
        Leather.armorValue = 11;
        Leather.damageResist = "none";
    }
}

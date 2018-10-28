using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour {

    public static StructsClass.Ability ShieldBash;
    public static StructsClass.Ability Thrust;
    public static StructsClass.Ability PowerSlash;

    public static StructsClass.Ability SwiftCut;
    public static StructsClass.Ability PoisonKnife;
    public static StructsClass.Ability MultiStab;

    public static StructsClass.Ability AcidSplash;
    public static StructsClass.Ability EldrictchBlast;
    public static StructsClass.Ability PoisonSpray;
    public static StructsClass.Ability MagicMissile;
    public static StructsClass.Ability FlamingSphere;

    public static StructsClass.Ability SacredFlame;
    public static StructsClass.Ability CureWounds;
    public static StructsClass.Ability SpiritualWeapon;

    public void defineActions()
    {
        ShieldBash.name = "Shield Bash";
        ShieldBash.cost = 1;
        ShieldBash.diceType = 6;
        ShieldBash.numOfDice = 1;
        ShieldBash.modifier = "strength";
        ShieldBash.damageType = "bash";

        Thrust.name = "Thrust";
        Thrust.cost = 2;
        Thrust.diceType = 8;
        Thrust.numOfDice = 1;
        Thrust.modifier = "strength";
        Thrust.damageType = "piercing";

        PowerSlash.name = "Power Slash";
        PowerSlash.cost = 3;
        PowerSlash.diceType = 12;
        PowerSlash.numOfDice = 1;
        PowerSlash.modifier = "strength";
        PowerSlash.damageType = "slashing";






        SwiftCut.name = "Swift Cut";
        SwiftCut.cost = 1;
        SwiftCut.diceType = 6;
        SwiftCut.numOfDice = 1;
        SwiftCut.modifier = "dexterity";
        SwiftCut.damageType = "slashing";

        PoisonKnife.name = "Poison Knife";
        PoisonKnife.cost = 2;
        PoisonKnife.diceType = 8;
        PoisonKnife.numOfDice = 1;
        PoisonKnife.modifier = "dexterity";
        PoisonKnife.damageType = "poison";

        MultiStab.name = "Multi-Stab";
        MultiStab.cost = 3;
        MultiStab.diceType = 4;
        MultiStab.numOfDice = 3;
        MultiStab.modifier = "dexterity";
        MultiStab.damageType = "piercing";






        AcidSplash.name = "Acid Splash";
        AcidSplash.cost = 1;
        AcidSplash.diceType = 6;
        AcidSplash.numOfDice = 1;
        AcidSplash.modifier = "intellidence";
        AcidSplash.damageType = "acid";

        EldrictchBlast.name = "Eldricth Blast";
        EldrictchBlast.cost = 1;
        EldrictchBlast.diceType = 10;
        EldrictchBlast.numOfDice = 1;
        EldrictchBlast.modifier = "intellidence";
        EldrictchBlast.damageType = "magic";

        PoisonSpray.name = "Poison Spray";
        PoisonSpray.cost = 2;
        PoisonSpray.diceType = 12;
        PoisonSpray.numOfDice = 1;
        PoisonSpray.modifier = "intellidence";
        PoisonSpray.damageType = "poison";

        MagicMissile.name = "Magic Missile";
        MagicMissile.cost = 2;
        MagicMissile.diceType = 4;
        MagicMissile.numOfDice = 3;
        MagicMissile.modifier = "intellidence";
        MagicMissile.damageType = "magic";

        FlamingSphere.name = "Flaming Sphere";
        FlamingSphere.cost = 3;
        FlamingSphere.diceType = 6;
        FlamingSphere.numOfDice = 2;
        FlamingSphere.modifier = "intellidence";
        FlamingSphere.damageType = "fire";








        SacredFlame.name = "Sacred Flame";
        SacredFlame.cost = 1;
        SacredFlame.diceType = 8;
        SacredFlame.numOfDice = 1;
        SacredFlame.modifier = "wisdom";
        SacredFlame.damageType = "holy";

        CureWounds.name = "Cure Wounds";
        CureWounds.cost = 2;
        CureWounds.diceType = 8;
        CureWounds.numOfDice = 1;
        CureWounds.modifier = "wisdom";
        CureWounds.damageType = "cure";

        SpiritualWeapon.name = "Spiritual Weapon";
        SpiritualWeapon.cost = 3;
        SpiritualWeapon.diceType = 1;
        SpiritualWeapon.numOfDice = 10;
        SpiritualWeapon.modifier = "wisdom";
        SpiritualWeapon.damageType = "magic";

    }
}

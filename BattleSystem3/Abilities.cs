using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : MonoBehaviour {

    public static StructsClass.Ability ShieldBash;
    public static StructsClass.Ability AttackStance;
    public static StructsClass.Ability Thrust;
    public static StructsClass.Ability PowerSlash;

    public static StructsClass.Ability SwiftCut;
    public static StructsClass.Ability EvasiveStance;
    public static StructsClass.Ability PoisonKnife;
    public static StructsClass.Ability MultiStab;

    public static StructsClass.Ability AcidSplash;
    public static StructsClass.Ability EldritchBlast;
    public static StructsClass.Ability PoisonSpray;
    public static StructsClass.Ability MagicMissile;
    public static StructsClass.Ability FlamingSphere;

    public static StructsClass.Ability SacredFlame;
    public static StructsClass.Ability CureWounds;
    public static StructsClass.Ability SpiritualWeapon;

    public static void defineActions()
    {
        ShieldBash.name = "Shield Bash";
        ShieldBash.cost = 1;
        ShieldBash.diceType = 6;
        ShieldBash.numOfDice = 1;
        ShieldBash.modifier = "strength";
        ShieldBash.damageType = "bashing";
        ShieldBash.description = "Bash the enemy for a chance to stun. Cost: 1, Damage: 1d6.";

        AttackStance.name = "Attacking Stance";
        AttackStance.cost = 1;
        AttackStance.diceType = 0;
        AttackStance.numOfDice = 0;
        AttackStance.modifier = "strength";
        AttackStance.damageType = "bashing";
        AttackStance.description = "Take a stance to increase attack for 3 turns. Cost: 1.";

        Thrust.name = "Thrust";
        Thrust.cost = 2;
        Thrust.diceType = 8;
        Thrust.numOfDice = 1;
        Thrust.modifier = "strength";
        Thrust.damageType = "piercing";
        Thrust.description = "Stab at the enemy. Cost: 2, Damage: 1d8.";

        PowerSlash.name = "Power Slash";
        PowerSlash.cost = 3;
        PowerSlash.diceType = 12;
        PowerSlash.numOfDice = 1;
        PowerSlash.modifier = "strength";
        PowerSlash.damageType = "slashing";
        PowerSlash.description = "Strike a mighty blow. Cost 3, Damage 1d12.";





        SwiftCut.name = "Swift Cut";
        SwiftCut.cost = 1;
        SwiftCut.diceType = 6;
        SwiftCut.numOfDice = 1;
        SwiftCut.modifier = "dexterity";
        SwiftCut.damageType = "slashing";
        SwiftCut.description = "Deliver a quick slash with increased crit chance. Cost: 1, Damage: 1d6.";

        EvasiveStance.name = "Evasive Stance";
        EvasiveStance.cost = 1;
        EvasiveStance.diceType = 0;
        EvasiveStance.numOfDice = 0;
        EvasiveStance.modifier = "strength";
        EvasiveStance.damageType = "bashing";
        EvasiveStance.description = "Take a stance to increase defence for 3 turns. Cost: 1.";

        PoisonKnife.name = "Poison Knife";
        PoisonKnife.cost = 2;
        PoisonKnife.diceType = 8;
        PoisonKnife.numOfDice = 1;
        PoisonKnife.modifier = "dexterity";
        PoisonKnife.damageType = "poison";
        PoisonKnife.description = "Stab the enemy for a chance to poison. Cost: 2, Damage: 1d8.";

        MultiStab.name = "Multi-Stab";
        MultiStab.cost = 3;
        MultiStab.diceType = 4;
        MultiStab.numOfDice = 3;
        MultiStab.modifier = "dexterity";
        MultiStab.damageType = "piercing";
        MultiStab.description = "Deliver multiple stabs. Cost: 3, Damage 3d4.";






        AcidSplash.name = "Acid Splash";
        AcidSplash.cost = 1;
        AcidSplash.diceType = 6;
        AcidSplash.numOfDice = 1;
        AcidSplash.modifier = "intellidence";
        AcidSplash.damageType = "acid";
        AcidSplash.description = "Splash the enemy with acid. Cost: 1, Damage: 1d6.";

        EldritchBlast.name = "Eldritch Blast";
        EldritchBlast.cost = 1;
        EldritchBlast.diceType = 10;
        EldritchBlast.numOfDice = 1;
        EldritchBlast.modifier = "intellidence";
        EldritchBlast.damageType = "magic";
        EldritchBlast.description = "Blast the enemy with eldritch energy. Cost: 1, Damage: 1d10.";

        PoisonSpray.name = "Poison Spray";
        PoisonSpray.cost = 2;
        PoisonSpray.diceType = 12;
        PoisonSpray.numOfDice = 1;
        PoisonSpray.modifier = "intellidence";
        PoisonSpray.damageType = "poison";
        PoisonSpray.description = "Spray the enemy with poison. Cost: 2, Damage: 1d12.";

        MagicMissile.name = "Magic Missile";
        MagicMissile.cost = 2;
        MagicMissile.diceType = 4;
        MagicMissile.numOfDice = 3;
        MagicMissile.modifier = "intellidence";
        MagicMissile.damageType = "magic";
        MagicMissile.description = "Fire magic bolts that never miss. Cost: 2, Damage: 3d4";

        FlamingSphere.name = "Flaming Sphere";
        FlamingSphere.cost = 3;
        FlamingSphere.diceType = 6;
        FlamingSphere.numOfDice = 2;
        FlamingSphere.modifier = "intellidence";
        FlamingSphere.damageType = "fire";
        FlamingSphere.description = "Unleash a flaming sphere. Cost: 3, Damage: 2d6.";








        SacredFlame.name = "Sacred Flame";
        SacredFlame.cost = 1;
        SacredFlame.diceType = 8;
        SacredFlame.numOfDice = 1;
        SacredFlame.modifier = "wisdom";
        SacredFlame.damageType = "holy";
        SacredFlame.description = "Strike with holy fire. Cost: 1, Damage: 1d8";

        CureWounds.name = "Cure Wounds";
        CureWounds.cost = 2;
        CureWounds.diceType = 8;
        CureWounds.numOfDice = 1;
        CureWounds.modifier = "wisdom";
        CureWounds.damageType = "cure";
        CureWounds.description = "Heal the wounds of your allies. Cost: 2, Heals fully";

        SpiritualWeapon.name = "Spiritual Weapon";
        SpiritualWeapon.cost = 3;
        SpiritualWeapon.diceType = 1;
        SpiritualWeapon.numOfDice = 10;
        SpiritualWeapon.modifier = "wisdom";
        SpiritualWeapon.damageType = "magic";
        SpiritualWeapon.description = "Strike with a magical weapon. Cost: 3, Damage: 1d10.";

    }
}

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Definitions : MonoBehaviour
{

    /*
     *
     *   Level 1 Characters
     *
     *
     */
    public static Battle battle = new Battle();

    public void Update()
    {
        battle.outputText = GameObject.Find("BattleText").GetComponent<Text>();
    }

    public static StructsClass.Character defineStartingWarrior()
    {
        StructsClass.Character Warrior;

        Warrior.name = "Kent";
        Warrior.charClass = "Warrior";
        Warrior.level = 1;
        Warrior.exp = 0;
        Warrior.str = 16;
        Warrior.dex = 14;
        Warrior.con = 16;
        Warrior.inte = 10;
        Warrior.wis = 12;
        Warrior.chr = 14;

        Warrior.hitDiceValue = 6;
        Warrior.maxHealth = (Warrior.level * Warrior.hitDiceValue) + Calculations.numberConvert(Warrior.con);
        Warrior.currentHealth = Warrior.maxHealth;
        Warrior.magicPoints = 10;

        //Warrior.statusEffects = "none";
        Warrior.blocking = 0;
        Warrior.attackBuff = 0;
        Warrior.defenceBuff = 0;

        Warrior.weapon = Items.ILongsword;
        Warrior.armor = Items.Leather;

        Warrior.actions = new StructsClass.Ability[1];
        Warrior.actions[0] = Abilities.ShieldBash;

        return Warrior;
    }

    public static StructsClass.Character defineStartingRogue()
    {

        StructsClass.Character Rogue;

        Rogue.name = "Joseph";
        Rogue.charClass = "Rogue";
        Rogue.level = 1;
        Rogue.exp = 0;
        Rogue.str = 12;
        Rogue.dex = 18;
        Rogue.con = 12;
        Rogue.inte = 14;
        Rogue.wis = 12;
        Rogue.chr = 16;
        Rogue.hitDiceValue = 5;
        Rogue.maxHealth = (Rogue.level * Rogue.hitDiceValue) + Calculations.numberConvert(Rogue.con);
        Rogue.currentHealth = Rogue.maxHealth;
        Rogue.magicPoints = 10;

        //Warrior.statusEffects = "none";
        Rogue.blocking = 0;
        Rogue.attackBuff = 0;
        Rogue.defenceBuff = 0;

        Rogue.weapon = Items.IDagger;
        Rogue.armor = Items.Leather;

        Rogue.actions = new StructsClass.Ability[1];
        Rogue.actions[0] = Abilities.SwiftCut;

        return Rogue;
    }

    public static StructsClass.Character defineStartingWizard()
    {
        StructsClass.Character Wizard;

        Wizard.name = "Scott";
        Wizard.charClass = "Wizard";
        Wizard.level = 1;
        Wizard.exp = 0;
        Wizard.str = 10;
        Wizard.dex = 12;
        Wizard.con = 12;
        Wizard.inte = 18;
        Wizard.wis = 18;
        Wizard.chr = 14;
        Wizard.hitDiceValue = 4;
        Wizard.maxHealth = (Wizard.level * Wizard.hitDiceValue) + Calculations.numberConvert(Wizard.con);
        Wizard.currentHealth = Wizard.maxHealth;
        Wizard.magicPoints = 10;

        //Warrior.statusEffects = "none";
        Wizard.blocking = 0;
        Wizard.attackBuff = 0;
        Wizard.defenceBuff = 0;

        Wizard.weapon = Items.OStaff;
        Wizard.armor = Items.Leather;

        Wizard.actions = new StructsClass.Ability[3];
        Wizard.actions[0] = Abilities.AcidSplash;
        Wizard.actions[1] = Abilities.EldritchBlast;
        Wizard.actions[2] = Abilities.PoisonSpray;

        return Wizard;
    }

    public static StructsClass.Character defineStartingCleric()
    {
        StructsClass.Character Cleric;

        Cleric.name = "Mitchell";
        Cleric.charClass = "Cleric";
        Cleric.level = 1;
        Cleric.exp = 0;
        Cleric.str = 14;
        Cleric.dex = 12;
        Cleric.con = 16;
        Cleric.inte = 16;
        Cleric.wis = 16;
        Cleric.chr = 14;
        Cleric.hitDiceValue = 5;
        Cleric.maxHealth = (Cleric.level * Cleric.hitDiceValue) + Calculations.numberConvert(Cleric.con);
        Cleric.currentHealth = Cleric.maxHealth;
        Cleric.magicPoints = 10;

        //Warrior.statusEffects = "none";
        Cleric.blocking = 0;
        Cleric.attackBuff = 0;
        Cleric.defenceBuff = 0;

        Cleric.weapon = Items.IMace;
        Cleric.armor = Items.Leather;

        Cleric.actions = new StructsClass.Ability[1];
        Cleric.actions[0] = Abilities.SacredFlame;

        return Cleric;
    }






    /*
     *
     *   Level 2 Characters
     *
     *
     */


    public static StructsClass.Character levelTwoWarrior(StructsClass.Character Warrior)
    {
        Warrior.level = 2;
        Warrior.exp = 0;
        Warrior.str = 18;
        Warrior.con = 18;

        Warrior.maxHealth = (Warrior.level * Warrior.hitDiceValue) + Calculations.numberConvert(Warrior.con);
        Warrior.currentHealth = Warrior.maxHealth;

        Warrior.actions = new StructsClass.Ability[2];
        Warrior.actions[0] = Abilities.ShieldBash;
        Warrior.actions[1] = Abilities.Thrust;

        battle.outputText.text += ("Warrior " + Warrior.name + " leveled up\n");
        battle.outputText.text += ("Strength +2\n");
        battle.outputText.text += ("Constitution +2\n");
        battle.outputText.text += ("Health went up\n");
        battle.outputText.text += ("Learned 'Thrust' skill\n");


        return Warrior;
    }

    public static StructsClass.Character levelTwoRogue(StructsClass.Character Rogue)
    {
        Rogue.level = 2;
        Rogue.exp = 0;
        Rogue.str = 14;
        Rogue.con = 14;

        Rogue.maxHealth = (Rogue.level * Rogue.hitDiceValue) + Calculations.numberConvert(Rogue.con);
        Rogue.currentHealth = Rogue.maxHealth;

        Rogue.actions = new StructsClass.Ability[2];
        Rogue.actions[0] = Abilities.SwiftCut;
        Rogue.actions[1] = Abilities.PoisonKnife;

        battle.outputText.text += ("Rogue " + Rogue.name + " leveled up\n");
        battle.outputText.text += ("Strength +2\n");
        battle.outputText.text += ("Constitution +2\n");
        battle.outputText.text += ("Health went up\n");
        battle.outputText.text += ("Learned 'Poison Knife' skill\n");

        return Rogue;
    }

    public static StructsClass.Character levelTwoWizard(StructsClass.Character Wizard)
    {
        Wizard.level = 2;
        Wizard.exp = 0;
        Wizard.str = 12;
        Wizard.con = 14;

        Wizard.maxHealth = (Wizard.level * Wizard.hitDiceValue) + Calculations.numberConvert(Wizard.con);
        Wizard.currentHealth = Wizard.maxHealth;

        Wizard.actions = new StructsClass.Ability[4];
        Wizard.actions[0] = Abilities.AcidSplash;
        Wizard.actions[1] = Abilities.EldritchBlast;
        Wizard.actions[2] = Abilities.PoisonSpray;
        Wizard.actions[3] = Abilities.MagicMissile;

        battle.outputText.text += ("Wizard " + Wizard.name + " leveled up\n");
        battle.outputText.text += ("Strength +2\n");
        battle.outputText.text += ("Constitution +2\n");
        battle.outputText.text += ("Health went up\n");
        battle.outputText.text += ("Learned 'Magic Missile' skill\n");

        return Wizard;
    }

    public static StructsClass.Character levelTwoCleric(StructsClass.Character Cleric)
    {
        Cleric.level = 2;
        Cleric.exp = 0;
        Cleric.str = 16;
        Cleric.wis = 18;

        Cleric.maxHealth = (Cleric.level * Cleric.hitDiceValue) + Calculations.numberConvert(Cleric.con);
        Cleric.currentHealth = Cleric.maxHealth;

        Cleric.actions = new StructsClass.Ability[2];
        Cleric.actions[0] = Abilities.SacredFlame;
        Cleric.actions[1] = Abilities.CureWounds;

        battle.outputText.text += ("Cleric " + Cleric.name + " leveled up\n");
        battle.outputText.text += ("Strength +2\n");
        battle.outputText.text += ("Wisdom +2\n");
        battle.outputText.text += ("Health went up\n");
        battle.outputText.text += ("Learned 'Cure Wounds' skill\n");

        return Cleric;
    }



    /*
 *
 *   Level 3 Characters
 *
 *
 */


    public static StructsClass.Character levelThreeWarrior(StructsClass.Character Warrior)
    {
        Warrior.level = 3;
        Warrior.exp = 0;
        Warrior.str = 20;
        Warrior.dex = 16;

        Warrior.maxHealth = (Warrior.level * Warrior.hitDiceValue) + Calculations.numberConvert(Warrior.con);
        Warrior.currentHealth = Warrior.maxHealth;

        Warrior.actions = new StructsClass.Ability[3];
        Warrior.actions[0] = Abilities.ShieldBash;
        Warrior.actions[1] = Abilities.Thrust;
        Warrior.actions[2] = Abilities.PowerSlash;

        battle.outputText.text += ("Warrior " + Warrior.name + " leveled up\n");
        battle.outputText.text += ("Strength +2\n");
        battle.outputText.text += ("Dexterity +2\n");
        battle.outputText.text += ("Health went up\n");
        battle.outputText.text += ("Learned 'Power Slash' skill\n");

        return Warrior;
    }

    public static StructsClass.Character levelThreeRogue(StructsClass.Character Rogue)
    {
        Rogue.level = 3;
        Rogue.exp = 0;
        Rogue.dex = 20;
        Rogue.con = 16;

        Rogue.maxHealth = (Rogue.level * Rogue.hitDiceValue) + Calculations.numberConvert(Rogue.con);
        Rogue.currentHealth = Rogue.maxHealth;

        Rogue.actions = new StructsClass.Ability[3];
        Rogue.actions[0] = Abilities.SwiftCut;
        Rogue.actions[1] = Abilities.PoisonKnife;
        Rogue.actions[2] = Abilities.MultiStab;

        battle.outputText.text += ("Rogue " + Rogue.name + " leveled up\n");
        battle.outputText.text += ("Dexterity +2\n");
        battle.outputText.text += ("Constitution +2\n");
        battle.outputText.text += ("Health went up\n");
        battle.outputText.text += ("Learned 'Multi-Stab' skill\n");

        return Rogue;
    }

    public static StructsClass.Character levelThreeWizard(StructsClass.Character Wizard)
    {
        Wizard.level = 3;
        Wizard.exp = 0;
        Wizard.str = 12;
        Wizard.inte = 20;

        Wizard.maxHealth = (Wizard.level * Wizard.hitDiceValue) + Calculations.numberConvert(Wizard.con);
        Wizard.currentHealth = Wizard.maxHealth;

        Wizard.actions = new StructsClass.Ability[5];
        Wizard.actions[0] = Abilities.AcidSplash;
        Wizard.actions[1] = Abilities.EldritchBlast;
        Wizard.actions[2] = Abilities.PoisonSpray;
        Wizard.actions[3] = Abilities.MagicMissile;
        Wizard.actions[4] = Abilities.FlamingSphere;

        battle.outputText.text += ("Wizard " + Wizard.name + " leveled up\n");
        battle.outputText.text += ("Strength +2\n");
        battle.outputText.text += ("Intelligence +2\n");
        battle.outputText.text += ("Health went up\n");
        battle.outputText.text += ("Learned 'FlamingSphere' skill\n");

        return Wizard;
    }

    public static StructsClass.Character levelThreeCleric(StructsClass.Character Cleric)
    {
        Cleric.level = 3;
        Cleric.exp = 0;
        Cleric.con = 18;
        Cleric.wis = 20;

        Cleric.maxHealth = (Cleric.level * Cleric.hitDiceValue) + Calculations.numberConvert(Cleric.con);
        Cleric.currentHealth = Cleric.maxHealth;

        Cleric.actions = new StructsClass.Ability[3];
        Cleric.actions[0] = Abilities.SacredFlame;
        Cleric.actions[1] = Abilities.CureWounds;
        Cleric.actions[2] = Abilities.SpiritualWeapon;

        battle.outputText.text += ("Cleric " + Cleric.name + " leveled up\n");
        battle.outputText.text += ("Constitution +2\n");
        battle.outputText.text += ("Wisdom +2\n");
        battle.outputText.text += ("Health went up\n");
        battle.outputText.text += ("Learned 'Spiritual Weapon' skill\n");

        return Cleric;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetermineAction : MonoBehaviour
{

    public void Block()
    {
        Battle.playerAttack = 0;
    }

    public void BasicAttack()
    {
        
        Battle.playerAttack = 1;
        

    }

    public void ShieldBash()
    {
        Battle.playerAttack = 2;
    }

    public void AttackStance()
    {
        Battle.playerAttack = 3;
    }

    public void Thrust()
    {
        Battle.playerAttack = 4;
    }

    public void PowerSlash()
    {
        Battle.playerAttack = 5;
    }

    public void SwiftCut()
    {
        Battle.playerAttack = 6;
    }

    public void EvasiveStance()
    {
        Battle.playerAttack = 7;
    }

    public void PoisonKnife()
    {
        Battle.playerAttack = 8;
    }

    public void MultiStab()
    {
        Battle.playerAttack = 9;
    }

    public void AcidSplash()
    {
        Battle.playerAttack = 10;
    }

    public void PoisonSpray()
    {
        Battle.playerAttack = 11;
    }

    public void MagicMissile()
    {
        Battle.playerAttack = 12;
    }

    public void FlamingSphere()
    {
        Battle.playerAttack = 13;
    }

    public void SacredFlame()
    {
        Battle.playerAttack = 14;
    }

    public void CureWounds()
    {
        Battle.playerAttack = 15;
    }

    public void SpiritualWeapon()
    {
        Battle.playerAttack = 6;
    }

}
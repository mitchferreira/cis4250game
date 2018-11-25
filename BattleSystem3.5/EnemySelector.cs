using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelector : MonoBehaviour
{




    public void attackEnemy1()
    {

        Battle.enemySelector = 1;
        //print(Battle.playerAttack);

    }

    public void attackEnemy2()
    {

        Battle.enemySelector = 2;

    }

    // Update is called once per frame
    void Update()
    {

    }





}
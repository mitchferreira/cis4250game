using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySelector : MonoBehaviour
{
    public GameObject attack_panel;



    public void attackEnemy1()
    {

        Battle.enemySelector = 0;
        Battle.flag = 1;
        attack_panel.SetActive(false);
        //print(Battle.playerAttack);
        //Debug.Log("Attacking enemy 1");

    }

    public void attackEnemy2()
    {

        Battle.enemySelector = 1;
        Battle.flag = 1;
        attack_panel.SetActive(false);
        //Debug.Log("Attacking enemy 2");

    }

    // Update is called once per frame
    void Update()
    {

    }





}
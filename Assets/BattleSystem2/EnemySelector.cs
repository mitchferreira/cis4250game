using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySelector : MonoBehaviour
{
    public GameObject attack_panel;
    public Image character;


    public void attackEnemy1()
    {

        Battle.enemySelector = 0;
        Battle.flag = 1;
        attack_panel.SetActive(false);
        /* if(Battle.whoseTurnIsIt == 1){

            character = GameObject.Find("Warrior").GetComponent<Image>();
            Debug.Log("Warrior Attack");
        }
        if(Battle.whoseTurnIsIt == 2){
            character = GameObject.Find("Rogue").GetComponent<Image>();
            Debug.Log("Rogue Attack");
        }
        if(Battle.whoseTurnIsIt == 3){
            character = GameObject.Find("Wizard").GetComponent<Image>();
            Debug.Log("Wizard Attack");
        }
        if(Battle.whoseTurnIsIt == 4){
            character = GameObject.Find("Cleric").GetComponent<Image>();
            Debug.Log("Cleric Attack");
        }
        Vector2 pos = character.transform.position;
        character.transform.position =  new Vector2(pos.x - 100, pos.y);
        int seconds = 0;
        while(seconds++ < 1000000)
            Debug.Log(seconds);
        character.transform.position = new Vector2(pos.x, pos.y);/* 
        //print(Battle.playerAttack);
        //Debug.Log("Attacking enemy 1");*/

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
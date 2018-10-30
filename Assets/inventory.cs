using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        Text text = GameObject.Find("inventory_text").GetComponent<Text>();

        text.text = "";

        Debug.Log("HALLLLO");

        int size = PlayerPrefs.GetInt("inventory_size");

        Debug.Log(size);

        for (int i = 0; i < size; i++)
        {
            string item = PlayerPrefs.GetString("item #" + i);

            Debug.Log(item);

            string [] values = item.Split(":"[0]);
            Debug.Log(values);

            text.text += "Name: " + values[0] + "\nType: " + values[1] + "\nDescription: " + values[2] +"\nEquipped: ";

            if (values[3][0] == 'T')
            {
                text.text += "yes";
            }
            else
            {
                text.text += "no";
            }
        }
        

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

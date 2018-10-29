using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory : MonoBehaviour {

    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("player");

        List <string> items = player.GetComponent<PlayerScript>().GetComponent < List<string> > ();
        Text text = GameObject.Find("inventory_text").GetComponent<Text>();

        Debug.Log("HALLLLO");
        Debug.Log(items[5]);
        Debug.Log(items);

        foreach (string item in items)
        {
            string [] values = item.Split(","[0]);

            Debug.Log(values);

            text.text = "name: " + values[0] + "\ntype: " + values[1] + "\ndescription: " + values[2] +"\nEquipped: ";

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventory_correct : MonoBehaviour
{
    public Text inventoryText;
    public string text;

    //On update 
    void Update ()
    {
        int size = PlayerPrefs.GetInt("inventory_size");

        Debug.Log(size);

        for (int i = 0; i < size; i++)
        {
            string item = PlayerPrefs.GetString("item #" + i);

            Debug.Log(item);

            string[] values = item.Split(':');
            Debug.Log(values);

            text = "Name: " + values[0] + "\nType: " + values[1] + "\nDescription: " + values[2] + "\nEquipped: ";

            Debug.Log(inventoryText.text);


            Debug.Log(values[5]);
            if (values[5][0] == 'T')
            {
                text += "yes";
            }
            else
            {
                text += "no";
            }

            inventoryText.text = text;
        }
    }
}

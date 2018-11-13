using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class inventory_correct : MonoBehaviour
{
    public string text;


    void hide_radio_btn(GameObject g, string name)
    {
        g.transform.Find(name + "/Label").GetComponent<Text>().text = "";
        g.transform.Find(name + "/Background").GetComponent<Image>().enabled = false;
        g.transform.Find(name + "/Background/Checkmark").GetComponent<Image>().enabled = false;
    }

    void show_radio_btn(GameObject g, string name, string label_text)
    {
        g.transform.Find(name + "/Label").GetComponent<Text>().text = label_text;
        g.transform.Find(name + "/Background").GetComponent<Image>().enabled = true;
        g.transform.Find(name + "/Background/Checkmark").GetComponent<Image>().enabled = true;
    }

    /*Setting up the listeners for the radio buttons*/
    /*slots are 1-indexed and items are 0-indexed, will change later*/
    void Start ()
    {
        for (int i = 0; i < 18; i++)
        {
            GameObject slot = GameObject.Find("slot_" + (i + 1));

            foreach(Toggle radio_button in slot.GetComponentsInChildren<Toggle>())
            {
                if(radio_button.name == "delete")
                {
                    radio_button.onValueChanged.AddListener(delegate 
                    {
                        string item = PlayerPrefs.GetString("item #" + i);

                        PlayerPrefs.DeleteKey("item #" + i);

                        item = PlayerPrefs.GetString("item #" + i);

                        int size = PlayerPrefs.GetInt("inventory_size");

                        GameObject slot1;
                        GameObject slot2;
                        for(int j = i; j < size - 2; j++)
                        {
                            slot1 = GameObject.Find("slot_" + j);
                            slot2 = GameObject.Find("slot_" + (j + 1));

                            slot1.GetComponent<Text>().text = slot2.GetComponent<Text>().text;
                        }

                        slot2 = GameObject.Find("slot_" + size);
                        slot2.GetComponent<Text>().text = "";
                        hide_radio_btn(slot2, "is_equipped");
                        hide_radio_btn(slot2, "delete");

                        Debug.Log(size);
                        size = size - 1;
                        PlayerPrefs.SetInt("inventory_size", size);
                    });
                }
                else if(radio_button.name == "is_equipped")
                {
                    radio_button.onValueChanged.AddListener(delegate
                    {
                        string[] values = PlayerPrefs.GetString("item #" + i).Split(':');

                        if (values.Length > 0 && values[5] != null)
                        {
                            string new_bool = (values[5][0] == 'T') ? ":False" : ":True";

                            string new_item = values[0] + ":" + values[1] + ":" + values[2] + ":" +
                                values[3] + ":" + values[4] + new_bool;
                            PlayerPrefs.DeleteKey("item #" + i);
                            PlayerPrefs.SetString(new_item, "item #" + i);
                        }
                    });
                }
            }
        }
    }


    //On Update 
    void Update ()
    {
        int size = PlayerPrefs.GetInt("inventory_size");
        /*Debug.Log(size);*/

        for (int i = 0; i < size; i++)
        {
            GameObject slot = GameObject.Find("slot_" + (i + 1));

            show_radio_btn(slot, "is_equipped", "Equipped:");
            show_radio_btn(slot, "delete", "Remove?:");

            /*Debug.Log(slot.gameObject.name);*/

            string item = PlayerPrefs.GetString("item #" + i);
            /*Debug.Log("hit da blunt");
            Debug.Log(item);*/

            string[] values = item.Split(':');
            /*Debug.Log(values);*/

            text = "Name: " + values[0] + "\nType: " + values[1] + "\nDescription: " + values[2];

            /*Debug.Log(text);*/
            slot.GetComponent<Text>().text = text;

            /*Debug.Log(descr.text);*/

            foreach (Toggle radio_button in slot.gameObject.GetComponents<Toggle>())
            {
                Debug.Log("FAFSBJADSABS");
                Debug.Log(radio_button.name);
                if (radio_button.name == "is_equipped")
                {
                    if (values[5][0] == 'T')
                    {
                        radio_button.isOn = true;
                    }
                    else
                    {
                        radio_button.isOn = false;
                    }

                }
                else if (radio_button.name == "delete")
                {
                    radio_button.isOn = true;
                }
            }

        }

        /*Do not show the other item slots, if they are empty*/
        
        for(int i = size; i < 18; i++)
        {
            GameObject slot = GameObject.Find("slot_" + (i + 1));
            slot.GetComponent<Text>().text = "";
            hide_radio_btn(slot, "is_equipped");
            hide_radio_btn(slot, "delete");

            /*to get the checkmark to be hidden as well*/
        }
    }
}

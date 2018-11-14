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

    void hide_item_slot(GameObject item_slot)
    {
        item_slot.GetComponent<Text>().text = "";
        hide_radio_btn(item_slot, "is_equipped");
        hide_radio_btn(item_slot, "delete");
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
                        GameObject player = GameObject.Find("player");
                        List <string> items = player.GetComponent<PlayerScript>().items;

                        int slot_number = slot.name[slot.name.Length - 1] - '1';
                        if (slot_number < items.Count)
                        {
                            items.RemoveAt(slot_number);
                        }
                        hide_item_slot(slot);
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
        GameObject player = GameObject.Find("player");

        List <string> items = player.GetComponent<PlayerScript>().items;
        int size = items.Count;

        /*Debug.Log(size);*/

        for (int i = 0; i < size; i++)
        {
            GameObject slot = GameObject.Find("slot_" + (i + 1));
            show_radio_btn(slot, "is_equipped", "Equipped:");
            show_radio_btn(slot, "delete", "Remove?:");

            /*Debug.Log(slot.gameObject.name);*/

            /*Debug.Log("hit da blunt");
            Debug.Log(item);*/

            string[] values = items[i].Split(':');
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
            hide_item_slot(GameObject.Find("slot_" + (i + 1)));
        }
    }
}

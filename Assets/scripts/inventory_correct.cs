using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class inventory_correct : MonoBehaviour
{
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

    char last_char(string s)
    {
        return s[s.Length - 1];
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

                        /*the +1 is to count the fact that slots are 1-indexed, 
                         * items are 0-indexed*/
                        int slot_number = last_char(slot.name) - ('0' + 1);
                 
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
                        GameObject player = GameObject.Find("player");

                        int slot_number = last_char(slot.name) - '1';

                        List <string> items = player.GetComponent<PlayerScript>().items;

                        string item = items[slot_number];

                        string[] values = item.Split(':');

                        if (values.Length > 0 && values[5] != null)
                        {
                            Debug.Log(values[5][0]);
                            string new_bool = (values[5][0] == 'T') ? ":False" : ":True";
                            Debug.Log(new_bool);

                            string new_item = values[0] + ":" + values[1] + ":" + values[2] + ":" +
                                values[3] + ":" + values[4] + new_bool;

                            Debug.Log(new_item + " vs. " + item);

                            items.RemoveAt(slot_number);
                            items.Insert(slot_number, new_item);
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

        for (int i = 0; i < size; i++)
        {
            GameObject slot = GameObject.Find("slot_" + (i + 1));
            show_radio_btn(slot, "is_equipped", "Equipped:");
            show_radio_btn(slot, "delete", "Remove?:");

            string[] values = items[i].Split(':');

            slot.GetComponent<Text>().text = "Name: " + values[0] + 
                "\nType: " + values[1] + "\nDescription: " + values[2];

            foreach (Toggle radio_button in slot.gameObject.GetComponents<Toggle>())
            {
                if (radio_button.name == "is_equipped")
                {
                    radio_button.isOn = (values[5][0] == 'T') ? true : false;
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

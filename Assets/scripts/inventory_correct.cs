using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class inventory_correct : MonoBehaviour
{
    void toggle_radio_btn(GameObject g, string name, bool toggle)
    {
        g.transform.Find(name + "/Background/Checkmark").GetComponent<Image>().enabled = toggle;
        g.transform.Find(name + "/Background").GetComponent<Image>().enabled = toggle;
        g.transform.Find(name).GetComponent<Toggle>().enabled = toggle;
    }

    void hide_text(Text text)
    {
        text.enabled = false;
        text.text = "";
    }

    void hide_item_slot(GameObject item_slot)
    {
        Transform t = item_slot.transform;

        hide_text(t.Find("Name").GetComponent<Text>());
        hide_text(t.Find("Modifier").GetComponent<Text>());
        hide_text(t.Find("Type").GetComponent<Text>());
        hide_text(t.Find("Amount").GetComponent<Text>());

        t.Find("Image").GetComponent<Image>().enabled = false;

        for (int i = 0; i < 4; i++)
        {
            toggle_radio_btn(item_slot, "is_equipped_" + i, false);
        }
        toggle_radio_btn(item_slot, "delete", false);
    }

    void hide_item_slots(int start, int end)
    {
        for (int i = start; i < end; i++)
        {
            hide_item_slot(GameObject.Find("slot_" + (i + 1)));
        }
    }
    void set_text(Text text, string content)
    {
        text.enabled = true;
        text.text = content;
    }

    char last_char(string s)
    {
        return s[s.Length - 1];
    }

    /*Well Scott, I made a constructor for weapon, it bothered me too much, if you want to move this to Items.cs you can.
     * I just dislike copying and pasting code, when I can build a function instead. I'm not exactly proud of this either.
     Have a good one, I wonder if we'll be finished the project by the time you read this*/
    StructsClass.Weapon Weapon(string name, string mod, string type, int numOfDice, int diceType)
    {
        StructsClass.Weapon weapon;

        weapon.name = name;
        weapon.modifier = mod;
        weapon.damageType = type;
        weapon.numOfDice = numOfDice;
        weapon.diceType = diceType;
        return weapon;
    }

    void disable_radio_btns(string slot_name, int equip_slot, bool active)
    {
        /*disable other toggles in the same column*/
        for (int j = 0; j < 18; j++)
        {
            GameObject other_slot = GameObject.Find("slot_" + (j + 1));
            Toggle[] btns = other_slot.GetComponentsInChildren<Toggle>();
            if (other_slot.name != slot_name)
            {
                Debug.Log("slot:" + (j + 1) + "  equip_slot:  " + equip_slot);
                if (btns.Length > 0 && btns[equip_slot] != null)
                {
                    btns[equip_slot].interactable = active;
                }
            }
        }

        /*disable toggles in the same row (but not itself)*/
        GameObject current_slot = GameObject.Find(slot_name);

        Toggle [] toggles = current_slot.GetComponentsInChildren<Toggle>();
        for(int i = 0; i < 4; i++)
        {
            if (i != equip_slot)
            {
                toggles[i].interactable = active;
            }
        }
    }


    void equip_weapon(string slot_name, int equip_slot)
    {
        GameObject player = GameObject.Find("player");

        int slot_number = last_char(slot_name) - '1';

        /*get the item at the item slot*/
        List<string> items = player.GetComponent<PlayerScript>().items;
        string item = items[slot_number];
        string[] values = item.Split(':');

        if (values.Length >= 6 &&
            values[5] != null)
        {
            /*change the bool value of the item*/
            Debug.Log(values[5][0]);
            string new_bool = (values[5][0] == 'T') ? ":False" : ":True";
            Debug.Log(new_bool);

            string new_item = values[0] + ":" + values[1] + ":" + values[2] + ":" +
               values[3] + ":" + values[4] + new_bool + ":" + "slot:" + equip_slot;

            /*replace the item*/
            items.RemoveAt(slot_number);
            items.Insert(slot_number, new_item);

            bool active = (new_bool == ":True") ? false : true;

            disable_radio_btns(slot_name, equip_slot, active);

            PartyScript members = GameObject.Find("player").GetComponentInChildren<PartyScript>();
            StructsClass.Character character; 

            /*I tried to base this on the order that they are assigned in, in the file party script:
             * member1 -> warrior, member2 -> rogue, member3 -> wizard, member4 -> cleric
             NOTE:: THIS IS A HARD-CODED ORDER, stay fresh/woke/aware of this*/
            switch(equip_slot)
            {
                case 1: character = members.member1; break;
                case 2: character = members.member2; break;
                case 3: character = members.member3; break;
                case 4: character = members.member4; break;
            }

            if (new_bool == ":True")
            {
                character.weapon = Weapon(values[0], values[1], values[2], values[3][0], values[4][0]);
            }
            else
            {
                character.weapon = Weapon("", "", "", 0, 0);
            }
        }
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
                else
                {
                    int equip_slot = last_char(radio_button.name) - '0';
                    radio_button.onValueChanged.AddListener(delegate
                    {
                        equip_weapon(slot.name, equip_slot);
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
            toggle_radio_btn(slot, "is_equipped_" + (i % 4), true);
            toggle_radio_btn(slot, "delete", true);

            string[] values = items[i].Split(':');
            
            if (items[i].EndsWith("slot:0") || 
                items[i].EndsWith("slot:1") ||
                items[i].EndsWith("slot:2") ||
                items[i].EndsWith("slot:3"))
            {
                Toggle[] toggles = slot.GetComponentsInChildren<Toggle>();

                for(int j = 0; j < 4; j++)
                {
                    if(toggles[j].isOn == true)
                    {
                        disable_radio_btns(slot.name, j, false);
                        break;
                    }
                }
            }

            Image sprite = slot.transform.Find("Image").
                GetComponentInChildren<Image>();
            sprite.enabled = true;
            sprite.SetNativeSize();
            sprite.sprite = ChestScript.getSpriteName(values[0]);

            Transform t = slot.transform;

            set_text(t.Find("Name").GetComponent<Text>(), values[0]);
            set_text(t.Find("Modifier").GetComponent<Text>(), values[1]);
            set_text(t.Find("Type").GetComponent<Text>(), values[2]);
            set_text(t.Find("Amount").GetComponent<Text>(), values[3] + "-" + values[4]);
        }

        hide_item_slots(size, 18);
    }
}
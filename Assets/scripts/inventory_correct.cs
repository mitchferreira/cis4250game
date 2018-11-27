using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.EventSystems;

public class inventory_correct : MonoBehaviour
{
    public static List<string> weapons = new List<string>();
    public static List<string> armors = new List<string>();

    public static bool[] rotate_weapon = new bool[30];
    public static bool[] rotate_armor = new bool[30];

    public static bool is_armor;

    public static bool armor_is_on_Screen()
    {
        return GameObject.Find("show_armor").GetComponent<Toggle>().isOn;
    }

    public static void toggle_radio_btn(GameObject g, string name, bool toggle)
    {
        g.transform.Find(name).GetComponent<Toggle>().enabled = toggle;
        g.transform.Find(name + "/Background/Checkmark").GetComponent<Image>().enabled = toggle;
        g.transform.Find(name + "/Background").GetComponent<Image>().enabled = toggle;
    }

    public static void hide_item_slot(GameObject item_slot)
    {
        Transform t = item_slot.transform;

        t.Find("Name").GetComponent<Text>().text = "";
        t.Find("Modifier").GetComponent<Text>().text = "";
        t.Find("Type").GetComponent<Text>().text = "";
        t.Find("Amount").GetComponent<Text>().text = "";

        t.Find("Image").GetComponent<Image>().enabled = false;

        for (int i = 0; i < 4; i++)
        {
            toggle_radio_btn(item_slot, "is_equipped_" + i, false);
        }
        //toggle_radio_btn(item_slot, "delete", false);
    }

    public static void hide_item_slots(int start, int end)
    {
        for (int i = start; i < end; i++)
        {
            hide_item_slot(GameObject.Find("slot_" + (i + 1)));
        }
    }

    public static char last_char(string s)
    {
        return s[s.Length - 1];
    }

    public static int char_to_int (char c)
    {
        return c - '0';
    }

    /*Well Scott, I made a constructor for weapon, it bothered me too much, if you want to move this to Items.cs you can.
     * I just dislike copying and pasting code, when I can build a function instead. I'm not exactly proud of this either.
     Have a good one, I wonder if we'll be finished the project by the time you read this*/
    public static StructsClass.Weapon Weapon(string name, string mod, string type, int numOfDice, int diceType)
    {
        StructsClass.Weapon weapon = new StructsClass.Weapon();

        weapon.name = name;
        weapon.modifier = mod;
        weapon.damageType = type;
        weapon.numOfDice = numOfDice;
        weapon.diceType = diceType;

        return weapon;
    }

    public static StructsClass.Armor Armor(string name, int value, string resistance)
    {
        StructsClass.Armor armor = new StructsClass.Armor();
        armor.name = name;
        armor.armorValue = value;
        armor.damageResist = resistance;

        return armor;
    }

    /*PURPOSE:: Does what disable_radio_btns() does but for all possible equipment slots. 
     * If given true, it will look for any equipped slots and make the ones around them unequippable
     * If given false, it will look for any unequipped slots, and make the ones around them equippable.
     * This function will check all possible slots, rather than just the most recently equipped one*/
    public static void disable_all_radio_btns(bool mode)
    {
        bool set = (mode == true) ? false : true;
        for(int i = 0; i < 18; i++)
        {
            GameObject slot = GameObject.Find("slot_" + (i + 1));

            Toggle [] btns = slot.GetComponentsInChildren<Toggle>();

            for(int j = 0; j < 4; j++)
            {
                if(btns[j].isOn == mode)
                {
                    disable_radio_btns(slot.name, j, set);
                }
            }
        }
    }

    public static void disable_radio_btns(string slot_name, int equip_slot, bool active)
    {
        /*disable other toggles in the same column*/
        for (int j = 0; j < 18; j++)
        {
            GameObject other_slot = GameObject.Find("slot_" + (j + 1));
            Toggle[] btns = other_slot.GetComponentsInChildren<Toggle>();
            if (other_slot.name != slot_name)
            {
                if (btns[equip_slot] != null)
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

    public static bool[,] get_equip_slots(string mode)
    {
        bool[,] values = new bool[30, 4];

        int size = (is_armor) ? armors.Count : weapons.Count;

        for (int i = 0; i < size; i++)
        {
            Toggle[] equip_slots = GameObject.Find("slot_" + (i + 1)).GetComponentsInChildren<Toggle>();

            for (int j = 0; j < 4; j++)
            {
                if (mode == "enabled")
                {
                    values[i, j] = equip_slots[j].interactable;
                }
                else if (mode == "equipped")
                {
                    values[i, j] = equip_slots[j].isOn;
                }
            }
        }
        for(int i = size; i < 18; i++)
        {
            Toggle[] equip_slots = GameObject.Find("slot_" + (i + 1)).GetComponentsInChildren<Toggle>();
            for (int j = 0; j < 4; j++)
            {
                equip_slots[j].isOn = false;
                equip_slots[j].interactable = true;
            }
        }
        return values;
    }

    public static void set_equip_slots(bool [,] values, bool [,] disabled, int mode = 'F')
    {
        int size;

        if(armor_is_on_Screen())
        {
            size = armors.Count;
        }
        else
        {
            size = weapons.Count;
        }

        for(int i = 0; i < 18; i++)
        {
            Toggle [] equip_slots = GameObject.Find("slot_" + (i + 1)).GetComponentsInChildren<Toggle>();

            for (int j = 0; j < 4; j++)
            {
                if (mode == 'F')
                {
                    equip_slots[j].isOn = false;
                    equip_slots[j].interactable = true;
                }
                else
                {
                    equip_slots[j].interactable = disabled[i, j];
                    equip_slots[j].isOn = values[i, j];
                }
            }
        }
    }

    public static StructsClass.Character get_party_member(PartyScript party, int member_number)
    {
        return party.members[member_number];
    }

    public static void equip_weapon(string slot_name, int equip_slot)
    {
        GameObject player = GameObject.Find("player");

        int slot_number = char_to_int(last_char(slot_name)) - 1;

        /*get the item at the item slot*/
        List<string> items = player.GetComponent<PlayerScript>().items;
        string item = items[slot_number];
        string[] values = item.Split(':');

        if (values.Length >= 6 &&
            values[5] != null)
        {
            /*change the bool value of the item*/
            Debug.Log(values[5][0]);
            string new_bool;

            if (values[5][0] == 'T')
            {
                new_bool = ":False";
                disable_radio_btns(slot_name, equip_slot, true);
            }
            else
            {
                new_bool = ":True";
                disable_radio_btns(slot_name, equip_slot, false);
            }
            disable_all_radio_btns(false);
            disable_all_radio_btns(true);
            
            Debug.Log(new_bool);

            string new_item = values[0] + ":" + values[1] + ":" + values[2] + ":" +
               values[3] + ":" + values[4] + new_bool + ":" + "slot:" + equip_slot;

            /*replace the item*/
            items.RemoveAt(slot_number);
            items.Insert(slot_number, new_item);

            StructsClass.Character character = get_party_member(
                player.GetComponentInChildren<PartyScript>(), equip_slot);

            Debug.Log(character.name);
            Debug.Log(character.charClass);

            /*I tried to base the item equips on the order that party members are added
             * in the file party script:
             * member1 -> warrior, member2 -> rogue, member3 -> wizard, member4 -> cleric
             * WRWC is the order (Warrior, Rogue, Wizard, Cleric)*/

            if (new_bool == ":True")
            {
                if (is_armor)
                {
                    character.armor = Armor(values[0], values[1][0], values[2]);
                }
                else
                {
                    character.weapon = Weapon(values[0], values[1], values[2], values[3][0], values[4][0]);
                }
            }
            else
            {
                if (is_armor)
                {
                    character.armor = Armor("", 0, "");
                }
                else
                {
                    character.weapon = Weapon("", "", "", 0, 0);
                }
            }
        }
    }

    public static void delete(GameObject slot)
    {
        GameObject player = GameObject.Find("player");
        List<string> items = player.GetComponent<PlayerScript>().items;

        /*the +1 is to count the fact that slots are 1-indexed,
         * items are 0-indexed*/
        int slot_number = char_to_int(last_char(slot.name)) - 1;

        /*-1 is not an equip_slot, this is so we that can know if none exist*/
        int equip_slot = -1;

        /*to unequip weapon, if it is equipped to a party member*/
        string[] values = items[slot_number].Split(':');

        if (values.Length >= 8)
        {
            equip_slot = char_to_int(values[7][0]);

            if (equip_slot != -1)
            {
                StructsClass.Character character = get_party_member(
                    player.GetComponent<PartyScript>(), equip_slot);

                if (is_armor)
                {
                    character.armor = Armor("", 0, "");
                }
                else
                {
                    character.weapon = Weapon("", "", "", 0, 0);
                }
            }
        }

        /*remove the item from the inventory*/
        if (slot_number < items.Count)
        {
            items.RemoveAt(slot_number);
        }
        hide_item_slot(slot);
    }

    List <string> separate_the_items (List <string> inventory, int type)
    {
        List<string> type_items = new List<string>();

        foreach(string item in inventory)
        {
            string[] values = item.Split(':');
            if(type == 'A' && values[4] == "")
            {
                type_items.Add(item);
            }
            else if(type == 'W' && values[4] != "")
            {
                type_items.Add(item);
            }
        }

        return type_items;
    }

    void Start()
    {
        for(int i = 0; i < 18; i++)
        {
            GameObject.Find("slot_" + (i + 1)).GetComponentsInChildren<Toggle>()[4].enabled = false;
        }
    }

    //On Update
    void Update ()
    {
        
        GameObject player = GameObject.Find("player");
        bool is_armor = armor_is_on_Screen();

        List <string> items = player.GetComponent<PlayerScript>().items;

        armors = separate_the_items(items, 'A');
        weapons = separate_the_items(items, 'W');
  
        int size;
        if (is_armor)
        {
            size = armors.Count;
        }
        else
        {
            size = weapons.Count;
        }

        for (int i = 0; i < size; i++)
        {
            GameObject slot = GameObject.Find("slot_" + (i + 1));

            for (int j = 0; j < 4; j++)
            {
                toggle_radio_btn(slot, "is_equipped_" + j, true);
            }
            //toggle_radio_btn(slot, "delete", true);

            string item;
            string [] values;

            item = (is_armor) ? armors[i] : weapons[i];
            values = item.Split(':');

            Image sprite = slot.transform.Find("Image").
                GetComponentInChildren<Image>();
            sprite.enabled = true;
            sprite.SetNativeSize();
            sprite.sprite = ChestScript.getSpriteName(values[0]);

            /*the staff sprite sheet is at a 45 degree angle, so below is my way of fixing it*/
            if (values[0].Contains("Staff") && rotate_weapon[i] == false)
            {
                sprite.transform.Rotate(new Vector3(0, 0, 45));
                rotate_weapon[i] = true;
            }

            Transform t = slot.transform;
            t.Find("Name").GetComponent<Text>().text = values[0];
            t.Find("Modifier").GetComponent<Text>().text = values[1];
            t.Find("Type").GetComponent<Text>().text = 
                (values[2].Contains("none")) ? "" : values[2];

            string amount;
            string modifier;
            if (is_armor != true)
            {
                int min = char_to_int(values[3][0]);
                int max = char_to_int(values[4][0]);

                if (min > 1)
                {
                    max = max * min;
                }
                amount = min + "-" + max;
                modifier = values[1];
            }
            else
            {
                amount = values[1];
                modifier = "";
            }
            t.Find("Amount").GetComponent<Text>().text = amount;
            t.Find("Modifier").GetComponent<Text>().text = modifier;
        }
        hide_item_slots(size, 18);
    }
}

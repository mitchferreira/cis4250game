﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

public class Show_armor : MonoBehaviour, IPointerClickHandler {

    string text;
    bool [] rotated = new bool[18];

    bool[,] weapons_equipped = new bool[30, 4];
    bool[,] weapons_disabled = new bool[30, 4];

    bool[,] armor_equipped = new bool[30, 4];
    bool[,] armor_disabled = new bool[30, 4];

    void set_Labels(string label_text)
    {
        GameObject.Find("Labels").GetComponent<Text>().text = label_text;
    }

    bool[,] clear(bool [,] values, bool value)
    {
        for(int i = 0; i < 18; i++)
        {
            for(int j = 0; j < 4; j++)
            {
                values[i, j] = value;
            }
        }
        return values;
    }

    void reset_equips()
    {
        weapons_disabled = clear(weapons_disabled, true);
        weapons_equipped = clear(weapons_equipped, false);

        armor_disabled = clear(armor_disabled, true);
        armor_equipped = clear(armor_equipped, false);
    }

    void Start()
    {
        reset_equips();
    }

    void set_initial_rotation(int rotate_z, int mode)
    {
        for(int i = 0; i < 18; i++)
        {
            GameObject slot = GameObject.Find("slot_" + (i + 1));

            Image image = slot.transform.Find("Image").GetComponent<Image>();
            image.transform.Rotate(0, 0, rotate_z);
        }
    }

    void print_arr(bool [,] arr)
    {
        for (int i = 0; i < 18; i++)
        {
            Debug.Log("column:" + i);
            for (int j = 0; j < 4; j++)
            {
                Debug.Log("row:" + j);
                Debug.Log(arr[i, j]);
            }
        }
    }

    public void OnPointerClick(PointerEventData ped)
    {
        text = this.gameObject.transform.Find("Label").GetComponent<Text>().text;

        if(text == "Armor")
        {
            this.gameObject.transform.Find("Label").GetComponent<Text>().text = "Weapons";
            set_Labels(" Name     Amount");
            set_initial_rotation(-90, 'A');

            weapons_equipped = inventory_correct.get_equip_slots("equipped");
            weapons_disabled = inventory_correct.get_equip_slots("enabled");

            inventory_correct.set_equip_slots(null, null, 'F');
            inventory_correct.set_equip_slots(armor_equipped, armor_disabled, ' ');
        }
        else
        {
            this.gameObject.transform.Find("Label").GetComponent<Text>().text = "Armor";
            set_Labels(" Name        Amount        DamageType Modifier");
            set_initial_rotation(90, 'W');

            armor_equipped = inventory_correct.get_equip_slots("equipped");
            armor_disabled = inventory_correct.get_equip_slots("enabled");

            inventory_correct.set_equip_slots(null, null, 'F');
            inventory_correct.set_equip_slots(weapons_equipped, weapons_disabled, ' ');
        }
        
    }
}

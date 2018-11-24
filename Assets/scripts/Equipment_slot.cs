using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Equipment_slot : MonoBehaviour, 
    IPointerClickHandler
{

    public static char last_char(string s)
    {
        return s[s.Length - 1];
    }

    public static int char_to_int(char c)
    {
        return c - '0';
    }

    public void OnPointerClick(PointerEventData ped)
    {
        int equip_slot = char_to_int(last_char(this.name));
        Debug.Log(transform.parent.name + "," + equip_slot);
        inventory_correct.equip_weapon(transform.parent.name, equip_slot);
    }
}

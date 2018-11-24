using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Delete_item : MonoBehaviour, IPointerClickHandler {

    public void OnPointerClick(PointerEventData ped)
    {
        GameObject parent = this.transform.parent.gameObject;

        Debug.Log(parent.name);

        inventory_correct.delete(this.transform.parent.gameObject);
    }
}

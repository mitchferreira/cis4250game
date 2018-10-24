using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exitPanel : MonoBehaviour {
	public GameObject attack_panel;
	
	void hide_panel(){
		attack_panel.SetActive(false);
	}
}

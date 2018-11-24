using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class attackPanel : MonoBehaviour {


	public GameObject attack_panel;
	public GameObject skills_panel;
	public GameObject items_panel;
	public bool hide_menu;
	public Button attackButton;


	

	void Awake(){
		attack_panel.SetActive(false);
		skills_panel.SetActive(false);
		items_panel.SetActive(false);
		hide_menu = true;

	}

	public void setInvsAP(){
		attack_panel.SetActive(false);
	}

	public void showAP(){
		attack_panel.SetActive(true);
	}

	public void setInvsSP(){
		skills_panel.SetActive(false);
	}

	public void showSP(){
		skills_panel.SetActive(true);
	}

	public void setInvsIP(){
		items_panel.SetActive(false);
	}

	public void showIP(){
		items_panel.SetActive(true);
	}
	/*void show_panel(){
		if(Input.GetKey("escape")){
			attack_panel.SetActive(false);
		}
	}*/
}

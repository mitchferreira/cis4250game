using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour {

	public GameObject save_menu_panel;
	public GameObject party_panel;
	public bool menu_hidden;
	public Button statsButton;

	// Use this for initialization
	void Awake() {
		save_menu_panel.SetActive(false);
		menu_hidden = true;
		statsButton.onClick.AddListener(OpenStatsMenu);
	}

	void Update() {
		if (Input.GetKeyDown("escape")) {
				if(menu_hidden) {
					save_menu_panel.SetActive(true);
				}
				else {
					save_menu_panel.SetActive(false);
					party_panel.GetComponent<Canvas>().enabled = false;
				}
				menu_hidden = !menu_hidden;
		}
	}

	void OpenStatsMenu() {
		party_panel.GetComponent<Canvas>().enabled = true;
	}
}

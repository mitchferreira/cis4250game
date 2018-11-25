using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour {

	public GameObject save_menu_panel;
	public GameObject party_panel;
	public bool menu_hidden;
	public Button statsButton;
	public Button closeStatsButton;

	// Use this for initialization
	void Awake() {
		save_menu_panel.SetActive(false);
		menu_hidden = true;
		statsButton.onClick.AddListener(OpenStatsMenu);
		closeStatsButton.onClick.AddListener(CloseStatsMenu);
		party_panel.SetActive(false);
	}

	void Update() {
		if (Input.GetKeyDown("escape")) {
				if(menu_hidden) {
					save_menu_panel.SetActive(true);
				}
				else {
					save_menu_panel.SetActive(false);
					party_panel.SetActive(false);
				}
				menu_hidden = !menu_hidden;
		}
	}

	void OpenStatsMenu() {
		GameObject.Find("_mysql").GetComponent<DatabaseHandler>().SaveGame();
		GameObject.Find("_mysql").GetComponent<DatabaseHandler>().LoadGame();
		party_panel.SetActive(true);
	}

	void CloseStatsMenu() {
		party_panel.SetActive(false);
	}
}

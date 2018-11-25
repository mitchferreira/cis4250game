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
		SetStatsMenu();
	}

	void CloseStatsMenu() {
		party_panel.SetActive(false);
	}

	void SetStatsMenu() {
		GameObject player = GameObject.Find("player");
		StructsClass.Character[] members = player.GetComponent<PartyScript>().GetPartyMembers();
		int i = 1;

		foreach (StructsClass.Character member in members) {
			Text name = GameObject.Find("member" + i + "Name").GetComponent<Text>();
			Text charClass = GameObject.Find("member" + i + "Class").GetComponent<Text>();
			Text level = GameObject.Find("member" + i + "Level").GetComponent<Text>();
			Text currentHealth = GameObject.Find("member" + i + "CurrentHealth").GetComponent<Text>();
			Text maxHealth = GameObject.Find("member" + i + "Maxhealth").GetComponent<Text>();
			Text mp = GameObject.Find("member" + i + "Mp").GetComponent<Text>();
			Text exp = GameObject.Find("member" + i + "Exp").GetComponent<Text>();
			Text str = GameObject.Find("member" + i + "Str").GetComponent<Text>();
			Text dex = GameObject.Find("member" + i + "Dex").GetComponent<Text>();
			Text con = GameObject.Find("member" + i + "Con").GetComponent<Text>();
			Text inte = GameObject.Find("member" + i + "Int").GetComponent<Text>();
			Text wis = GameObject.Find("member" + i + "Wis").GetComponent<Text>();
			Text chr = GameObject.Find("member" + i + "Chr").GetComponent<Text>();
			Text hit = GameObject.Find("member" + i + "HitDiceValue").GetComponent<Text>();
			name.text = member.name.ToString();
			charClass.text = member.charClass.ToString();
			level.text = member.level.ToString();
			currentHealth.text = member.currentHealth.ToString();
			maxHealth.text = member.maxHealth.ToString();
			mp.text = member.magicPoints.ToString();
			exp.text = member.exp.ToString();
			str.text = member.str.ToString();
			dex.text = member.dex.ToString();
			con.text = member.con.ToString();
			inte.text = member.inte.ToString();
			wis.text = member.wis.ToString();
			chr.text = member.chr.ToString();
			hit.text = member.hitDiceValue.ToString();
			i++;
		}
	}
}

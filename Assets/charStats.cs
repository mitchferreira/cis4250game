using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charStats : MonoBehaviour {

	public Text expText;
	public Text lvlText;

	public StructsClass.Character[] members;

	// Use this for initialization
	void Awake () {
		GameObject player = GameObject.Find("player");
		members = player.GetComponent<PartyScript>().GetPartyMembers();
		// SetStatsMenu();

	}

	// Update is called once per frame
	void Update () {

	}
	public void switchCharPanel(){

	}
}

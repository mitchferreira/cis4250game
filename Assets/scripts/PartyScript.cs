using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyScript : MonoBehaviour {
	public StructsClass.Character member1;
	public StructsClass.Character member2;
	public StructsClass.Character member3;
	public StructsClass.Character member4;
	public List<StructsClass.Character> members;

	// Use this for initialization
	void Awake () {
		member1 = Definitions.defineStartingWarrior();
		member2 = Definitions.defineStartingRogue();
		member3 = Definitions.defineStartingWizard();
		member4 = Definitions.defineStartingCleric();

		members = new List<StructsClass.Character>();
		members.Add(member1);
		members.Add(member2);
		members.Add(member3);
		members.Add(member4);
	}

	// Update is called once per frame
	void Update () {

	}

	public void SetPartyMember(string name, int str, int dex, int con, int inte, int wis, int chr, int level, int hitDiceValue, int maxHealth, int currentHealth, string className, int member, int mp, int exp) {
		StructsClass.Character insertMember = Definitions.defineStartingWarrior(); // just to have some starting character
		insertMember.name = name;
		insertMember.str = str;
		insertMember.dex = dex;
		insertMember.con = con;
		insertMember.inte = inte;
		insertMember.wis = wis;
		insertMember.chr = chr;
		insertMember.level = level;
		insertMember.hitDiceValue = hitDiceValue;
		insertMember.maxHealth = maxHealth;
		insertMember.currentHealth = currentHealth;
		insertMember.charClass = className;
		insertMember.magicPoints = mp;
		insertMember.exp = exp;
		members[member-1] = insertMember;
	}

	public StructsClass.Character[] GetPartyMembers() {
		return members.ToArray();
	}

	public void LevelUpParty(StructsClass.Character[] newMembers) {
		Debug.Log("member 1 before: " + members[0].level);
		Debug.Log("member 1 before: " + members[1].level);
		Debug.Log("member 1 before: " + members[2].level);
		Debug.Log("member 1 before: " + members[3].level);
		members[0] = newMembers[0];
		members[1] = newMembers[1];
		members[2] = newMembers[2];
		members[3] = newMembers[3];
		Debug.Log("member 1 after: " + members[0].level);
		Debug.Log("member 1 after: " + members[1].level);
		Debug.Log("member 1 after: " + members[2].level);
		Debug.Log("member 1 after: " + members[3].level);

		GameObject db = GameObject.Find("_mysql");
		db.GetComponent<DatabaseHandler>().SaveGame();
	}
}

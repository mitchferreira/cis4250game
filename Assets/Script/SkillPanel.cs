using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SkillPanel : MonoBehaviour {

	List<string> skillList;

	public Text skillText;
	private string display = "";

	void Start(){
		skillList = new List<string>();

		skillList.Add("skill1");
		skillList.Add("skill2");
		skillList.Add("skill3");

		
	}
	// Use this for initialization
	public void displaySkills () {
		foreach(string msg in skillList)
         {
             display = display.ToString () + msg.ToString() + "\n";
         }
         skillText.text = display;

	}

}

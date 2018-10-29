using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class charStats : MonoBehaviour {

    public Text expText;
    public Text lvlText;

	public StructsClass.Character member1;
	public StructsClass.Character member2;
	public StructsClass.Character member3;
	public StructsClass.Character member4;


	// Use this for initialization
	void Start () {

				
		member1 = Definitions.defineStartingWarrior();
		member2 = Definitions.defineStartingRogue();
		member3 = Definitions.defineStartingWizard();
		member4 = Definitions.defineStartingCleric();

		expText.text = member1.exp.ToString();
		lvlText.text = member1.level.ToString();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void switchCharPanel(){
		
	}
}

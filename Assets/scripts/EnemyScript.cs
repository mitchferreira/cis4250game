using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	public bool defeated;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public void UpdateEnemy(bool state) {
		defeated = !state;
		this.gameObject.SetActive(state);
	}
}

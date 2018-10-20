using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battle_cue : MonoBehaviour {

    public Rigidbody2D rb2d;
    public SpriteRenderer s;
    public GameObject g_obj;

	// Use this for initialization
	void Start () {
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("FUCK YES:");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

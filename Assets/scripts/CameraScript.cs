using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

	private GameObject player;
	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}

	void Awake() {
		player = GameObject.Find("player");
		// transform.position = Vector3.MoveTowards(transform.position, player.transform.position, 1);
		// transform.position = player.transform.position;
	}

	// Update is called once per frame
	void LateUpdate () {
		// transform.position = player.transform.position + offset;
		transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
		// transform.position = player.transform.position; // Camera follows the player with specified offset position
		// transform.position.x = player.transform.position.x;
		// transform.position.y = player.transform.position.y;
	}
}

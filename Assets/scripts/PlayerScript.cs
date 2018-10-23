using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
	public int level;
	public int expPoints;
	public float xCoordinate;
	public float yCoordinate;
	public GameObject player;

	public void UpdatePlayerState(float x, float y, int lvl, int exp) {
		level = lvl;
		expPoints = exp;
		xCoordinate = x;
		yCoordinate = y;
		UpdatePlayer();
	}

	void UpdatePlayer() {
		player.transform.position = new Vector3(xCoordinate, yCoordinate, 0.0f);
	}
}

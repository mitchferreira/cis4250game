using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerScript : MonoBehaviour {
	public int level;
	public int expPoints;
	public float xCoordinate;
	public float yCoordinate;
	public GameObject player;
	public string[] items;

	public void UpdatePlayerState(float x, float y, int lvl, int exp, string itemsToAdd) {
		level = lvl;
		expPoints = exp;
		xCoordinate = x;
		yCoordinate = y;
		items = itemsToAdd.Split(',');
		Debug.Log(items.Length);
		items = items.Where(elm => !string.IsNullOrEmpty(elm)).ToArray();
		Debug.Log(items.Length);
		foreach(string item in items) {
			Debug.Log(item);
		}
		UpdatePlayer();
	}

	void UpdatePlayer() {
		player.transform.position = new Vector3(xCoordinate, yCoordinate, 0.0f);
	}
}

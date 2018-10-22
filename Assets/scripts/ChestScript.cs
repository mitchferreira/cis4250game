using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour {

	public Sprite closed;
	public Sprite open;
	public GameObject chest;
	public bool opened;

	void Start()
	{
			SpriteRenderer renderer = chest.AddComponent<SpriteRenderer>();
			renderer.sortingOrder = 1;

			if(opened) {
				renderer.sprite = open;
			}
			else {
				renderer.sprite = closed;
			}
	}
}

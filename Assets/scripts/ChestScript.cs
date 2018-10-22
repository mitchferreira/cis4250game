using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour {

	public Sprite closed;
	public Sprite open;
	public GameObject chest;
    public bool opened;
    public SpriteRenderer render;
    Rigidbody2D rb; 

	void Start()
	{
			render = chest.AddComponent<SpriteRenderer>();
            render.sortingOrder = 1;
    
            rb = chest.AddComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Static;

            BoxCollider2D collider = chest.AddComponent<BoxCollider2D>();
            collider.size = new Vector2(0.05f, 0.07f);

            render.sprite = closed;
            opened = false;
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.CompareTag("Player"))
        {
            opened = true;
            render.sprite = open;
        }
    }
}

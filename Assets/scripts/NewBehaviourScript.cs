using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    public Rigidbody2D rb2d;
    public float tile_size = 0.25f;

	// Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || 
            Input.GetKey(KeyCode.A))
        {
            rb2d.MovePosition( new Vector2(rb2d.position.x - tile_size, rb2d.position.y));
        }
        else if (Input.GetKey(KeyCode.RightArrow) || 
            Input.GetKey(KeyCode.D))
        {
            rb2d.MovePosition( new Vector2(rb2d.position.x + tile_size, rb2d.position.y));
        }
        else if (Input.GetKey(KeyCode.UpArrow) || 
            Input.GetKey(KeyCode.W))
        {
            rb2d.MovePosition( new Vector2(rb2d.position.x, rb2d.position.y + tile_size));
        }
        else if (Input.GetKey(KeyCode.DownArrow) || 
            Input.GetKey(KeyCode.S))
        {
            rb2d.MovePosition( new Vector2(rb2d.position.x, rb2d.position.y - tile_size));
        }
    }
}

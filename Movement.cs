using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Rigidbody2D rb2d;
    public float tile_size = 1f;

    //tile based movement
    public bool has_moved = false;

	// Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (has_moved == false)
        {
            if (Input.GetKey(KeyCode.LeftArrow) ||
                Input.GetKey(KeyCode.A))
            {
                rb2d.MovePosition(new Vector2(rb2d.position.x - tile_size, rb2d.position.y));
                has_moved = true;
            }
            else if (Input.GetKey(KeyCode.RightArrow) ||
                Input.GetKey(KeyCode.D))
            {
                rb2d.MovePosition(new Vector2(rb2d.position.x + tile_size, rb2d.position.y));
                has_moved = true;
            }
            else if (Input.GetKey(KeyCode.UpArrow) ||
                Input.GetKey(KeyCode.W))
            {
                rb2d.MovePosition(new Vector2(rb2d.position.x, rb2d.position.y + tile_size));
                has_moved = true;
            }
            else if (Input.GetKey(KeyCode.DownArrow) ||
                Input.GetKey(KeyCode.S))
            {
                rb2d.MovePosition(new Vector2(rb2d.position.x, rb2d.position.y - tile_size));
                has_moved = true;
            }
        }

        // in order to do tile-based movement, I made a has_moved variable. Until a key is up, you
        // can only move once in a given direction of the 4 directions: up, down, left or right.
        if (Input.GetKeyUp(KeyCode.UpArrow) == true)
            has_moved = false;
        else if (Input.GetKeyUp(KeyCode.DownArrow) == true)
            has_moved = false;
        else if (Input.GetKeyUp(KeyCode.LeftArrow) == true)
            has_moved = false;
        else if (Input.GetKeyUp(KeyCode.RightArrow) == true)
            has_moved = false;
    }
}

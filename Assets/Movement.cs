using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public Rigidbody2D rb2d;
    public SpriteRenderer spriteR;

    public Sprite [] up;
    public Sprite [] down;  
    public Sprite [] left;
    public Sprite [] right;

    public Animator anim; 

    public int walk_cycle = 0;

    public float tile_size = 1f;
    public bool has_moved = false;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>(); 

        up    = Resources.LoadAll<Sprite>("walk_up"); 
        down  = Resources.LoadAll<Sprite>("walk_down");
        left  = Resources.LoadAll<Sprite>("walk_left");
        right = Resources.LoadAll<Sprite>("walk_right");
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
                spriteR.sprite = left[walk_cycle++];
            }
            else if (Input.GetKey(KeyCode.RightArrow) ||
                Input.GetKey(KeyCode.D))
            {
                rb2d.MovePosition(new Vector2(rb2d.position.x + tile_size, rb2d.position.y));
                has_moved = true;
                spriteR.sprite = right[walk_cycle++];
            }
            else if (Input.GetKey(KeyCode.UpArrow) ||
                Input.GetKey(KeyCode.W))
            {
                rb2d.MovePosition(new Vector2(rb2d.position.x, rb2d.position.y + tile_size));
                has_moved = true;
                spriteR.sprite = up[walk_cycle++];
            }
            else if (Input.GetKey(KeyCode.DownArrow) ||
                Input.GetKey(KeyCode.S))
            {
                rb2d.MovePosition(new Vector2(rb2d.position.x, rb2d.position.y - tile_size));
                has_moved = true;
                spriteR.sprite = down[walk_cycle++];
            }
        }

        if (walk_cycle == 6)
        {
            walk_cycle = 0;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            has_moved = false;
        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            has_moved = false;
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            has_moved = false;
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            has_moved = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class PlayerScript : MonoBehaviour {
	public int level;
	public int expPoints;
	public float xCoordinate;
	public float yCoordinate;
	public GameObject player;
	public List <string> items;

    public Rigidbody2D rb2d;
    public SpriteRenderer spriteR;

    public Sprite[] up;
    public Sprite[] down;
    public Sprite[] left;
    public Sprite[] right;

    public Sprite prev_sprite;

    public int walk_cycle = 0;
    public float tile_size = 0.16f;

    public int speed = 5;
    public int frame = 0;

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteR = GetComponent<SpriteRenderer>();

        up = Resources.LoadAll<Sprite>("walk_up");
        down = Resources.LoadAll<Sprite>("walk_down");
        left = Resources.LoadAll<Sprite>("walk_left");
        right = Resources.LoadAll<Sprite>("walk_right");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && frame++ % speed == 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                rb2d.MovePosition(new Vector2(rb2d.position.x - tile_size, rb2d.position.y));
                spriteR.sprite = left[walk_cycle++];
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                rb2d.MovePosition(new Vector2(rb2d.position.x + tile_size, rb2d.position.y));
                spriteR.sprite = right[walk_cycle++];
            }
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                rb2d.MovePosition(new Vector2(rb2d.position.x, rb2d.position.y + tile_size));
                spriteR.sprite = up[walk_cycle++];
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                rb2d.MovePosition(new Vector2(rb2d.position.x, rb2d.position.y - tile_size));
                spriteR.sprite = down[walk_cycle++];
            }
            else if (Input.GetKey(KeyCode.Escape))
            {
                PlayerPrefs.SetInt("inventory_size", items.Count);

                for(int i = 0; i < items.Count; i++)
                {
                    PlayerPrefs.SetString("item #" + i, items[i]);
                }
            }
            walk_cycle = walk_cycle % 6;
        }
    }

    public void UpdatePlayerState(float x, float y, int lvl, int exp, string itemsToAdd) {
		level = lvl;
		expPoints = exp;
		xCoordinate = x;
		yCoordinate = y;
		items = itemsToAdd.Split(',').ToList();
        Debug.Log(items.Count);

		items = items.Where(elm => !string.IsNullOrEmpty(elm)).ToList();
		Debug.Log(items.Count);

		foreach(string item in items) {
			Debug.Log(item);
		}
		UpdatePlayer();
	}

	void UpdatePlayer() {
		player.transform.position = new Vector3(xCoordinate, yCoordinate, 0.0f);
	}
}

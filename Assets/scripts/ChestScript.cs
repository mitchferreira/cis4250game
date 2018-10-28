using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour {

	public Sprite closed;
	public Sprite open;
	public GameObject chest;
	public bool opened;
	public SpriteRenderer render;
    public List <string> items;
    public string item_name;
    public string ability; 

	void Awake()
	{
		render = chest.AddComponent<SpriteRenderer>();
		render.sortingOrder = 1;

		BoxCollider2D collider = chest.AddComponent<BoxCollider2D>();

		/*NOTE:: the box collider size is based on a transform scale of 0.2 for the X and Y values,
			* if the transform scale changes, the box collider size WILL NEED to change as well,
			*  (Kent, 10/23/2018)
			*/
		collider.size = new Vector2(1.2f, 1.2f);

		render.sprite = opened ? open : closed;
	}

    void OnCollisionEnter2D(Collision2D c)
    {
        /*Checks if the player has collided with the chest,
         * if the player is in front of the chest (from a top down perspective,
         * should appear below the chest), and if the player's X position is within 0.25 of the chests's X
         * position.
         * NOTE:: I made these values assuming the transform's scale of the chest sprite is set to 0.2 for X and Y,
         *  if the size of the sprite changes, these values WILL NEED to change as well. - (Kent, 10/23/2018)
         */
        if(c.gameObject.CompareTag("Player") &&
			c.gameObject.transform.position.x > chest.transform.position.x - 0.25 &&
			c.gameObject.transform.position.x < chest.transform.position.x + 0.25 &&
			c.gameObject.transform.position.y < chest.transform.position.y && !opened)
        {
			opened = true;
			render.sprite = open;
            PlayerScript player = GameObject.Find("player").GetComponent<PlayerScript>();

            player.items.Add(item_name + ":" + ability);
            Debug.Log(item_name);
            Debug.Log(ability);
        }
    }

	public void UpdateChest(bool state) {
		opened = state;
		render.sprite = opened ? open : closed;
	}
}

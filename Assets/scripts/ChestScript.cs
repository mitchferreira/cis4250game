using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour {

	public Sprite closed;
	public Sprite open;
	public GameObject chest;
	public bool opened;
	public SpriteRenderer render;

    public string item_name;
    public string item_mod;
    public string item_type;
    public int dice_num;
    public int dice_type;

    string getSpriteName()
    {
        if(item_name == "Mace")
        {
            return "more_weapons_0";
        }
        else if(item_name == "Dagger")
        {
            return "more_weapons_1";
        }
        else if(item_name == "Longsword")
        {
            return "more_weapons_2";
        }
        else if(item_name == "Staff")
        {
            return "more_weapons_3";
        }
        else
        {
            return "notification_types_0";
        }
    }

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
			c.gameObject.transform.position.x > chest.transform.position.x - 0.15 &&
			c.gameObject.transform.position.x < chest.transform.position.x + 0.15 &&
			c.gameObject.transform.position.y < chest.transform.position.y + 0.10 && !opened)
        { 
            if (string.IsNullOrEmpty(item_name) == false)
            {
                List<string> items = GameObject.Find("player").GetComponent<PlayerScript>().items;

                /*The chest will not open unless you have sufficient space:
                 * less than or equal 18 items in your inventory*/
                if (items.Count <= 18)
                {
                    string item = item_name + ":" + 
                        item_mod + ":" + item_type + ":" + dice_num + ":" + dice_type + ":False";

                    items.Add(item);

                    opened = true;
                    render.sprite = open;

                    /*the rest of the code in this if, is to show the item on screen*/
                    /*calls getSprite() which choose the sprite based on the weapon name*/
                    GameObject alert = new GameObject();
                    alert.AddComponent<SpriteRenderer>();

                    alert.GetComponent<SpriteRenderer>().sortingOrder = 2;

                    /*name is the sprite name*/
                    string name = getSpriteName();
                    int len = name.Length;
                    int slice = name[len-1] - '0';
                    
                    alert.GetComponent<SpriteRenderer>().sprite = 
                        Resources.LoadAll<Sprite>(name.Substring(0, len-2))[slice];

                    alert.transform.position = 
                        new Vector3(chest.transform.position.x, chest.transform.position.y, 0);

                    alert.transform.localScale = new Vector3(1.5f, 0.9f, 1);
                    Destroy(alert, 0.25f);
                }
            }
        }
    }

	public void UpdateChest(bool state) {
		opened = state;
		render.sprite = opened ? open : closed;
	}
}

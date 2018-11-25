using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class Movement : MonoBehaviour {

    public Rigidbody2D rb2d;
    public SpriteRenderer spriteR;

    public Sprite [] up;
    public Sprite [] down;
    public Sprite [] left;
    public Sprite [] right;

    public int walk_cycle = 0;
    public float tile_size = 0.16f;

    public int speed = 10;
    public int frame = 0;

    public string nextLevel;

    public StructsClass.Enemy enemy1;
    public StructsClass.Enemy enemy2;
    public StructsClass.Enemy enemy3;
    public StructsClass.Enemy enemy4;
    public StructsClass.Enemy boss;
    public StructsClass.Enemy[] enemies;
    public StructsClass.Enemy[] battleEnemies;
    public StructsClass.Character[] players;
    public GameObject encounteredEnemy;

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

    private void OnTriggerEnter2D(Collider2D c)
    {
        // save when you get close to the enemy, so you don't get stuck in an endless loop of loading and immediately encountering the enemy
        if(c.gameObject.CompareTag("Enemy") || c.gameObject.CompareTag("Boss")) {
            GameObject.Find("_mysql").GetComponent<DatabaseHandler>().SaveGame();
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.CompareTag("Enemy"))
        {
            encounteredEnemy = c.gameObject;

            GameObject player = GameObject.Find("player");

            Enemies.defineEnemies();
            battleEnemies = new StructsClass.Enemy[4];

            if(SceneManager.GetActiveScene().name == "worldScene") {
                enemy1 = Enemies.Hobgoblin;
                enemy2 = Enemies.Hobgoblin;
                enemy3 = Enemies.Goblin;
                enemy4 = Enemies.Goblin;
            }
            else if(SceneManager.GetActiveScene().name == "level2") {
                enemy1 = Enemies.Ghast;
                enemy2 = Enemies.Ghast;
                enemy3 = Enemies.MinotaurSkeleton;
                enemy4 = Enemies.MinotaurSkeleton;
            }
            else if(SceneManager.GetActiveScene().name == "level3") {
                enemy1 = Enemies.HeckHound;
                enemy2 = Enemies.HeckHound;
                enemy3 = Enemies.Nightmare;
                enemy4 = Enemies.Nightmare;

            }

            // potential enemies in battle
            battleEnemies[0] = enemy1;
            battleEnemies[1] = enemy2;
            battleEnemies[2] = enemy3;
            battleEnemies[3] = enemy4;

            // choose two of the potential enemies at random
            enemies = new StructsClass.Enemy[2];
            System.Random rand = new System.Random();
            int dice = (rand.Next(0, 3));
            enemies[0] = battleEnemies[dice];

            dice = (rand.Next(0, 3));
            enemies[1] = battleEnemies[dice];

            players = player.GetComponent<PartyScript>().GetPartyMembers();

            SceneManager.LoadScene("BattleUI", LoadSceneMode.Additive);
        }

        if(c.gameObject.CompareTag("Boss")) {
            GameObject player = GameObject.Find("player");
            encounteredEnemy = c.gameObject;

            Enemies.defineEnemies();
            if(SceneManager.GetActiveScene().name == "worldScene") {
                boss = Enemies.GobKing; // change to boss enemy
                enemy1 = Enemies.Hobgoblin;
            }
            else if(SceneManager.GetActiveScene().name == "level2") {
                boss = Enemies.Ghast; // change to level 2 boss enemy
                enemy1 = Enemies.Hobgoblin;
            }
            else if(SceneManager.GetActiveScene().name == "level3") {
                boss = Enemies.HeckHound; // change to level 3 boss enemy
                enemy1 = Enemies.Hobgoblin;
            }

            battleEnemies = new StructsClass.Enemy[2];
            battleEnemies[0] = boss;
            battleEnemies[1] = enemy1;

            enemies = new StructsClass.Enemy[2];
            enemies[0] = battleEnemies[0];
            enemies[1] = battleEnemies[1];

            players = player.GetComponent<PartyScript>().GetPartyMembers();

            SceneManager.LoadScene("BattleUI", LoadSceneMode.Additive);
        }

        if(c.gameObject.CompareTag("Stairs")) {
            c.gameObject.GetComponent<LoadScene>().changeScene(nextLevel);
            if(nextLevel == "level2") {
                nextLevel = "level3";
            }
            else if(nextLevel == "level3") {
                nextLevel = "end";
            }
        }
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
            walk_cycle = walk_cycle % 6;
        }
    }
}

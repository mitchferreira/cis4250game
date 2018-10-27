using UnityEngine;
using UnityEngine.UI;
using System;
using System.Data;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using MySql.Data;
using MySql.Data.MySqlClient;
using UnityEngine.SceneManagement;

public class DatabaseHandler : MonoBehaviour
{

    public string host, database, user, password;
    public bool pooling = true;

    public GameObject dbObj;
    public GameObject inGameMenu;
    public GameObject menuCanvas;

    private String connectionString;
    private MySqlConnection con = null;
    private MySqlCommand cmd = null;
    private MySqlDataReader rdr = null;

    private MD5 _md5Hash;

    private GameObject[] chests;
    private GameObject[] enemies;
    private GameObject player;

    public Button saveBtn;
    public Button loadBtn;

    void Awake()
    {
        DontDestroyOnLoad(dbObj);
        DontDestroyOnLoad(inGameMenu);
        DontDestroyOnLoad(menuCanvas);
        connectionString = "Server=" + host + ";Database=" + database + ";User=" + user + ";Password=" + password + ";Pooling=";

        saveBtn.onClick.AddListener(SaveGame);
        loadBtn.onClick.AddListener(LoadGame);

        if (pooling)
        {
            connectionString += "true;";
        }
        else
        {
            connectionString += "false;";
        }

        try
        {
            con = new MySqlConnection(connectionString);
            con.Open();
            Debug.Log("Mysql state: " + con.State);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void SaveGame() {
        SaveChests();
        SaveEnemies();
        SavePlayer();
    }

    void SaveChests() {
        Debug.Log("saving chests");
        chests = GameObject.FindGameObjectsWithTag("chest");

        try {
            cmd = new MySqlCommand("TRUNCATE TABLE chests;", con);
            rdr = cmd.ExecuteReader();
            rdr.Close();
        }
        catch (Exception e) {
            Debug.Log(e);
        }

        foreach(GameObject chest in chests) {
            string name = chest.GetComponent<ChestScript>().name;
            int opened = chest.GetComponent<ChestScript>().opened ? 1 : 0;
            string insertString = $"INSERT INTO chests VALUES (\"{name}\", {opened});";

            try {
                cmd = new MySqlCommand(insertString, con);
                rdr = cmd.ExecuteReader();
                rdr.Close();
            }
            catch (Exception e) {
                Debug.Log(e);
            }
        }
    }

    void SaveEnemies() {
        Debug.Log("saving enemies");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");


        try {
            cmd = new MySqlCommand("TRUNCATE TABLE enemies;", con);
            rdr = cmd.ExecuteReader();
            rdr.Close();
        }
        catch (Exception e) {
            Debug.Log(e);
        }

        foreach(GameObject enemy in enemies) {
            string name = enemy.name;
            int defeated = enemy.GetComponent<EnemyScript>().defeated ? 1 : 0;
            string insertString = $"INSERT INTO enemies VALUES (\"{name}\", {defeated});";

            try {
                cmd = new MySqlCommand(insertString, con);
                rdr = cmd.ExecuteReader();
                rdr.Close();
            }
            catch (Exception e) {
                Debug.Log(e);
            }
        }
    }

    void SavePlayer() {
        Debug.Log("saving player");
        player = GameObject.Find("player");
        int level = player.GetComponent<PlayerScript>().level;
        int expPoints = player.GetComponent<PlayerScript>().expPoints;
        float xCoordinate = player.GetComponent<PlayerScript>().transform.position.x;
        float yCoordinate = player.GetComponent<PlayerScript>().transform.position.y;
        string insertString = $"INSERT INTO player VALUES ({xCoordinate}, {yCoordinate}, {level}, {expPoints});";

        try {
            cmd = new MySqlCommand("TRUNCATE TABLE player;", con);
            rdr = cmd.ExecuteReader();
            rdr.Close();
        }
        catch (Exception e) {
            Debug.Log(e);
        }

        try {
            cmd = new MySqlCommand(insertString, con);
            rdr = cmd.ExecuteReader();
            rdr.Close();
        }
        catch (Exception e) {
            Debug.Log(e);
        }
    }

    public void LoadGame() {
        LoadChests();
        Debug.Log("Loading enemies");
        LoadEnemies();
        Debug.Log("Loading player");
        LoadPlayer();
    }

    void LoadChests() {
        try {
            cmd = new MySqlCommand("SELECT * from chests;", con);
            rdr = cmd.ExecuteReader();
            Debug.Log("Loading chests");

            if(rdr.HasRows) {
                while(rdr.Read()) {
                    UpdateChestState(rdr.GetString(0), rdr.GetInt32(1));
                }
            }
            else
            {
                Debug.Log("No chests found.");
            }
            rdr.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    void LoadEnemies() {
        try {
            cmd = new MySqlCommand("SELECT * from enemies;", con);
            rdr = cmd.ExecuteReader();

            if(rdr.HasRows) {
                while(rdr.Read()) {
                    UpdateEnemyState(rdr.GetString("name"), rdr.GetInt32("defeated"));
                }
            }
            else
            {
                Debug.Log("No enemies found.");
            }
            rdr.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    void LoadPlayer() {
        try {
            cmd = new MySqlCommand("SELECT * from player;", con);
            rdr = cmd.ExecuteReader();

            if(rdr.HasRows) {
                rdr.Read();
                UpdatePlayerState(rdr.GetFloat("xCoordinate"), rdr.GetFloat("yCoordinate"), rdr.GetInt32("level"), rdr.GetInt32("experiencePoints"));
            }
            else
            {
                Debug.Log("No chests found.");
            }
            rdr.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    void UpdatePlayerState(float x, float y, int lvl, int exp) {
        player = GameObject.Find("player");
        player.GetComponent<PlayerScript>().UpdatePlayerState(x, y, lvl, exp);
    }

    void UpdateChestState(string chestName, int chestOpen) {
        bool open = true;
        if(chestOpen == 0) {
            open = false;
        }

        GameObject chest = GameObject.Find(chestName);
        chest.GetComponent<ChestScript>().UpdateChest(open);
    }

    void UpdateEnemyState(string enemyName, int enemyDefeated) {
        bool alive = true;
        if(enemyDefeated == 1) {
            alive = false;
        }

        GameObject enemy = GameObject.Find(enemyName);
        enemy.GetComponent<EnemyScript>().UpdateEnemy(alive);
    }

    void OnApplicationQuit()
    {
        if (con != null)
        {
            if (con.State.ToString() != "Closed")
            {
                con.Close();
                Debug.Log("Mysql connection closed");
            }
            con.Dispose();
        }
    }

    public string GetConnectionState()
    {
        return con.State.ToString();
    }
}

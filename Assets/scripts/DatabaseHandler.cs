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

public class DatabaseHandler : MonoBehaviour
{

    public string host, database, user, password;
    public bool pooling = true;

    private String connectionString;
    private MySqlConnection con = null;
    private MySqlCommand cmd = null;
    private MySqlDataReader rdr = null;

    private MD5 _md5Hash;

    private GameObject[] chests;

    public Button saveBtn;
    public Button loadBtn;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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

    void SaveGame() {
        Debug.Log("Saving");
        chests = GameObject.FindGameObjectsWithTag("chest");

        try {
            cmd = new MySqlCommand("TRUNCATE TABLE chests", con);
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
                Debug.Log(insertString);
                cmd = new MySqlCommand(insertString, con);
                rdr = cmd.ExecuteReader();
                rdr.Close();
            }
            catch (Exception e) {
                Debug.Log(e);
            }
        }

        try
        {
            cmd = new MySqlCommand("UPDATE save_file SET data = \"new text\", data_blob = 100 where id = 1;", con);
            rdr = cmd.ExecuteReader();
            rdr.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    void LoadGame() {
        Debug.Log("Loading");
        try
        {
            cmd = new MySqlCommand("SELECT data, data_blob from save_file;", con);
            rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    Debug.Log("Text field: " + rdr.GetString(0));
                    Debug.Log("Blob field: " + rdr.GetString(1));
                }
            }
            else
            {
                Debug.Log("No rows found.");
            }
            rdr.Close();
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
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

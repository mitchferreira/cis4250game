using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    public void changeScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public void changeSceneAndLoad(){
        DontDestroyOnLoad(this.gameObject);
        SceneManager.activeSceneChanged += ChangedActiveScene;

        string sceneName = GameObject.Find("_mysql").GetComponent<DatabaseHandler>().GetLevel();
        SceneManager.LoadScene(sceneName);
    }

    private void ChangedActiveScene(Scene current, Scene next)
    {
        string currentName = current.name;
        Debug.Log("Next: " + next.name);
        Debug.Log("Current: " + current.name);
        Debug.Log(GameObject.Find("player").transform.position.x);

        if (next.name == "worldScene" || next.name == "level2" || next.name == "level3")
        {
            GameObject db = GameObject.Find("_mysql");
            db.GetComponent<DatabaseHandler>().LoadGame();
        }
    }
}

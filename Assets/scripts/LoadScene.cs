using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene : MonoBehaviour {

    public void changeScene(string sceneName){
        Application.LoadLevel(sceneName);
    }
}

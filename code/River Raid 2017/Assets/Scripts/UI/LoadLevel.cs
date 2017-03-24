using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

    public string levelName = "MainScene";

    public void Trigger()
    {
        SceneManager.LoadScene(levelName);
    }
}

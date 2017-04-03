using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public string levelName = "MainScene";

    public void Trigger()
    {
        StartCoroutine(LoadScene());
    }

    //Gives us some time to play button sounds etc
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.15f);
        SceneManager.LoadScene(levelName);
    }
}

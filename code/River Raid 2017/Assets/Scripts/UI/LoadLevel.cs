using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{

    public string levelName = "MainScene";

    public void Trigger()
    {
        iTween.CameraFadeAdd();
        iTween.CameraFadeTo(1f, 0.4f);
        StartCoroutine(LoadScene());
    }

    //Gives us some time to play button sounds/fade out etc
    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene(levelName);
    }
}

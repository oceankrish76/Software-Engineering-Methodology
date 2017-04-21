using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonHandler : MonoBehaviour
{



    public void OnNewGameClicked()
    {
        iTween.CameraFadeAdd();
        iTween.CameraFadeTo(1f, .15f);
        SceneManager.LoadScene("MainScene");

    }

    public void OnOptionsClicked()
    {
        iTween.CameraFadeAdd();
        iTween.CameraFadeFrom(1f, .3f);
       // StartCoroutine("FadeFrom");
    }

    public void OnCreditsClicked()
    {
        iTween.CameraFadeAdd();
        iTween.CameraFadeFrom(1f, .3f);
        //StartCoroutine("FadeFrom");
    }

    public void OnQuitClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ToggleSounds()
    { 
        bool setState = AudioListener.pause ? false : true; 
        AudioListener.pause = setState;
    }
}

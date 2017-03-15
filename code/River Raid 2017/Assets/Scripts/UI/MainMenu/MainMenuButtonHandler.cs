using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtonHandler : MonoBehaviour
{



    public void OnNewGameClicked()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnOptionsClicked()
    {

    }

    public void OnCreditsClicked()
    {

    }

    public void OnQuitClicked()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}

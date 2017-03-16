using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloadSceneChange : MonoBehaviour {

    public float sceneChangeTimer = 3.5f;
	// Use this for initialization
	void Start () {

        StartCoroutine(ChangeScene());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(sceneChangeTimer);
        SceneManager.LoadScene("MainScene");
    }
}

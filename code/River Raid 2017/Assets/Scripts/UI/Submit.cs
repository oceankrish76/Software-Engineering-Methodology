using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Submit : MonoBehaviour {

	// Use this for initialization
	public void OnSubmitClicked()
	{
		Debug.Log ("Clicked");
		SceneManager.LoadScene("greetings");
		//Application.LoadLevel("MainScene");
	}
}

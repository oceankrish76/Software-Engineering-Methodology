using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Submit : MonoBehaviour {

	// Use this for initialization

	//for players name
	private SimpleGameManager manager;
	//private string name;
	//private string playerName;
	//public GameObject inputField;
	public void OnSubmitClicked()
	{
		Debug.Log ("Clicked");
		//manager = FindObjectOfType<SimpleGameManager>();
		//playerName = manager.PlayerName;
		//inputField.GetComponent<Text>().text = playerName;


		SceneManager.LoadScene("greetings");
		//Application.LoadLevel("MainScene");
	}
}

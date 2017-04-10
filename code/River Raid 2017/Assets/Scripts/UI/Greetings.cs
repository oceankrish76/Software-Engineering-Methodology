using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManager;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Greetings : MonoBehaviour {

	public GameObject nameField;
	//for players name
	private SimpleGameManager manager;
	private string name;
	private string playerName;


	void Start()
	{

		manager = FindObjectOfType<SimpleGameManager>();
		name = manager.PlayerName;
		nameField.GetComponent<Text>().text = "Hello " + name + "!";


	}

	//For Continue button
	public void OnContinueGameClicked()
	{
		Debug.Log ("Clicked");
		SceneManager.LoadScene("MainMenu");
		//Application.LoadLevel("MainScene");
	}
}

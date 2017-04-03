using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManager;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Greetings : MonoBehaviour {
	public GameObject window;
	public Text messageField;

	public void Show(string message){
		messageField.text = message;
		window.SetActive (true);


	}

	public void Hide(){
		window.SetActive (false);
	}
	//for players name
	private SimpleGameManager manager;
	private string name;
	void Start()
	{

		manager = FindObjectOfType<SimpleGameManager>();
		name = manager.PlayerName;
		GetComponent<Text>().text = name;


	}

	//For Continue button
	public void OnContinueGameClicked()
	{
		Debug.Log ("Clicked");
		SceneManager.LoadScene("MainScene");
		//Application.LoadLevel("MainScene");
	}
}

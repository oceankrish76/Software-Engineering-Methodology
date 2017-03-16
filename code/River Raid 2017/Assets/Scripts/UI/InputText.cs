using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputText : MonoBehaviour {


	private InputField playersnameInput;
	private string playersname;
	private InputField mainInputField;
	private SimpleGameManager manager;


	public void Start()
	{
		

		mainInputField = GetComponent<InputField>();

		
		mainInputField.onValueChanged.AddListener (delegate {ValueChangeCheck ();});

	}
	public void Saveplayersname(string newName) {
		playersname = newName;
	}
	public void ValueChangeCheck()
	{
		//mainInputField.text = playersname;
		playersname = mainInputField.text;
		//Greeting to the player
		Debug.Log ("Hello, " + playersname + "Greetings from River Raid 2017!");

		manager = FindObjectOfType<SimpleGameManager> ();
		manager.PlayerName = playersname;
	}
		

}

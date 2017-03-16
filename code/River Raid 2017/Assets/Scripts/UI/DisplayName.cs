using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayName : MonoBehaviour {

	private SimpleGameManager manager;
	//private string playerName;
	private string playersnameNew;



	// Use this for initialization
	void Start () {

		manager = FindObjectOfType<SimpleGameManager> ();
		playersnameNew = manager.PlayerName;


		GetComponent<Text>().text = "Player: " + playersnameNew;


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

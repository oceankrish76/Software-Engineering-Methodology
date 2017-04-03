using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInGreetings : MonoBehaviour {

	private SimpleGameManager manager;
	private string name;
	void Start()
	{

		manager = FindObjectOfType<SimpleGameManager>();
		name = manager.PlayerName;
		GetComponent<Text>().text = name;


	}
}

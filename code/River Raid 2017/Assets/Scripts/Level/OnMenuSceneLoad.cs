using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMenuSceneLoad : MonoBehaviour {

    private SimpleGameManager manager;
    
	// Use this for initialization
	void Awake () {

        if(FindObjectOfType<SimpleGameManager>())
        {
            manager = FindObjectOfType<SimpleGameManager>();
        }

        manager.SetGameState(GameState.MENU);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

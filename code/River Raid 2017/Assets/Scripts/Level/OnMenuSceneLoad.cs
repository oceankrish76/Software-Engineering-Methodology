using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMenuSceneLoad : MonoBehaviour {


    private SimpleGameManager manager;
    
	// Use this for initialization
	void Start () {

        if(FindObjectOfType<SimpleGameManager>())
        {
            manager = FindObjectOfType<SimpleGameManager>();
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHighScoresLoad : MonoBehaviour {

    private SimpleGameManager manager;

	void Start () {

        if (FindObjectOfType<SimpleGameManager>())
        {
            manager = FindObjectOfType<SimpleGameManager>();
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}

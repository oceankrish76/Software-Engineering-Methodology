using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelColliderBehaviour : MonoBehaviour {


    private SimpleGameManager manager;
	// Use this for initialization
	void Start () {

        manager = FindObjectOfType<SimpleGameManager>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            manager.PlayerLives -= 1;
        }

        Destroy(other.gameObject);

    }
}

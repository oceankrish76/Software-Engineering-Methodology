using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelColliderBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<SimpleGameManager>().GetComponent<SimpleGameManager>().PlayerLives = -1;
        }
            Destroy(other.gameObject);

    }
}

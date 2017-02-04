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
        if(other.gameObject.tag == "Player")
        {
            Destroy(other.gameObject);
            Debug.Log("GameOver");
        }
    }
}

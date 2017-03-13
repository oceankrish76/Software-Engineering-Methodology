using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {

    public GameObject playerPrefab;
	
	void Start () {
	    	
	}

    public void respawnPlayer()
    {
        Instantiate(playerPrefab, transform.position, Quaternion.Euler(0,180,0));
    }
	
}

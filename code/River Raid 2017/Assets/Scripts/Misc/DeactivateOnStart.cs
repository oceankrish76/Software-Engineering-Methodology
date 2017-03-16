using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateOnStart : MonoBehaviour {

	void Awake () {

        GetComponent<Canvas>().enabled = false;
	}
	
}

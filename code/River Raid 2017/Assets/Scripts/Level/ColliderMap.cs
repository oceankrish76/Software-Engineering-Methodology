using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMap : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Collided enter");
			Destroy(other.gameObject);
		}
		//Destroy (wallc.gameObject);
	}

	/*void OnTriggerExit(Collider wallc){
		Debug.Log ("Collided exit");
		//Destroy (wallc.gameObject);
	}*/
}

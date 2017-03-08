using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMap : MonoBehaviour {
	/*
	MapGenerator MapGenerator;

	void start () {
		MapGenerator.AddColliders ();
	}

	void update () {
		if (Input.GetMouseButtonDown(0)) {
			MapGenerator.ClearMapColliders ();
			MapGenerator.AddColliders ();
		}
	}
*/
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

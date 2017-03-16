using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderMap : MonoBehaviour {

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			Debug.Log ("Collided enter");
			Destroy(other.gameObject);
		}
	}
}

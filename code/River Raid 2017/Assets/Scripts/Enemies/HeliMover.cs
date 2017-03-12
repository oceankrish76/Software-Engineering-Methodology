using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class HeliMover : MonoBehaviour {

    public float speed = 1.0f;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(-1, 0, -1, ForceMode.Impulse);
    }
	void Update () {

        
    }
}

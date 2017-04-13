using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class HeliMover : MonoBehaviour {

    public float forceX = 0;
    public float forceY = 0f;
    public float forceZ = 0f;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(forceX, forceY, forceZ, ForceMode.Impulse);
    }
	void Update () {

        
    }
}

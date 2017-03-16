using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

    public float amountX = 1.0f;
    public float amountY = 1.0f;
    public float amountZ = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {

        gameObject.transform.Rotate(amountX, amountY, amountZ);
	}
}

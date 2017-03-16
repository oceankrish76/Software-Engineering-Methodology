using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    public float rotationSpeed = 30.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetRotation()
    {
        transform.localEulerAngles = new Vector3(0, 180, 0);
    }

    public void RotateModel()
    {
        float direction = Input.GetAxis("Horizontal");
        transform.localEulerAngles = new Vector3(0, 180, direction*rotationSpeed);
    }
}

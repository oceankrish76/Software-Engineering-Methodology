using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour {

    public float rotationSpeed = 30.0f;


	// Ensure correct spawning rotation
	void Start () {
        transform.localEulerAngles = new Vector3(0, 180, 0);
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

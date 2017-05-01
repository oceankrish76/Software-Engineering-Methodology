using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RotateObject : MonoBehaviour {

    public float tumble = .5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.angularVelocity = Random.insideUnitSphere * tumble;
    }
}

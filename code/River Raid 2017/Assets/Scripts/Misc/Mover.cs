using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Mover: MonoBehaviour
{
    public float speed = 0f;

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();//.AddForce(forceX, forceY, forceZ, ForceMode.Impulse);
        rb.velocity = transform.forward * speed;
    }
}
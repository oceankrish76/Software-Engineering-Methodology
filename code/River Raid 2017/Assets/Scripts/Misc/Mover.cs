using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class Mover: MonoBehaviour
{
    public float forceX = 0f;
    public float forceY = 0f;
    public float forceZ = 0f;

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(forceX, forceY, forceZ, ForceMode.Impulse);
    }
}
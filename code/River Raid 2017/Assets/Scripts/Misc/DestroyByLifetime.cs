using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByLifetime : MonoBehaviour
{


    public float lifetime = 2f;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

}

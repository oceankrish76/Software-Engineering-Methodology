using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupExplosion : MonoBehaviour {


    private ParticleSystem particles;

	void Start () {
        particles = GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {

        if(!particles.isEmitting)
        {
            Destroy(gameObject);
        }
	}
}

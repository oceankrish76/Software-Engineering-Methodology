//Arno
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public GameObject Bullets;

	void Start () {
		
	}
	
	void Update () {
		
	}


    void Fire(Transform spawn)
    {
        Instantiate(Bullets, spawn.position, spawn.rotation);
    }
}

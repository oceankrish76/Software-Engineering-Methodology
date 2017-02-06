//Arno

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public float moveSpeed = 1.0f;
    public Transform shotSpawn;

    public float fireRate = 0f;
    private float nextFire;

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(GetComponent<PlayerWeapons>().availableWeapons.defaultWeapon, shotSpawn.position, shotSpawn.rotation);
        }
    }

    void FixedUpdate () {
        
        //TODO: check if player is alive
            if (Input.GetButton("Horizontal"))
            {
                transform.localPosition += Input.GetAxis("Horizontal") * transform.right * Time.deltaTime * moveSpeed;
                GetComponentInChildren<PlayerRotation>().RotateModel();
            }

            if (Input.GetButton("Vertical"))
            {
                transform.localPosition += Input.GetAxis("Vertical") * transform.forward * Time.deltaTime * moveSpeed;
                GetComponentInChildren<PlayerRotation>().ResetRotation();
            }


	}
}

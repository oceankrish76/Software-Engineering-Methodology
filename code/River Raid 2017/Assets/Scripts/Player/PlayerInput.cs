//Arno

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {

    public float moveSpeed = 50.0f;
    public float rotationSpeed = 1.0f;
    public Transform shotSpawn;

    public float fireRate = 0.0f;
    private float nextFire;

    Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
        rigidbody = GetComponent<Rigidbody>();

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

        float moveHorizontally = Input.GetAxis("Horizontal");
        float moveVertically = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontally, 0.0f, moveVertically);
        rigidbody.velocity = movement * moveSpeed;

        rigidbody.position = new Vector3(rigidbody.position.x, 0.0f, rigidbody.position.z);

        rigidbody.rotation = Quaternion.Euler(0.0f, 180.0f, rigidbody.velocity.x * rotationSpeed);
    }
}

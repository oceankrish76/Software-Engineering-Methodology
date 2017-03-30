//Arno

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public float moveSpeed = 50.0f;
    public float rotationSpeed = 1.0f;
    public Transform shotSpawn;

    public float fireRate = 0.0f;
    private float nextFire;

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //Respawn invulnerability
        StartCoroutine(Respawning());

    }

    void SetColliderStatus(bool active)
    {
        foreach (Collider c in GetComponents<Collider>())
        {
            c.enabled = active;
        }
    }

    IEnumerator Respawning()
    {
        SetColliderStatus(false);
        StartCoroutine(RespawnBlink());
        yield return new WaitForSeconds(1.5f);
        SetColliderStatus(true);
    }

    IEnumerator RespawnBlink()
    {
        Color color1 = GetComponent<Renderer>().material.color;
        Color color2 = color1;
        color2.a = 0;
        GetComponent<Renderer>().material.color = color2;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Renderer>().material.color = color1;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Renderer>().material.color = color2;
        yield return new WaitForSeconds(0.5f);
        GetComponent<Renderer>().material.color = color1;

    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(GetComponent<PlayerWeapons>().availableWeapons.defaultWeapon, shotSpawn.position, shotSpawn.rotation);
        }
    }
    void FixedUpdate()
    {

        //TODO: check if player is alive

        float moveHorizontally = Input.GetAxis("Horizontal");
        float moveVertically = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontally, 0.0f, moveVertically);
        rb.velocity = movement * moveSpeed;

        rb.position = new Vector3(rb.position.x, 0.0f, rb.position.z);

        rb.rotation = Quaternion.Euler(0.0f, 180.0f, rb.velocity.x * rotationSpeed);
    }
}

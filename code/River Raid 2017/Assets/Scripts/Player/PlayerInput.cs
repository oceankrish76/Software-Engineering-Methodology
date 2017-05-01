//Arno

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public float moveSpeed = 50.0f;
    public float rotationSpeed = 1.0f;

    public float fireRate = 0.0f;
    private float nextFire;

    private Rigidbody rb;
    private SimpleGameManager manager;

    private GameObject pauseMenu;

    // Use this for initialization
    void Start()
    {
        manager = FindObjectOfType<SimpleGameManager>();
        pauseMenu = GameObject.FindWithTag("PauseMenu");
        rb = GetComponent<Rigidbody>();

        //Respawn invulnerability
        StartCoroutine(Respawning());

    }

    //Sets all colliders on or off
    void SetColliderStatus(bool active)
    {
        foreach (Collider c in GetComponents<Collider>())
        {
            c.enabled = active;
        }
    }

    //When respawning, the player is invulnerable for a few seconds
    IEnumerator Respawning()
    {
        SetColliderStatus(false);
        StartCoroutine(RespawnBlink());
        yield return new WaitForSeconds(2f);
        SetColliderStatus(true);
    }


    //TODO: this is garbage
    IEnumerator RespawnBlink()
    {
        Color color1 = GetComponent<Renderer>().material.color;
        Color color2 = color1;
        color2.a = 0;
        color2.g = 255;

        for (int i = 0; i < 3; ++i)
        {
            GetComponent<Renderer>().material.color = color2;
            yield return new WaitForSeconds(0.5f);
            GetComponent<Renderer>().material.color = color1;
            yield return new WaitForSeconds(0.5f);
        }

    }




    //Actual movement functions
    //Update handles only fire
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            if(manager.playerIsAlive)
            {
                GetComponent<PlayerWeapons>().FireCurrentWeapon();
            }
        }

        if(Input.GetButtonDown("Cancel"))
        {
            if (Time.timeScale == 1.0f)
            {
                Time.timeScale = 0f;
                pauseMenu.GetComponent<Canvas>().enabled = true;
            } else
            {
                pauseMenu.GetComponent<Canvas>().enabled = false;
                Time.timeScale = 1.0f;
            }
        }
    }

    //Fixed update for physics related stuff such as movement
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


    //Collision with bullets
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyBullets")
        {

            Destroy(gameObject);
        }
    }
}

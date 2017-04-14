using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : Weapon
{

    public float missileSpeed = 0.02f;
    public GameObject explosion;

    private SimpleGameManager manager;
    private GameObject player;

    void Awake()
    {
        manager = FindObjectOfType<SimpleGameManager>();
        player = GameObject.FindWithTag("Player");
    }

    public override void Fire(Transform position, GameObject owner)
    {
        //This is quite curious, since we're calling this function to instantiate this gameObject.
        player = GameObject.FindWithTag("Player");
        if (player && player.transform.position.z < owner.transform.position.z)
        {
            base.Fire(position, owner);
        }
        //StartCoroutine(MoveTowards());
    }

    void Update()
    {
        // iTween.MoveUpdate(gameObject, GameObject.FindWithTag("Player").transform.position, 2f);
        if (player)
        {
            iTween.LookUpdate(gameObject, player.transform.position, .1f);
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, missileSpeed);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PlayerBullets")
        {
            Destroy(gameObject);
        }
    }

    void OnDestroy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
    }
}

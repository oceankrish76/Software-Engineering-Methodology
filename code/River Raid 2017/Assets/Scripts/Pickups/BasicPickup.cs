using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPickup : MonoBehaviour {

   public GameObject explosion;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Pickup Picked");

            Destroy(gameObject);
        }

        if(other.gameObject.tag == "Bullets")
        {
            GameObject particles = Instantiate(explosion, transform.position, transform.rotation);
       
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }



}

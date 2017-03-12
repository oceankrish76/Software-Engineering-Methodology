using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour {

    public GameObject Explosion;
    public AudioClip explosionSound;
    public int scoreForKill = 100;

    private SimpleGameManager manager;



    void Start () {

        manager = FindObjectOfType<SimpleGameManager>();
	}
	
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullets")
        {
            manager.PlayerScore += scoreForKill;
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            Instantiate(Explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
            

        }
    }
}


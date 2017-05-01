using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCollision : MonoBehaviour {

    public GameObject Explosion;
    public GameObject scoreUI;
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
        if(other.tag == "PlayerBullets")
        {
            GameObject scorevisual = Instantiate(scoreUI, (transform.position+ new Vector3(0,2,0)), Quaternion.identity);
            scorevisual.GetComponentInChildren<Text>().text = scoreForKill.ToString();
            manager.PlayerScore += scoreForKill;
            DestroyMe();
            Destroy(other.gameObject);


        } else if(other.tag == "Player")
        {
            DestroyMe();
            Destroy(other.gameObject);

        }

        //FIXME? Enemies collide with their own shots
        /*else if(other.tag == "EnemyBullets")
        {
            DestroyMe();
            Destroy(other.gameObject);
        }*/
    }

    virtual protected void DestroyMe()
    {
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollision : EnemyCollision
{

    public GameObject Fire;

    private int life = 2;

    protected override void DestroyMe()
    {
        life -= 1;
        if (life == 0)
        {
            StartCoroutine(SinkTheShip());
        } else
        {
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 0.5f;
            Instantiate(Fire, transform.position, transform.rotation);
        }
        

    }

    IEnumerator SinkTheShip()
    {
        GameObject fire = Instantiate(Fire,transform.position,transform.rotation);
        //fire.transform.localPosition = new Vector3(0,4,0);

        
        GetComponent<Rigidbody>().drag = 3;
        GetComponentInChildren<Animator>().SetBool("sinking", true);

        yield return new WaitForSeconds(1);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

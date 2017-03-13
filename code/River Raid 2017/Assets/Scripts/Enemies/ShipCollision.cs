using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollision : EnemyCollision
{

    public GameObject Fire;

    protected override void DestroyMe()
    {
        StartCoroutine(SinkTheShip());
    }

    IEnumerator SinkTheShip()
    {
        GameObject fire = Instantiate(Fire,transform.position,transform.rotation);
        //fire.transform.localPosition = new Vector3(0,4,0);

        
        GetComponent<Rigidbody>().drag = 3;

        /* transform.position = new Vector3(transform.position.x, -1f, transform.position.z);
         int i = 0;
         while(i < 50)
         {
             float currentX = transform.rotation.x;
             transform.Rotate(new Vector3(currentX + 1f, 0, 0));
             ++i;
             yield return new WaitForEndOfFrame();
         }
         */
        yield return new WaitForSeconds(1);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        Instantiate(Explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}

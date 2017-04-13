//Arno
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public AudioClip weaponSound;
    public float fireRate = .5f;

    public virtual void Fire(Transform position)
    {
        Instantiate(gameObject, position.position, position.rotation);
        if (weaponSound != null)
        {
            AudioSource.PlayClipAtPoint(weaponSound, transform.position);
        }
    }

    public virtual void Fire(Transform position, GameObject owner)
    {
        Instantiate(gameObject, position.position, position.rotation);
        if (weaponSound != null)
        {
            AudioSource.PlayClipAtPoint(weaponSound, transform.position);
        }

       // StartCoroutine(KillOnOwnerDestroyed(owner));
    }

    IEnumerator KillOnOwnerDestroyed(GameObject shooter)
    {
        while(true)
        {
            if(shooter == null)
            {
                Destroy(gameObject);
            }
            yield return new WaitForEndOfFrame();
        }
    }
}

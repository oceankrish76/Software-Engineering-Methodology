//Arno
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public AudioClip weaponSound;
    public float fireRate = .5f;

    public void Fire(Transform position)
    {
        Instantiate(gameObject, position.position, position.rotation);
        AudioSource.PlayClipAtPoint(weaponSound, transform.position);
    }
}

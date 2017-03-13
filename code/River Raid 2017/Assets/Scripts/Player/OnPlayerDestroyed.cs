using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerDestroyed : MonoBehaviour
{

    public GameObject explosion;
    public AudioClip explosionSound;

    private bool isQuitting = false;

    void OnApplicationQuit()
    {
        isQuitting = true;
    }

    void OnDestroy()
    {
        if (!isQuitting)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            FindObjectOfType<SimpleGameManager>().PlayerDied();
        }

    }
}

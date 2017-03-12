using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerDestroyed : MonoBehaviour {

    public GameObject explosion;
    public AudioClip explosionSound;

    void OnDestroy()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        FindObjectOfType<SimpleGameManager>().SetGameState(GameState.GAME_OVER);
    }
}

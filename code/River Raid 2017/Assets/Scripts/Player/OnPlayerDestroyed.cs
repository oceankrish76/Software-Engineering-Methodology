using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnPlayerDestroyed : MonoBehaviour {

    void OnDestroy()
    {
        FindObjectOfType<SimpleGameManager>().SetGameState(GameState.GAME_OVER);
    }
}

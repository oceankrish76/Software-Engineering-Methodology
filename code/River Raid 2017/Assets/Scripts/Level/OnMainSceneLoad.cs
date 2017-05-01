using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMainSceneLoad : MonoBehaviour {


	void Awake () {
        iTween.CameraFadeAdd();
        iTween.CameraFadeFrom(1f, .5f);
        FindObjectOfType<SimpleGameManager>().GetComponent<SimpleGameManager>().SetGameState(GameState.GAME);

    }
	

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMainSceneLoad : MonoBehaviour {


	void Awake () {

        FindObjectOfType<SimpleGameManager>().GetComponent<SimpleGameManager>().SetGameState(GameState.GAME);
	}
	

}

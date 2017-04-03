using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesLeft : MonoBehaviour {

    private Image[] lives;
    private int livesLeft;
    private SimpleGameManager manager;

	void Awake () {

        lives = GetComponentsInChildren<Image>();
        manager = FindObjectOfType<SimpleGameManager>();
        AdjustUI(manager.PlayerLives);
        manager.OnLivesChanged += new OnPlayerLivesChanged(AdjustUI);
 	}
	
    void AdjustUI(int amount)
    {
        for (int j =0; j < lives.Length; ++j)
        {
            lives[j].enabled= false;
        }
        for (int i = 0; i < amount; ++i)
        {
            lives[i].enabled = true;
        }
    }


    void OnDestroy()
    {
        // Unsubscribing from events when the scene is unloaded
        manager.OnLivesChanged -= AdjustUI;
    }
}

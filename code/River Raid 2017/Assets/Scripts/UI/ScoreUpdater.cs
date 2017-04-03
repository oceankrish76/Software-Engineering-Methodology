using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdater : MonoBehaviour {

    private SimpleGameManager manager;
	// Use this for initialization
	void Start () {

        manager = FindObjectOfType<SimpleGameManager>();
        manager.OnScoreChanged += new OnScoreChanged(UpdateScore);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void UpdateScore(int score)
    {
        GetComponent<Text>().text = score.ToString();
    }

    void OnDestroy()
    {
        // Unsubscribing from events when the scene is unloaded
        manager.OnScoreChanged -= UpdateScore;
    }
}

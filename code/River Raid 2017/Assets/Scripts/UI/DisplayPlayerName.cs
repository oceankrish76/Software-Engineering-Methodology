using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class DisplayPlayerName : MonoBehaviour {

    private SimpleGameManager manager;
    private string playerName;
    void Start()
    {
        manager = FindObjectOfType<SimpleGameManager>();
        playerName = manager.PlayerName;
        GetComponent<Text>().text = playerName;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInput : MonoBehaviour {

    private string playersname;
    private InputField input;
    private SimpleGameManager manager;


    public void Start()
    {
        input = GetComponent<InputField>();
        input.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

    }

    public void ValueChangeCheck()
    {
        playersname = input.text;
        //Greeting to the player
        Debug.Log("Hello, " + playersname + "Greetings from River Raid 2017!");

        manager = FindObjectOfType<SimpleGameManager>();
        manager.PlayerName = playersname;
    }

}

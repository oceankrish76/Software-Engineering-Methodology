using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetSoundToggleState : MonoBehaviour {

	// Use this for initialization
	void Start () {
        bool state = AudioListener.pause ? true : false;
        GetComponent<Toggle>().isOn = state;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

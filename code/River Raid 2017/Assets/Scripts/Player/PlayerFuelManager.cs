using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFuelManager : MonoBehaviour {

    public float consumptionSpeed = 0.01f;
    private SimpleGameManager manager;
	// Use this for initialization
	void Start () {

        manager = FindObjectOfType<SimpleGameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        manager.PlayerFuel -= consumptionSpeed;
	}
}

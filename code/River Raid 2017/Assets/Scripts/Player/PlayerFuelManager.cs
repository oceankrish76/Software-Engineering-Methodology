using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFuelManager : MonoBehaviour {

    public float consumptionSpeed = 13f;
    private SimpleGameManager manager;
	// Use this for initialization
	void Start () {

        manager = FindObjectOfType<SimpleGameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        manager.PlayerFuel -= consumptionSpeed;

        if(manager.PlayerFuel == 0f)
        {
            Destroy(gameObject);
        }
	}
}

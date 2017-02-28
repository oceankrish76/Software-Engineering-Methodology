using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelGauge : MonoBehaviour
{

    private Slider fuelGauge;
    private SimpleGameManager manager;
    // Use this for initialization
    void Awake()
    {
        fuelGauge = GetComponent<Slider>();
        manager = Object.FindObjectOfType<SimpleGameManager>();
        Debug.Log(manager);
    }

    // Update is called once per frame
    void Update()
    {
        fuelGauge.value = manager.GetComponent<SimpleGameManager>().PlayerFuel;
    }


}

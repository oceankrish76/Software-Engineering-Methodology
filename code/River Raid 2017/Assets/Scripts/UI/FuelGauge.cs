using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelGauge : MonoBehaviour
{

    private Slider fuelGauge;
    private SimpleGameManager manager;
    private float fuelLeft;

    private bool isPlayingSound = false;

    void Awake()
    {
        fuelGauge = GetComponent<Slider>();
        manager = Object.FindObjectOfType<SimpleGameManager>();
        //Initializing routines
        if (manager)
        {
            fuelLeft = manager.GetComponent<SimpleGameManager>().PlayerFuel;
            StartCoroutine(FuelLevelWarning());
        }
    }

    void Update()
    {
        if (manager)
        {
            fuelLeft = manager.GetComponent<SimpleGameManager>().PlayerFuel;
            fuelGauge.value = fuelLeft;
        }

    }

    //Since there's no real need to check this every frame,
    //let's save some on performance
    IEnumerator FuelLevelWarning()
    {
        while(true)
        {
            if (fuelLeft < 20f && !isPlayingSound)
            {
                Debug.Log("Playing fuel critical sound");
                GetComponent<AudioSource>().Play();
                isPlayingSound = true;
            }
            else if (fuelLeft > 20f && isPlayingSound)
            {
                GetComponent<AudioSource>().Stop();
                isPlayingSound = false;
            }
            yield return new WaitForSeconds(0.5f);
        }

    }
}

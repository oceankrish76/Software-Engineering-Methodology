using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{

    public GameObject GameManager;
   // public SoundManager SoundManager;

    void Awake()
    {
        Screen.SetResolution(600, 900, false);
        //Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
        if (SimpleGameManager.instance == null)
        {
            //Instantiate gameManager prefab
            Instantiate(GameManager);   
            
        } else
        {
            SimpleGameManager.instance = null;
            Instantiate(GameManager);
        }

        /*Check if a SoundManager has already been assigned to static variable GameManager.instance or if it's still null
        if (SoundManager.instance == null)
        {
            Instantiate(SoundManager);
        }*/
    }

}
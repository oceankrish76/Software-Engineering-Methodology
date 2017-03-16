using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour {

    public float speed = 0.005f;
    private Color original;


    void Start () {
       original  = GetComponent<Renderer>().material.color;
    }
	
	// Update is called once per frame
	void Update () {
        if(original.a > 0)
        {
            original.a -= speed;
            GetComponent<Renderer>().material.color = original;
        }

    }
}

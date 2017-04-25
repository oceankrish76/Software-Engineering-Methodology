using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Fade_InOut : MonoBehaviour {

    public float duration = 1.0f;
    //This can be only 0 or 1
    public float startingAlpha = 1.0f;
    private float lerp = 0.0f;
    private float alpha = 0.0f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lerpAlpha();
	}

    void lerpAlpha()
    {
        //The alternative for a flashing object (thanks StackOverflow)
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        alpha = Mathf.Lerp(1.0f, 0.0f, lerp);
        //If this is assigned to a UI thingummyjig (preferably text lol)
        Color color = GetComponent<Text>() ? gameObject.GetComponent<Text>().material.color : gameObject.GetComponent<Renderer>().material.color;
        color.a = 1f;

        if(GetComponent<Text>())
        {
            GetComponent<Text>().material.SetColor("_Color", color);
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", color);
        }
    }
}

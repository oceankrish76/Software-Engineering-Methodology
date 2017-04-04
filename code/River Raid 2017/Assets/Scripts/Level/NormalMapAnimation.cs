using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMapAnimation : MonoBehaviour
{


    private Renderer rend;
    private Object[] maps;
    private int i = 0;
    // Use this for initialization
    void Awake()
    {
        maps = Resources.LoadAll("WaveHeightMaps/");
        rend = GetComponent<Renderer>();
        StartCoroutine(AnimateNormalMap());
    }

    IEnumerator AnimateNormalMap()
    {
        while (true)
        {
            if (i == maps.Length) { i = 0; }

            Texture2D texture = (Texture2D)maps[i];
            rend.material.SetTexture("_BumpMap", texture);
            ++i;
            yield return new WaitForSecondsRealtime(0.05f);
        }
    }
}

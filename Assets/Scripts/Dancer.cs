using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dancer : MonoBehaviour
{
    public float power = 2;
    public float maxSize = 5;

    public Color startColor;
    public Color endColor;

    void Start()
    {
        Analyzer.onVolumeChanged.AddListener(Dance);
    }

    public void Dance(float volume)
    {
        transform.localScale = Vector3.one * (2f + Mathf.Pow(volume, power) * maxSize);

        var mixedColor = Color.Lerp(startColor, endColor, volume * 3f);

        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", mixedColor);

        if (true)
        {

        }
    }
}

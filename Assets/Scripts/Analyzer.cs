using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Analyzer : MonoBehaviour
{
    AudioSource source;
    public static UnityEvent<float> onVolumeChanged = new();
    void Start()
    {
        source = GetComponent<AudioSource>();
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        var samples = new float[735];
        source.clip.GetData(samples, source.timeSamples);

        var sum = 0f;
        for (int i = 0; i < samples.Length; i++)
        {
            sum += Mathf.Abs(samples[i]);
        }
        var average = sum / samples.Length;
        //print(average);

        onVolumeChanged.Invoke(average);

        /*if(average > 0.15f)
        {
            print("Beat");
        }*/
    }
}

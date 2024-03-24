using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDancer1 : MonoBehaviour
{
    public int count = 10;
    public float radius = 5f;
    public GameObject prefab;
    public int rotateSpeed = 360;
    public float sensitivity = 1f;

    void Start()
    {
        for (float i = 0; i < count; i++)
        {
            var angle = (i/count * Mathf.PI * 2f);
            var x = Mathf.Cos(angle);
            var y = Mathf.Sin(angle);
            var pos = new Vector3(x, y, 0) * (radius);

            var obj = Instantiate(prefab, pos, Quaternion.identity, transform);
            obj.transform.LookAt(transform);
        }

        Analyzer.onVolumeChanged.AddListener(Dance);
    }

    void Dance(float volume)
    {
        transform.Rotate(0, 0, Mathf.Pow(volume-2f, sensitivity) * Time.deltaTime * rotateSpeed);
        transform.localScale = Vector3.one * volume;
    }
}

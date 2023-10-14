using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sin : MonoBehaviour
{
    public float Frequency;
    public float Amplitude;
    public float Offset;

    public Vector3 startScale;

    private void Start()
    {
        transform.localScale = startScale;
    }
    void Update()
    {
        transform.localScale = startScale * (Mathf.Sin(Time.time * Frequency * 2 * Mathf.PI) * Amplitude + Offset);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject[] objectArray;
    public Light[] AllLight;
    public Rigidbody[] AllRigidbodies;
    public List<GameObject> ObjectList = new List<GameObject>();
    void Start()
    {
        AllRigidbodies = FindObjectsOfType<Rigidbody>();
        for (int i = 0; i < objectArray.Length; i++)
        {
            objectArray[i].GetComponent<Renderer>().material.color = Color.red;
            objectArray[i].AddComponent<Rigidbody>();
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            for (int i = 0; i < objectArray.Length; i++)
            {
                objectArray[i].GetComponent<Rigidbody>().AddForce(0f, 10f, 0f);
            }
            for (int i = 0; i < AllLight.Length; i++)
            {
                AllLight[i].color = Color.red;
            }
        }
        else
        {
            for (int i = 0; i < AllLight.Length; i++)
            {
                AllLight[i].color = Color.white;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private Transform player;
    public Transform ground;
    private Light myLight;
    public Color goodColor;
    public Color badColor;
 
    void Start()
    {
        player = FindObjectOfType<Player>().transform;
        myLight = GetComponent<Light>();
    }
 
    void Update()
    {
        //transform.position = new Vector3(player.position.x, transform.position.y, player.position.z);
        ChangeLightColor();
    }
 
    void ChangeLightColor()
    {
        float distanceToBoundary = GetMinDistanceToBound();
        float t = Mathf.InverseLerp(0, ground.localScale.x / 2, distanceToBoundary);
        Debug.Log(t);
        myLight.color = Color.Lerp(badColor, goodColor, t);
    }


    float GetMinDistanceToBound() => Mathf.Min(GetAllDistancesToBound());
 
    float[] GetAllDistancesToBound()
    {
        float zBound = ground.position.z + ground.localScale.z / 2;
        float xBound = ground.position.x + ground.localScale.x / 2;
        float[] bounds = {
            player.transform.position.x + xBound,
            xBound - player.transform.position.x,
            player.transform.position.z + zBound,
            zBound - player.transform.position.z,
        };
        return bounds;
    }


}


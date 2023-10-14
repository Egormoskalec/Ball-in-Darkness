using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isLose = false;
    private LightController[] allLightes;
    public static GameManager instance = null;
    private AudioController audioController;
 
    private void Awake()
    {
        if (instance == null) { 
	        instance = this; 
	    } else if(instance == this){ 
	        Destroy(gameObject); 
	    }
    }
 
    void Start()
    {
        allLightes = FindObjectsOfType<LightController>();
        audioController = FindObjectOfType<AudioController>();
    }
 
    public void Lose()
    {
        isLose = true;
        LightSwitch(false);
        audioController.PlayLoseSound();
    }
 
    public void RestartGame()
    {
        isLose = false;
        LightSwitch(true);
    }
 
    void LightSwitch(bool isLightOn)
    {
        foreach (LightController light in allLightes)
        {
            light.GetComponent<Light>().enabled = isLightOn;
        }
    }
}

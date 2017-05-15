using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour {

    public float flickeringLevel;
    public bool isFlickering;
    private Light light;
    private float maxIntensity;


    // Use this for initialization
    void Start () {
        light = gameObject.GetComponent<Light>();

        maxIntensity = light.intensity;
    }
	
	// Update is called once per frame
	void Update () {
        if (isFlickering & Random.Range(0, 100000) < 1000 * flickeringLevel)
        {
            float intensity = Random.Range(0, maxIntensity);
            light.intensity = intensity;
            flickerChildLights(intensity);
        }
	}

    private void flickerChildLights(float intensity)
    {
        foreach (Transform child in transform)
        {
            Light childLight = child.GetComponent<Light>();
            if (childLight != null) childLight.intensity = intensity;
        }
    }
}

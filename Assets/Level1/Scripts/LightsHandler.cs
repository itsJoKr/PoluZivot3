using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsHandler : MonoBehaviour {

    public List<GameObject> lights = new List<GameObject>();
    public AudioClip LightsOutSound;

    private bool lightsOut = false;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    void OnTriggerEnter()
    {
        if (!lightsOut) DimLights();
    }

    private void DimLights()
    {
        foreach (GameObject lightObject in lights)
        {
            Light light = lightObject.GetComponent<Light>();
            LightFlicker flicker = lightObject.GetComponent<LightFlicker>();
            if (light != null) light.intensity = 0.1f * light.intensity;
            if (flicker != null) flicker.isFlickering = false;
        }

        lightsOut = true;
        PlayLightsOutSound();
    }

    private void PlayLightsOutSound()
    {
        audioSource.PlayOneShot(LightsOutSound);
    }
}

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
            Debug.Log(lightObject.transform.parent.gameObject.name);
            Light light = lightObject.GetComponent<Light>();
            LightFlicker flicker = lightObject.GetComponent<LightFlicker>();
            GameObject bulb = lightObject.transform.parent.gameObject.name == "Bulb" ? lightObject.transform.parent.gameObject : null;
            if (light != null) light.enabled = false;
            if (flicker != null) flicker.isFlickering = false;
            if (bulb != null) UnlightBulb(bulb);
        }

        lightsOut = true;
        PlayLightsOutSound();
    }

    private void PlayLightsOutSound()
    {
        audioSource.PlayOneShot(LightsOutSound);
    }

    private void UnlightBulb(GameObject bulb)
    {
        Material mat = bulb.GetComponent<Renderer>().material;
        mat.SetColor("_EmissionColor", Color.black);
    }
}

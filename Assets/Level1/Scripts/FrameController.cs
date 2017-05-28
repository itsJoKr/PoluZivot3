using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameController : MonoBehaviour {

    public Texture flashTexture;    
    public float flashDuration = 0.2f;
    public List<GameObject> fireBurstParticles;
    public AudioClip burstSound;

    private AudioSource audioSource;
    private Material flashMaterial;
    private Material defaultMaterial;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        defaultMaterial = GetComponent<Renderer>().material;
        flashMaterial = new Material(Shader.Find("Standard"));
        flashMaterial.SetTexture("_MainTex", flashTexture);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Flash()
    {
        Invoke("RevertTexture", flashDuration);
        GetComponent<Renderer>().material = flashMaterial;
        BurstFire();
    }

    private void BurstFire()
    {
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(burstSound, 0.2f);

        foreach (GameObject gameObject in fireBurstParticles)
        {
            ParticleSystem ps = gameObject.GetComponent<ParticleSystem>();

            if (!ps.isPlaying)
                ps.Play();
        }
    }

    private void RevertTexture()
    {
        GetComponent<Renderer>().material = defaultMaterial;
    }
}

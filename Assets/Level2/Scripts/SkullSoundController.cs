using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullSoundController : MonoBehaviour {

    public AudioClip crashSound;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        AudioSource otherAudio = other.gameObject.GetComponent<AudioSource>();
        if (!audioSource.isPlaying && otherAudio != null && !otherAudio.isPlaying)
            audioSource.PlayOneShot(crashSound, Random.Range(0,60) / 100.0f);
    }
}

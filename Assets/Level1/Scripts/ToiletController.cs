using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletController : MonoBehaviour {

    public AudioClip flushSound;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Flush()
    {
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(flushSound);
    }
}

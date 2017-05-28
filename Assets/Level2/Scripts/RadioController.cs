﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour {

    public List<AudioClip> songs;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Play()
    {
        if (songs.Count < 1) return;

        int songIndex = Random.Range(0, songs.Count - 1);

        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(songs[songIndex]);
    }
}

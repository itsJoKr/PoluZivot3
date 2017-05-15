﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonterTriggerer : MonoBehaviour {

    public GameObject monster;
    public GameObject spotlight;
    public AudioClip spotlightSound;

    private bool monsterMoved;
    private bool spotlightOn;
    private AudioSource audioSource;
    
    void OnTriggerEnter()
    {
        audioSource = GetComponent<AudioSource>();
        if (!spotlightOn) TurnSpotlightOn();
        if (!monsterMoved) MonsterMove();
    }

    private void TurnSpotlightOn()
    {
        Light light = spotlight.GetComponent<Light>();
        audioSource.PlayOneShot(spotlightSound);
        if (light != null) light.intensity = 50;
        spotlightOn = true;
    }

    private void MonsterMove()
    {
        monster.GetComponent<Animator>().SetTrigger("Move");
        monsterMoved = true;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrower : MonoBehaviour {

    public float period = 2;
    public LevelFinishHandler levelFinish;

    private ParticleSystem particleSystem;
    private float nextFlameTime = 0.0f;

	// Use this for initialization
	void Start () {
        particleSystem = GetComponent<ParticleSystem>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (Time.time  > nextFlameTime)
        {
            nextFlameTime += period;
            particleSystem.Play();
        }
	}

    void OnTriggerStay(Collider other)
    {
        if (particleSystem.isPlaying)
            Die();
    }

    private void Die()
    {
        levelFinish.Die();
    }
}

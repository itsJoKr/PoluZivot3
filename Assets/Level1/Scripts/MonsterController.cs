using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

    public AudioClip kickSound;
    private Animator anim;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter()
    {
        anim.SetTrigger("Attack");
        audioSource.clip = kickSound;
        audioSource.PlayDelayed(0.8f);
    }
}

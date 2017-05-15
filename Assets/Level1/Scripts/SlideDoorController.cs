using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoorController : MonoBehaviour {

    public AudioClip slidingSound;
    public List<GameObject> lightsToDestroy;

    private AudioSource audioSource;
    private Animator anim;
    private bool isOpen;

    public bool IsOpen
    { 
        get { return this.isOpen; }
    }

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Open()
    {
        isOpen = true;
        audioSource.PlayOneShot(slidingSound);
        anim.SetTrigger("Open");
        DestroyLights();
    }

    private void DestroyLights()
    {
        foreach (GameObject light in lightsToDestroy)
            Destroy(light);
    }
}

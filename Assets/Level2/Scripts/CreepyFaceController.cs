using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepyFaceController : MonoBehaviour {

    public GameObject triggerDoor;
    public AudioClip soundEffect;

    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundEffect;
	}
	
	// Update is called once per frame
	void Update () {
		if (triggerDoor.GetComponent<Animator>().GetBool("Open"))
        {
            Invoke("Animate", 0.5f);
        }
	}

    void Animate()
    {
        GetComponent<Animator>().SetTrigger("Float");
        if (!audioSource.isPlaying)
        {
            audioSource.PlayDelayed(0.5f);
        }
    }
}

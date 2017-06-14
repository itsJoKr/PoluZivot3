using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FallDetector : MonoBehaviour {

    public AudioClip splatSound;

    private Collider playerCollider;
    private AudioSource aSrc;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        LevelFinishHandler lFinishHandler = other.GetComponent<LevelFinishHandler>();

        if (other.tag == "Player" && lFinishHandler != null)
        {
            playerCollider = other;
            aSrc = playerCollider.GetComponent<AudioSource>();
            Invoke("Splat", 1.5f);
            Invoke("DisablePlayer", 0.5f);
            lFinishHandler.DieWithGameFinish();
            aSrc.volume = 0;
        }
    }

    private void Splat()
    {
        FirstPersonController fpc = playerCollider.GetComponent<FirstPersonController>();

        aSrc.volume = 1;
        if (!aSrc.isPlaying)
            aSrc.PlayOneShot(splatSound);

        fpc.UnlockCursor();
    }

    private void DisablePlayer()
    {
        playerCollider.GetComponent<FirstPersonController>().enabled = true;
    }
}

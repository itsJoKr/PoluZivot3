using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Controller : MonoBehaviour {

    public AudioClip pickUpSound;
    public AudioClip openAttemptSound;
    public AudioClip unlockAttemptSound;
    public AudioClip openDoorSound;
    public AudioClip openSafeSound;

    private AudioSource audioSource;
    private Raycaster raycaster;
    private bool hasDoorKey;
    private bool hasSafeKey;
    private bool isDoorOpen;
    private bool isSafeOpen;


    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        raycaster = transform.GetComponent<Raycaster>();
        if (MusicManager.MM != null)
            MusicManager.MM.PlayLevelMusic(2);
    }
	
	// Update is called once per frame
	void Update () {
        GameObject hitObject = raycaster.GetHitObject();

        if (Input.GetMouseButton(0) && hitObject != null)
        {
            switch (hitObject.name)
            {
                case "Doorway":
                    HandleDoorOpen(hitObject);
                    break;
                case "Key":
                case "Door Key":
                    TakeKey(hitObject);
                    break;
                case "Radio":
                    HandlePlayRadio(hitObject);
                    break;
                case "Safe Door":
                    HandleSafeOpen(hitObject);
                    break;
            }
        }
    }

    private void HandleSafeOpen(GameObject safe)
    {
        if (!hasSafeKey)
            AttemptDoorUnlock();
        else if (!isSafeOpen)
        {
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(openSafeSound);
            safe.GetComponent<Animator>().SetTrigger("Open");
            isSafeOpen = true;
        }
    }

    private void HandlePlayRadio(GameObject radio)
    {
        radio.GetComponent<RadioController>().Play();
    }

    private void TakeKey(GameObject key)
    {
        Debug.Log(key.name);
        if (!hasDoorKey && key.name == "Door Key")
            hasDoorKey = true;
        else if (!hasSafeKey && key.name == "Key")
            hasSafeKey = true;

        Destroy(key);
        audioSource.PlayOneShot(pickUpSound);
    }

    private void HandleDoorOpen(GameObject doorWay)
    {
        if (!hasDoorKey)
            HandleDoorFail();
        else if (!isDoorOpen)
        {
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(openDoorSound);
            doorWay.GetComponent<Animator>().SetTrigger("Open");
            isDoorOpen = true;
        }
    }

    private void HandleDoorFail()
    {
        if (hasSafeKey)
        {
            raycaster.SetInfoLabel("The key doesn't fit");
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(unlockAttemptSound, 0.5f);
        }
        else
        {
            AttemptDoorUnlock();
        }
    }

    private void AttemptDoorUnlock()
    {
        raycaster.SetInfoLabel("The door is locked");
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(openAttemptSound, 0.5f);
    }
}

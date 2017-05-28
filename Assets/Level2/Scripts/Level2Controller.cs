using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2Controller : MonoBehaviour {

    public AudioClip pickUpSound;
    public AudioClip openAttemptSound;
    public AudioClip unlockAttemptSound;

    private AudioSource audioSource;
    private Raycaster raycaster;
    private bool hasDoorKey;
    private bool hasSafeKey;


    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        raycaster = transform.GetComponent<Raycaster>();
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
            HandleSafeFail();
        else
            safe.GetComponent<Animator>().SetTrigger("Open");
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
        else
            doorWay.GetComponent<Animator>().SetTrigger("Open");
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
            raycaster.SetInfoLabel("The door is locked");
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(openAttemptSound, 0.5f);
        }
    }

    private void HandleSafeFail()
    {
        throw new NotImplementedException();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Level2Controller : MonoBehaviour {

    public AudioClip pickUpSound;
    public AudioClip openAttemptSound;
    public AudioClip unlockAttemptSound;
    public AudioClip openDoorSound;
    public AudioClip openSafeSound;
    public AudioClip elevatorSound;

    private GameObject radio;
    private AudioSource audioSource;
    private Raycaster raycaster;
    private bool hasDoorKey;
    private bool hasSafeKey;
    private bool isDoorOpen;
    private bool isSafeOpen;
    private bool isElevatorDown;

    private Transform controllerParent;

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
                case "Button":
                    if (ElevatorManager.canPush)
                        HandleElevator(hitObject);
                    break;
            }
        }
    }

    private void HandleElevator(GameObject elevatorBtn)
    {
        if (isElevatorDown) return;

        Transform elevator = elevatorBtn.transform.parent;

        transform.parent.parent = elevator;
        elevator.gameObject.GetComponent<Animator>().SetTrigger("Go");
        isElevatorDown = true;
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(elevatorSound);
        if (radio != null)
            // turn off the radio so we don't hear it through whole scene
            radio.GetComponent<RadioController>().TurnOffWithDelay(2);
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
        this.radio = radio;
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
            doorWay.GetComponent<Animator>().SetTrigger("Open");
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(openDoorSound);
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

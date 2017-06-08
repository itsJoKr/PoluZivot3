using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Level1Controller : MonoBehaviour {
    
    public AudioClip useToiletSound;
    public AudioClip pickUpSound;
    public AudioClip openDoorAttempt;

    private AudioSource audioSource;
    private Raycaster raycaster;
    private GameObject toilet;
    private bool hasKey;

    // Use this for initialization
    void Start ()
    {
        raycaster = transform.GetComponent<Raycaster>();
        audioSource = GetComponent<AudioSource>();
        if (MusicManager.MM != null)
            MusicManager.MM.PlayLevelMusic(1);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject hitObject = raycaster.GetHitObject();

        if (Input.GetMouseButton(0) && hitObject != null)
        {
            switch (hitObject.name)
            {
                case "Door":
                    HandleDoorOpen(hitObject);
                    break;
                case "Slide Door":
                    HandleSlideDoor(hitObject);
                    break;
                case "Toilet Seat":
                    HandleToilet(hitObject);
                    break;
                case "Key":
                    TakeKey(hitObject);
                    break;
            }
        }
    }


    private void HandleSlideDoor(GameObject slideDoor)
    {
        if (!hasKey) AttemptToOpenSlideDoor();
        else OpenSlideDoor(slideDoor);
    }

    private void TakeKey(GameObject key)
    {
        if (!hasKey)
        {
            hasKey = true;
            audioSource.PlayOneShot(pickUpSound);
            Destroy(key);
        }
    }

    private void HandleToilet(GameObject toilet)
    {
        // easter egg joke
        if (!audioSource.isPlaying)
        {
            GetComponentInParent<FirstPersonController>().ForceStop();
            this.toilet = toilet;
            audioSource.PlayOneShot(useToiletSound);
            Invoke("FlushToilet", useToiletSound.length);
        }
    }

    private void HandleDoorOpen(GameObject door)
    {
        DoorController doorController = door.GetComponent<DoorController>();
        if (doorController != null) doorController.Open();
    }

    private void FlushToilet()
    {
        GetComponentInParent<FirstPersonController>().ForceStart();
        if (toilet != null) toilet.GetComponent<ToiletController>().Flush();
    }

    private void AttemptToOpenSlideDoor()
    {
        raycaster.SetInfoLabel("The door is locked");
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(openDoorAttempt);
    }

    private void OpenSlideDoor(GameObject slideDoor)
    {
        SlideDoorController doorController = slideDoor.GetComponent<SlideDoorController>();
        if (!doorController.IsOpen)
            doorController.Open();
    }
}

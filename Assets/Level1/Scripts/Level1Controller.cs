using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Controller : MonoBehaviour {
    
    public AudioClip shittingSound;
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
    }

    // Update is called once per frame
    void Update()
    {
        GameObject hitObject = raycaster.GetHitObject();

        if (Input.GetMouseButton(0) && hitObject != null)
        {
            if (hitObject.name == "Door") HandleDoorOpen(hitObject);
            if (hitObject.name == "Slide Door") HandleSlideDoor(hitObject);
            if (hitObject.name == "Toilet Seat") HandleToilet(hitObject);
            if (hitObject.name == "Key") TakeKey(hitObject);
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
        if (!audioSource.isPlaying)
        {
            GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
            this.toilet = toilet;
            audioSource.PlayOneShot(shittingSound);
            Invoke("FlushToilet", shittingSound.length);
        }
    }

    private void HandleDoorOpen(GameObject door)
    {
        DoorController doorController = door.GetComponent<DoorController>();
        if (doorController != null) doorController.Open();
    }

    private void FlushToilet()
    {
        GetComponentInParent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = true;
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

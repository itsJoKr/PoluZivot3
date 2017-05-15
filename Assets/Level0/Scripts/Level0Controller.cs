using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level0Controller : MonoBehaviour {

    public GameObject gameManager;
    public AudioClip pickUpSound;
    public AudioClip slurpSound;
    public AudioClip unlockSound;
    public AudioClip openSound;

    private AudioSource audioSource;
    private Raycaster raycaster;
    private bool hasKey;

    public bool HasKey { get; set; }

    // Use this for initialization
    void Start () {
        raycaster = transform.GetComponent<Raycaster>();
        hasKey = false;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        GameObject hitObject = raycaster.GetHitObject();

        if (Input.GetMouseButton(0) && hitObject != null)
        {
            if (hitObject.name == "Key") HandleKeyClick(hitObject);
            else if (hitObject.name == "Drawer") HandleDrawerClick(hitObject);
            else if (hitObject.name == "Door") HandleDoorClick();
            else if (hitObject.name == "Milk") HandleMilkClick();
            else if (hitObject.name == "BagLSD" || hitObject.name == "LSD") GoToNextLevel();
        }
	}

    private void GoToNextLevel()
    {
        FlickerLamp();
        gameManager.GetComponent<LevelManager>().LoadNextLevel();
    }

    private void FlickerLamp()
    {
        GameObject gameObject = GameObject.Find("Lamp Light");
        LightFlicker flicker = gameObject.GetComponent<LightFlicker>();
        flicker.flickeringLevel = 25;
        flicker.isFlickering = true;
    }
    
    private void HandleKeyClick(GameObject key)
    {
        PlaySFX(pickUpSound);
        Destroy(key);
        hasKey = true;
    }

    private void HandleDrawerClick(GameObject drawer)
    {
        DrawerController drawerController = drawer.GetComponent<DrawerController>();
        if (hasKey)
        {
            if (drawerController.IsLocked) drawerController.Unlock();
            else drawerController.Open();
        }
        else
        {
            PlaySFX(openSound);
            raycaster.SetInfoLabel("The drawer is locked");
        }
    }

    private void HandleDoorClick()
    {
        if (hasKey)
        {
            PlaySFX(unlockSound, 0.6f);
            raycaster.SetInfoLabel("Can't unlock this door");
        }
        else
        {
            PlaySFX(openSound, 0.4f);
            raycaster.SetInfoLabel("Locked");
        }
    }

    private void HandleMilkClick()
    {
        PlaySFX(slurpSound, 0.4f);
        Invoke("SetNotThirstyLabel", 1);
    }

    private void SetNotThirstyLabel()
    {
        raycaster.SetInfoLabel("You are not thirsty anymore");
    }

    private void PlaySFX(AudioClip clip, float volume = 1)
    {
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(clip, volume);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerController : MonoBehaviour
{
    private AudioSource audioSource;
    private Vector3 initialPosition;
    private bool isOpening;
    private bool isUnlocking;

    public AudioClip unlockSound;
    public AudioClip openingSound;

    private bool isLocked;
    public bool IsLocked { get; private set; }

    private bool isOpen;
    public bool IsOpen { get; private set; }

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        initialPosition = transform.position;
        IsOpen = false;
        IsLocked = true;
        isOpening = false;
        isUnlocking = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (!IsLocked && isOpening) Pull();
	}

    public void Unlock()
    {
        if (!isUnlocking)
        {
            isUnlocking = true;
            audioSource.clip = unlockSound;
            audioSource.Play();
            Invoke("SetUnlocked", unlockSound.length);
        }
    }

    public void Open()
    {
        if (!IsLocked && !isUnlocking && !IsOpen)
        {
            isOpening = true;
            audioSource.clip = openingSound;
            audioSource.Play();
        }
    }

    private void Pull()
    {
        if (isOpening && transform.position.z < initialPosition.z + 0.7)
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        else if (!IsLocked && isOpening)
        {
            IsOpen = true;
            isOpening = false;
        }
    }

    private void SetUnlocked()
    {
        IsLocked = false;
        isUnlocking = false;
    }
}

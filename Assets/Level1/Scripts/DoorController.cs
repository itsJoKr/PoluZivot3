using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public float maxOpenAngle = 90;
    public float openSpeed = 10;
    public AudioClip openSound;

    private AudioSource audioSource;
    private float openAngle = 0;
    private bool isOpening = false;
    
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if (isOpening && openAngle <= maxOpenAngle)
        {
            Push();
        }
	}

    public void Open()
    {
        isOpening = true;
        if (!audioSource.isPlaying)
            audioSource.PlayOneShot(openSound, 0.2f);
    }

    private void Push()
    {
        float rotateByValue = openSpeed * Time.deltaTime;
        openAngle += rotateByValue;
        transform.RotateAround(transform.GetChild(0).position, new Vector3(0, 1, 0), rotateByValue);
    }
}

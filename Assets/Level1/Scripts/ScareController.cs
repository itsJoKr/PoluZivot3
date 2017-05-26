using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareController : MonoBehaviour {

    public GameObject scareObject;
    public Camera camera;
    public float cameraSpeed = 1;
    public float duration = 2;
    public AudioClip scareSound;

    private AudioSource audioSource;
    private Vector3 cameraStartPosition;
    private bool scare;

	// Use this for initialization
	void Start () {
        cameraStartPosition = camera.transform.position;
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!scare) return;
        camera.depth = 10;

        camera.transform.position = Vector3.MoveTowards(camera.transform.position,
            scareObject.transform.position, cameraSpeed * Time.deltaTime);
    }

    public void Engage()
    {
        scare = true;
        audioSource.PlayOneShot(scareSound);
        Invoke("Stop", duration);
    }

    private void Stop()
    {
        scare = false;
        camera.transform.position = cameraStartPosition;
        camera.depth = -10;
    }
}

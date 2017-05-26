using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameFlashTriggerer : MonoBehaviour {

    public GameObject frame;
    public bool flashOnce;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter()
    {
        if (frame != null)
            frame.GetComponent<FrameController>().Flash();

        if (frame != null && flashOnce)
            frame = null;
    }
}

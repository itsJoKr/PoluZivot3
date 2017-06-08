using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDetector : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        LevelFinishHandler lFinishHandler = other.GetComponent<LevelFinishHandler>();

        if (other.tag == "Player" && lFinishHandler != null)
        {
            lFinishHandler.DieWithGameFinish();
        }
    }
}

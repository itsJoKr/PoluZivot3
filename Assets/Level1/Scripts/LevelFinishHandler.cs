using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinishHandler : MonoBehaviour {

    public GameObject gameManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.name == "End Part")
            GoToNextLevel();
    }

    private void GoToNextLevel()
    {
        gameManager.GetComponent<LevelManager>().LoadNextLevel();
    }
}

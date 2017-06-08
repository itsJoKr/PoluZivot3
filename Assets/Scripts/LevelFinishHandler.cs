using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class LevelFinishHandler : MonoBehaviour {

    public GameObject gameManager;

    private LevelManager levelManager;
    private FirstPersonController fpsController;

	// Use this for initialization
	void Start () {
        levelManager = gameManager.GetComponent<LevelManager>();
        fpsController = GetComponent<FirstPersonController>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.name == "End Part")
        {
            GoToNextLevel();
        }
        else if (other.name == "Monster Mesh")
        {
            fpsController.ForceStop();
            Invoke("Die", 2f);
        }            
    }

    private void GoToNextLevel()
    {
        levelManager.LoadNextLevel();
    }

    public void Die()
    {
        fpsController.UnlockCursor();
        fpsController.enabled = false;
        levelManager.SetGameOver();
    }

    public void DieWithGameFinish()
    {
        fpsController.UnlockCursor();
        fpsController.enabled = false;
        levelManager.SetGameFinished();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour {

    public AudioClip creditsMusic;

	// Use this for initialization
	void Start () {
        MusicManager.MM.PlaySituationClip(creditsMusic);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("Menu");
        }

    }
}

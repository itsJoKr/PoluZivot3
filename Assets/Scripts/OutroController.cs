using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OutroController : MonoBehaviour {

    public AudioClip outroMusic;
    public AudioClip bell;

	// Use this for initialization
	void Start ()
    {
        GetComponent<AudioSource>().PlayOneShot(bell);
        Invoke("PlayMusic", 4);
        MusicManager.MM.StopAll();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Return))
        {
            SceneManager.LoadScene("Credits");
        }
	}

    private void PlayMusic()
    {
        GetComponent<AudioSource>().PlayOneShot(outroMusic);
    }
}

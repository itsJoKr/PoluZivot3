using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareTriggerer : MonoBehaviour {

    public GameObject scareController;
    public AudioClip suspenseMusic;
    public bool scareOnce;

    private bool engaged = false;

	void OnTriggerEnter()
    {
        if (scareOnce && !engaged)
        {
            if (MusicManager.MM != null)
                MusicManager.MM.PlaySituationClip(suspenseMusic);
            Invoke("Scare", suspenseMusic.length + 1);
            engaged = true;
        }
    }

    void Scare()
    {
        scareController.GetComponent<ScareController>().Engage();

        if (!scareOnce)
            engaged = false;
    }
}

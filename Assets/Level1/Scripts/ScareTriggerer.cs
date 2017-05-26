using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareTriggerer : MonoBehaviour {

    public GameObject scareController;
    public bool scareOnce;

	void OnTriggerEnter()
    {
        if (scareController != null)
        {
            scareController.GetComponent<ScareController>().Engage();
        }

        if (scareOnce)
            scareController = null;
    }
}

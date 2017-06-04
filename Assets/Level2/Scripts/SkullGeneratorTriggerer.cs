using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullGeneratorTriggerer : MonoBehaviour {

    public GameObject skullGenerator;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter()
    {
        if (skullGenerator != null)
        {
            skullGenerator.GetComponent<SkullGenerator>().GenerateSkulls();
            skullGenerator = null;
        }
    }
}

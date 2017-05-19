using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToiletTrigger : MonoBehaviour {

    public GameObject toilet;
    private bool flushed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter()
    {
        if (!flushed)
        {
            toilet.GetComponent<ToiletController>().Flush();
            flushed = true;
        }
    }
}

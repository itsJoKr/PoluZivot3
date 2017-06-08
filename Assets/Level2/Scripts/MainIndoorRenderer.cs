using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainIndoorRenderer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        transform.parent.gameObject.GetComponent<MeshRenderer>().enabled = true;
    }
}

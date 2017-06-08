using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorManager : MonoBehaviour {
    
    public static bool canPush;
        
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        canPush = true;
        if (other.tag == "Player")
            other.transform.parent = transform.parent;
    }


    void OnTriggerExit(Collider other)
    {
        canPush = false; ;
        if (other.tag == "Player")
            other.transform.parent = null;
    }
}

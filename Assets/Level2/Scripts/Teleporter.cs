using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour {

    public GameObject destinationTeleporter;
    public GameObject crosshair;
    public bool autoTeleport;

    private bool canTeleport;
    private Transform teleportingObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (canTeleport && !autoTeleport && Input.GetKeyUp(KeyCode.T))
        {
            Teleport();
        }
	}

    private void Teleport()
    {
        Quaternion currRotation = teleportingObject.rotation;
        Quaternion destRotation = destinationTeleporter.transform.rotation;
        Vector3 destPosition = destinationTeleporter.transform.position;
        teleportingObject.position = new Vector3(destPosition.x, destPosition.y + 1, destPosition.z);
        //teleportingObject.rotation = Quaternion.AngleAxis(destRotation.eulerAngles.y - 90, Vector3.up);
    }

    void OnTriggerEnter(Collider other)
    {
        teleportingObject = other.transform;
        canTeleport = true;
        if (!autoTeleport)
            SetInfoLabel("Press T to teleport");
        else
            Teleport();
    }

    void OnTriggerExit(Collider other)
    {
        canTeleport = false;
        if (!autoTeleport)
            SetInfoLabel("");
    }

    private void SetInfoLabel(string text)
    {
        crosshair.GetComponent<GUICrosshair>().instructionLabelText = null;
        crosshair.GetComponent<GUICrosshair>().instructionLabelText = text;
    }
}

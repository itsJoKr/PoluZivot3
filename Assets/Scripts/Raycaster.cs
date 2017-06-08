using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycaster : MonoBehaviour {
    private RaycastHit hit;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
        if (Physics.SphereCast(transform.position, 0.1f, transform.forward, out hit, 2.5f))
        {
            switch (hit.transform.name)
            {
                case "Key":
                case "Door Key":
                    SetCrosshairLabel("Take the key");
                    break;
                case "Door":
                case "Slide Door":
                case "Doorway":
                case "Safe Door":
                case "Drawer":
                    SetCrosshairLabel("Open the " + hit.transform.name.ToLower());
                    break;
                case "Milk":
                    SetCrosshairLabel("Drink some milk");
                    break;
                case "BagLSD":
                    SetCrosshairLabel("Take the LSD");
                    break;
                case "Toilet Seat":
                    SetCrosshairLabel("Use a toilet");
                    break;
                case "Radio":
                    SetCrosshairLabel("Turn on");
                    break;
                case "Button":
                    if (ElevatorManager.canPush)
                        SetCrosshairLabel("Push");
                    break;
                default:
                    SetCrosshairLabel(null);
                    SetInfoLabel(null);
                    break;
            }
        } else
        {
            SetCrosshairLabel(null);
            SetInfoLabel(null);
        }
    }

    public GameObject GetHitObject()
    {
        if (Physics.SphereCast(transform.position, 0.1f, transform.forward, out hit, 2.5f))
        {
            return hit.transform.gameObject;
        }

        return null;
    }

    public void SetInstructionLabel(string text)
    {
        transform.GetChild(0).GetComponent<GUICrosshair>().instructionLabelText = text;
    }

    public void SetInfoLabel(string text)
    {
        transform.GetChild(0).GetComponent<GUICrosshair>().infoLabelText = text;
    }

    private void SetCrosshairLabel(string text)
    {
        transform.GetChild(0).GetComponent<GUICrosshair>().labelText = text;
    }
}

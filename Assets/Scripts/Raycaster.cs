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
                    SetCrosshairLabel("Take the key");
                    break;
                case "Door":
                    SetCrosshairLabel("Open the door");
                    break;
                case "Milk":
                    SetCrosshairLabel("Drink some milk");
                    break;
                case "Drawer":
                    SetCrosshairLabel("Open the drawer");
                    break;
                case "BagLSD":
                    SetCrosshairLabel("Take the LSD");
                    break;
            }
        }
        else
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

    public void SetInfoLabel(string text)
    {
        transform.GetChild(0).GetComponent<GUICrosshair>().infoLabelText = text;
    }

    private void SetCrosshairLabel(string text)
    {
        transform.GetChild(0).GetComponent<GUICrosshair>().labelText = text;
    }
}

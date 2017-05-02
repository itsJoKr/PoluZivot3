using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUICrosshair : MonoBehaviour {

    public Texture2D crosshairTexture;
    public float crosshairScale = 1;
    public string labelText = null;
    public string infoLabelText = null;

    GUIStyle mainLabelStyle;
    GUIStyle infoLabelStyle;

    void Start()
    {
        mainLabelStyle = new GUIStyle();
        infoLabelStyle = new GUIStyle();

        mainLabelStyle.fontSize = 18;
        mainLabelStyle.normal.textColor = Color.white;

        infoLabelStyle.fontSize = 24;
        infoLabelStyle.normal.textColor = Color.yellow;
    }

    void OnGUI()
    {
        //if not paused
        if (Time.timeScale != 0)
        {
            if (crosshairTexture != null)
            {
                GUI.DrawTexture(new Rect((Screen.width - crosshairTexture.width * crosshairScale) / 2, (Screen.height - crosshairTexture.height * crosshairScale) / 2, crosshairTexture.width * crosshairScale, crosshairTexture.height * crosshairScale), crosshairTexture);
                if (labelText != null && labelText.Length > 0)
                    GUI.Label(new Rect(Screen.width / 2 + 20, (Screen.height - crosshairTexture.height * crosshairScale) / 2, 200, 20), new GUIContent(labelText), mainLabelStyle);
                if (infoLabelText != null && infoLabelText.Length > 0)
                    GUI.Label(new Rect(Screen.width / 2 + 20, (Screen.height - crosshairTexture.height * crosshairScale) / 2 + 30, 300, 20), new GUIContent(infoLabelText), infoLabelStyle);
            }
            else
                Debug.Log("No crosshair texture set in the Inspector");
        }
    }
}

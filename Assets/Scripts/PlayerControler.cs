using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour {

    public Texture2D fadeTexture;
    public float fadeSpeed = 0.2f;
    public int drawDepth = -1000;
    public string nextLevel;

    private float alpha = 0.0f;
    private int fadeDir = 1;
    private bool hasKey;
    private Raycaster raycaster;
    private bool drawerOpen;
    private Vector3 drawerStartPosition;
    private GameObject drawer;
    private bool fadeOut = false;

    public bool HasKey { get; set; }

    // Use this for initialization
    void Start () {
        raycaster = transform.GetComponent<Raycaster>();
        hasKey = false;
        drawerOpen = false;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject hitObject = raycaster.GetHitObject();

        if (Input.GetMouseButton(0) && hitObject != null)
        {
            if (hitObject.name == "Key")
            {
                Destroy(hitObject);
                hasKey = true;
            }
            else if (hitObject.name == "Drawer")
            {
                if (hasKey)
                {
                    if (!drawerOpen)
                        StartPullingDrawer(hitObject);
                }
                else
                    raycaster.SetInfoLabel("The drawer is locked");
            }
            else if (hitObject.name == "Door")
            {
                if (hasKey)
                    raycaster.SetInfoLabel("Can't unlock this door");
                else
                    raycaster.SetInfoLabel("Locked");
            }
            else if (hitObject.name == "Milk")
            {
                raycaster.SetInfoLabel("You are not thirsty anymore");
            }
            else if (hitObject.name == "BagLSD" || hitObject.name == "LSD")
            {
                GoToNextLevel();
            }
        }

        PullDrawer();
	}

    void OnGUI()
    {
        if (fadeOut)
        {
            alpha += fadeDir * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);

            Color thisAlpha = GUI.color;
            thisAlpha.a = alpha;
            GUI.color = thisAlpha;
            GUI.depth = drawDepth;
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
        }
    }

    private void StartPullingDrawer(GameObject drawer)
    {
        this.drawer = drawer;
        drawerStartPosition = drawer.transform.position;
        drawerOpen = true;
    }

    private void PullDrawer()
    {
        if (drawerOpen && drawer.transform.position.z < drawerStartPosition.z + 0.7)
        {
            drawer.transform.Translate(Vector3.left * Time.deltaTime);
        }
    }

    private void GoToNextLevel()
    {
        fadeOut = true;
        Invoke("LoadNextLevel", 3.0f);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}

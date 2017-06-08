using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    private float alpha = 0.0f;
    private int fadeDir = 1;
    private bool fadeOut = false;

    public GameObject crosshair;
    public Texture2D fadeTexture;
    public float fadeSpeed = 0.2f;
    public int drawDepth = -1000;
    public string nextLevel;
    public float loadLevelDelay = 3.0f;
    public GameObject gameOverCanvas;
    public GameObject gameFinishedCanvas;
    public GameObject UICamera;
    public GameObject UICameraFin;

    // Use this for initialization
    void Start ()
    {
        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(false);
        if (gameFinishedCanvas != null)
            gameFinishedCanvas.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI()
    {
        if (fadeOut) FadeOut();
    }

    public void LoadNextLevel()
    {
        fadeOut = true;
        Invoke("LoadNextScene", loadLevelDelay);
    }

    public void ReloadLevel()
    {
        loadLevelDelay = 2;
        fadeOut = true;
        Invoke("ReloadScene", loadLevelDelay);
    }

    public void SetGameOver()
    {
        Destroy(crosshair);
        if (gameOverCanvas != null)
            gameOverCanvas.SetActive(true);
        UICamera.GetComponent<Camera>().depth = Camera.main.depth + 1;
    }

    internal void SetGameFinished()
    {
        Destroy(crosshair);
        if (gameOverCanvas != null)
            Destroy(gameOverCanvas);
        if (gameFinishedCanvas != null)
            gameFinishedCanvas.SetActive(true);
        UICameraFin.GetComponent<Camera>().depth = Camera.main.depth + 1;
    }

    private void FadeOut()
    {
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        Color thisAlpha = GUI.color;
        thisAlpha.a = alpha;
        GUI.color = thisAlpha;
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }
    
    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}

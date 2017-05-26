using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameController : MonoBehaviour {

    public Texture flashTexture;
    public float flashDuration = 0.2f;

    private Material flashMaterial;
    private Material defaultMaterial;

	// Use this for initialization
	void Start () {
        defaultMaterial = GetComponent<Renderer>().material;
        flashMaterial = new Material(Shader.Find("Standard"));
        flashMaterial.SetTexture("_MainTex", flashTexture);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Flash()
    {
        GetComponent<Renderer>().material = flashMaterial;
        Invoke("RevertTexture", flashDuration);
    }

    private void RevertTexture()
    {
        GetComponent<Renderer>().material = defaultMaterial;
    }
}

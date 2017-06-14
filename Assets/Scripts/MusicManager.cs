using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public static MusicManager MM;

    public AudioClip menuIntroMusic;
    public AudioClip level1Music;
    public AudioClip level2Music;

    private AudioSource audioSource;
    private AudioClip currentLevelClip;

    private bool fadingOut;
    private float FadeTime = 2;

    void Awake()
    {
        if (MM != null)
            Destroy(MM);
        else
            MM = this;

        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 0.5f;
        currentLevelClip = menuIntroMusic;
        PlayMusic(currentLevelClip);
    }
	
	// Update is called once per frame
	void Update () {
        if (fadingOut && audioSource.volume > 0)
        {
            audioSource.volume -= 0.5f * Time.deltaTime / FadeTime;
        }

        if (audioSource.volume <= 0)
        {
            audioSource.volume = 0.5f;
            fadingOut = false;
        }
    }

    public void PlayLevelMusic(int level)
    {
        switch (level)
        {
            case 1:
                currentLevelClip = level1Music;
                PlayMusic(currentLevelClip);
                break;
            case 2:
                currentLevelClip = level2Music;
                PlayMusic(currentLevelClip);
                break;
        }
    }

    public void PlaySituationClip(AudioClip ac, bool loop = false)
    {

        //StartCoroutine(FadeSoundOut(audioSource, 0.2f));
        FadeTime = 0.5f;
        fadingOut = true;
        audioSource.clip = ac;
        audioSource.loop = loop;
        audioSource.PlayDelayed(FadeTime);
        Invoke("ContinueLevelMusic", ac.length + FadeTime);
    }

    public void ContinueLevelMusic()
    {
        PlayMusic(currentLevelClip);
    }

    void PlayMusic(AudioClip ac)
    {
        float delay = 2;

        if (audioSource.clip != null)
        {
            FadeTime = delay;
            fadingOut = true;
            //StartCoroutine(FadeSoundOut(audioSource, delay));
        }
        else
            delay = 0;

        audioSource.clip = ac;
        audioSource.loop = true;
        audioSource.PlayDelayed(delay);
    }
    
    public void StopAll()
    {
        audioSource.Stop();
    }

    //IEnumerator FadeSoundOut(AudioSource audioSource, float FadeTime)
    //{
    //    float startVolume = audioSource.volume;

    //    if (audioSource.volume > 0)
    //    {
    //        audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

    //        yield return null;
    //    }

    //    audioSource.volume = startVolume;
    //}    
}

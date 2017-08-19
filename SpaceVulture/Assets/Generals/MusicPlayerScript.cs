using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayerScript : MonoBehaviour {

    static MusicPlayerScript instance = null;

    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;
    private AudioSource musicSource;

	void Start () {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        } else
        {
            instance = this;
            GameObject.DontDestroyOnLoad(gameObject);
            musicSource = GetComponent<AudioSource>();
            musicSource.clip = startClip;
            musicSource.loop = true;
            musicSource.Play();
        }
        SceneManager.activeSceneChanged += OnSceneLoaded;

	}

    private void OnDestroy()
    {
        SceneManager.activeSceneChanged -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene oldScene, Scene newScene)
    {
        
        //
        // gets the curent scene
        //
        Scene thisScene = SceneManager.GetActiveScene();
        //
        //gets the build index number of the screen
        //
        int level = thisScene.buildIndex;

        musicSource.Stop();
        if (level == 0)
        {
            musicSource.clip = startClip;
        }
        if (level == 1)
        {
            musicSource.clip = gameClip;
        }
        if (level == 2)
        {
            musicSource.clip = endClip;
        }
        musicSource.loop = true;
        musicSource.Play();

    }

}

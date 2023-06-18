using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    GameObject BackgroundMusic;
    AudioSource backmusic;

    void Awake()
    {
        BackgroundMusic = GameObject.Find("Background Music");
        backmusic = BackgroundMusic.GetComponent<AudioSource>(); 
        if (backmusic.isPlaying)
        {
            return; 
        }
        else
        {
            backmusic.Play();
            DontDestroyOnLoad(BackgroundMusic);
        }
    }
}

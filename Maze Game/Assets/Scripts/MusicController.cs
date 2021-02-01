using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public AudioSource winMusic;
    public AudioSource loseMusic;

    public bool bms = true;
    public bool wms = false;
    public bool lms = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackgroundMusic()
    {
        bms = true;
        wms = false;
        lms = false;
        backgroundMusic.Play();
    }

    public void WinMusic()
    {
        if(backgroundMusic.isPlaying)
            bms = false;
            {
                backgroundMusic.Stop();
            }
            if(!winMusic.isPlaying && wms == false)
            {
                winMusic.Play();
                wms = true;
            }
    }

    public void LoseMusic()
    {
        if(backgroundMusic.isPlaying)
            bms = false;
            {
                backgroundMusic.Stop();
            }
            if(!loseMusic.isPlaying && lms == false)
            {
                loseMusic.Play();
                lms = true;
            }
    }
}

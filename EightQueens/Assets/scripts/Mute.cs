using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mute : MonoBehaviour {

    public AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void MuteSound()
    {
        if (audio.mute == false)
        {
            audio.mute = true;
        }
        else if (audio.mute == true)
        {
            audio.mute = false;
        }
        
    }
}

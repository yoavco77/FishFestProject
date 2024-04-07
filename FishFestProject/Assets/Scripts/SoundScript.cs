using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    AudioSource[] audio;
    void Start()
    {
        audio = GetComponents<AudioSource>();
    }

    public void playSound()
    {
        audio[0].Play();
    }
    public void playSound(int index)
    {
        audio[index].Play();
    }

    
}

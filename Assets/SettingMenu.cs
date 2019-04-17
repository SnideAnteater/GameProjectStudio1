using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingMenu : MonoBehaviour
{
    public AudioSource audioSc;
    private float musicVolume = 1f;

    void Start()
    {
        audioSc = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSc.volume = musicVolume;
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public static BGMManager Instance { get; private set; }
    AudioSource audioSource;
    public AudioClip bgm;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(this.gameObject);

        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayMusic()
    {
        audioSource.PlayOneShot(bgm);
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }
}

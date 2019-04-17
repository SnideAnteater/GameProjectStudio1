using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public float playTime = 0.5f;
    public float pauseTime = 0.5f;
    private AudioSource sfx;

    void Start()
    {
        sfx = GetComponent<AudioSource>();
        StartCoroutine("PlayPauseCoroutine");
    }

    IEnumerator PlayPauseCoroutine()
    {
        while (true)
        {
            sfx.Play();
            yield return new WaitForSeconds(playTime);
            sfx.Pause();
            yield return new WaitForSeconds(pauseTime);
        }
    }
}

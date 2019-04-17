using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip sfx;
    AudioSource audioSc;
    public int everySeconds;
    bool keepPlaying = true;

     void Start()
    {
       SoundOut();
    }

   IEnumerable SoundOut()
    {
        yield return new WaitForSeconds(everySeconds);
        {
            audioSc.PlayOneShot(sfx);
            Debug.Log("SFX played");
        }   
    }
}

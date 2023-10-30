using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource _audio;

    public AudioClip[] ClickSounds;

    private void Start()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void OnClickSoundButton()
    {
         
        int randomIndex = Random.Range(0, ClickSounds.Length);
        _audio.PlayOneShot(ClickSounds[randomIndex]);  
    }
}

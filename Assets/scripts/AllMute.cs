using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMute : MonoBehaviour
{
    public void ToggleMute()
    {
        AudioListener.pause = !AudioListener.pause; 
    }
}

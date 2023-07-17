using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlaySound: MonoBehaviour
{    
     public void Play(AudioClip audioClip)
     {
        AudioPlayer.instance.Play(audioClip);
     }
}

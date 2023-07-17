using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public GameObject clon;
    public AudioClip clip;
    private void Start()
    {
        SoundPlayer.regit.sorse.PlayOneShot(clip,2);
    }
    public void Ded()
    {
        Destroy(clon);
    }
}

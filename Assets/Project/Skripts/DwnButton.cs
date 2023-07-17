using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DwnButton : MonoBehaviour
{
    public float speed = 0.5f;
    public AudioClip clip;
    public Animator anim, torture;

    public void OnClick()
    {
        SoundPlayer.regit.sorse.PlayOneShot(clip,3);
        // Destroy(this);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            torture.SetFloat("Speed", speed);
            anim.SetFloat("Speed", 1);
        }
    }
}

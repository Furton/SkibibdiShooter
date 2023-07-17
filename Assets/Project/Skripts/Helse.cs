using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helse : MonoBehaviour
{
    public AudioClip mau, dedy;
    public GameObject dad;
    public Animator anim;
    public float helse;
    private float timer;
    public void DamaGe() {
        if (helse <= 0)
        {
            SoundPlayer.regit.sorse.PlayOneShot(dedy,7.0f);
            Instantiate(dad,transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            SoundPlayer.regit.sorse.PlayOneShot(mau,7.0f);
            helse -= 10;
            anim.SetBool("Damage", true);
        }
        
    }
    public void Reload() {
        anim.SetBool("Damage", false);
    }
    void Update()
    {
    }
}

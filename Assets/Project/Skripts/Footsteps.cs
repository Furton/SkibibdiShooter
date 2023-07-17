using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {
    public float volume;
    public float maxDist = 40;
	public AudioClip[] clip;
    public void Step()
    {
        float dist = Vector3.Distance(Muwer.rid.transform.position, transform.position);
        int num = Random.Range(0, clip.Length-1);
        if (dist < 40)
        {
            SoundPlayer.regit.sorse.PlayOneShot(clip[num], ((maxDist -dist)/maxDist)-volume);
        }
    }
}

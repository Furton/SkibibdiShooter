using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge;

public class Masager : MonoBehaviour
{
    public AudioClip clip;
    public TipeOfMasage tipe;
    public enum TipeOfMasage {state, dinamic}
    [SerializeField] private Language language;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Bridge.platform.language == "ru")
            {
                Subtitres.regit.subtitres = language.ru;
            }
            else
            {
                Subtitres.regit.subtitres = language.en;
            }
            if (tipe == TipeOfMasage.state)
            {
                Destroy(gameObject);
            }
            SoundPlayer.regit.sorse.PlayOneShot(clip);
        }
    }
}

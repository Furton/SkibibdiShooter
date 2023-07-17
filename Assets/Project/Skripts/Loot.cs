using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge;

public class Loot : MonoBehaviour
{
    [SerializeField] private Language language;
    public AudioClip clip;
    public Data data;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SoundPlayer.regit.sorse.PlayOneShot(clip);
            int mas = Random.Range(1,5);
            if (Bridge.platform.language == "ru")
            {
                Subtitres.regit.subtitres = language.ru + " + " + mas;
            }
            else
            {
                Subtitres.regit.subtitres = language.en + " + " + mas; ;
            }
            data.bulets += mas;
            Destroy(gameObject);
        }
    }
}

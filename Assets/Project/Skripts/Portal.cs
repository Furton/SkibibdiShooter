using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge;
public class Portal : MonoBehaviour
{
    public AudioClip clip;
    [SerializeField] private Language language;

    public Animator anim;
    public GameObject[] energi;
    private int num;

    public static Portal rid { get; set; }
    void Awake()
    {
        if (rid == null)
        {
            rid = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void OnDestroy()
    {
        rid = null;
    }
    public void Andlevel()
    {
        Interface.rid.AndLVL();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (num >= energi.Length)
            {
                anim.SetFloat("Speed", 1);
            }
            else
            {
                SoundPlayer.regit.sorse.PlayOneShot(clip);
                if (Bridge.platform.language == "ru")
                {
                    Subtitres.regit.subtitres = language.ru;
                }
                else
                {
                    Subtitres.regit.subtitres = language.en;
                }
            }
        }
        
        if (other.tag == "Soul")
        {
            UpEnergi();
            Destroy(other.gameObject);
        }
    }
    public void UpEnergi()
    {
        if (num <= energi.Length - 1)
        {
            energi[num].SetActive(true);
            num += 1;
        }
    }
}

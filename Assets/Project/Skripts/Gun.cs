using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Data data;
    public float helse = 10;
    public AudioClip clip, damage, ded;
    public Animator anim;
    public static Gun rid { get; set; }
    private bool relod = false;
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

    public void Ded()
    {
        if (!anim.GetBool("Ded"))
        {
            Muwer muwer = Muwer.rid;
            muwer.enabled = false;
            anim.SetBool("Ded", true);
            SoundPlayer.regit.sorse.PlayOneShot(ded);
            helse = 0;
        }
    }
    public void GameOver()
    {
        Interface iF = Interface.rid;
        iF.GameOver();
        Destroy(this);
    }
    public void Shut() {
        if (!relod)
        {
            if (data.bulets > 0)
            {
                data.bulets -= 1;
                anim.SetBool("Shut", true);
                SoundPlayer.regit.sorse.PlayOneShot(clip);
                relod = true;
                RaycastHit hit;
                Ray ray = new Ray(transform.position, transform.forward);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.tag == "Enemy")
                    {
                        hit.collider.GetComponent<DamagSensor>().Damag();
                    }
                }
            }
            else
            {
                Interface.rid.NullBK();
            }
        }   
    }
    public void Damage()
    {
        if (helse > 1)
        {
            SoundPlayer.regit.sorse.PlayOneShot(damage);
            relod = true;
            anim.SetBool("Damage", true);
            helse -= Random.Range(1,3);
        }
        else
        {
            Ded();
        }
    }
    public void Reload() {
        anim.SetBool("Shut", false);
        relod = false;
        anim.SetBool("Damage", false);
    }
}

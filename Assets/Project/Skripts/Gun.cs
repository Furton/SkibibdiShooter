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

    private void Ded()
    {
            Muwer muwer = Muwer.rid;
            muwer.enabled = false;
            anim.SetTrigger("dead");
            SoundPlayer.regit.sorse.PlayOneShot(ded);
            helse = 0;
            Invoke("GameOver", 0.9f);
    }

    private void GameOver()
    {
        Interface iF = Interface.rid;
        iF.GameOver();
        Destroy(this);
    }


    public void Shut() {
            if (data.bulets > 0)
            {
                data.bulets -= 1;
                anim.SetTrigger("shoot");
                SoundPlayer.regit.sorse.PlayOneShot(clip);
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


    public void Damage()
    {
        if (helse > 1)
        {
            SoundPlayer.regit.sorse.PlayOneShot(damage);
            anim.SetTrigger("damage");
            helse -= Random.Range(1,3);
        }
        else
        {
            Ded();
        }
    }
}

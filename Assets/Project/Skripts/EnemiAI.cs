using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiAI : MonoBehaviour {
    public AudioClip udar;
    public Data data;
    public GameObject onDestroy;
    public GameObject[] loot;
    public AudioClip ded;
	public float speed, stopDist, helse = 10;
	public Animator anim;
	public Transform player;
	public NavMeshAgent agent;
    private bool damage;
    private void Start()
    {
        player = Muwer.rid.transform;
        agent.speed = speed;
        if (data.record < 10)
        {
            speed = 1 + data.record;
        }
        else
        {
            speed = 10;
        }
    }
    public void OnKick()
    {
        if (player.GetComponentInChildren<Gun>())
        {
            var lokker = player.position - transform.position;
            lokker.y = 0;
            transform.rotation = Quaternion.LookRotation(lokker);
            if (Vector3.Distance(player.position, transform.position) <= stopDist)
            {
                player.GetComponentInChildren<Gun>().Damage();
            }
        }
        else
        {
            player = null;
        }
    }
    public void Damage()
    {
        if (helse > 1)
        {
            anim.SetBool("Damage", true);
            helse -= Random.Range(1, 3);
        }
        else
        {
            anim.SetBool("Ded", true);
        }
        damage = true;
        agent.isStopped = true;
    }
    public void Ded()
    {
        int num = Random.Range(0, loot.Length);
        Instantiate(loot[num], transform.position, Quaternion.identity);
        SoundPlayer.regit.sorse.PlayOneShot(ded);
        data.record += 1;
        Destroy(onDestroy);
    }
    public void Resed()
    {
        damage = false;
        anim.SetBool("Damage", false);
        agent.isStopped = false;
    }

    void Update () {
        anim.SetFloat ("Speed", agent.velocity.magnitude/6);
        agent.speed = speed;
        if (!damage)
        {
            if (player != null)
            {
                if (Vector3.Distance(player.position, transform.position) <= stopDist)
                {
                    agent.isStopped = true;
                    anim.SetBool("Run", false);
                    anim.SetBool("Kik", true);
                }
                else
                {
                    agent.isStopped = false;
                    anim.SetBool("Run", true);
                    anim.SetBool("Kik", false);
                }
                agent.destination = player.position;
            }
            else
            {
                agent.isStopped = true;
                anim.SetBool("Run", false);
                anim.SetBool("Kik", false);
            }
        }
	}
}

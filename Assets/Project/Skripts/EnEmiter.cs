using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnEmiter : MonoBehaviour
{
    public GameObject enemy;
    public float interval;

    private float timer;
    private bool active = true;
    private void Start()
    {
        timer = Time.time;
    }
    void Emit()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
        timer = Time.time;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            active = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            active = true;
        }
    }
    private void Update()
    {
        if (active)
        {
            if (Time.time > (timer + interval))
            {
                Emit();
            }
        }
    }
}

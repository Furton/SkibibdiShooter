using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guner : MonoBehaviour
{
    public float interval;
    private float timer;
    public void ToucherDown()
    {
        timer = Time.time;
    }
    public void ToucherUp()
    {
        float tim = Time.time - timer;
        if (tim < interval)
        {
            Gun.rid.Shut();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagSensor : MonoBehaviour
{
    public EnemiAI ai;
    public void Damag()
    {
        ai.Damage();
    }
}

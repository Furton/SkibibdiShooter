using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Gun.rid.Damage();
        }
        if (other.gameObject.tag == "Enemi")
        {
            other.GetComponent<EnemiAI>().Damage();
        }
    }
}

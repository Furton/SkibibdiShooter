using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{

    void Start()
    {
        Invoke("DestroyObject", 0.7f);
    }

    
    void DestroyObject()
    {
        Destroy(gameObject);
    }
}

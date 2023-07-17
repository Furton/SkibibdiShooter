using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSkript : MonoBehaviour
{
    public Animator anim;
    public bool open;

    void Update()
    {
        anim.SetBool("Open", open);
    }
}

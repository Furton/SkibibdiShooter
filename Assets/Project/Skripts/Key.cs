using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public DoorSkript durOne, durTwo;
    public Animator anim;
    public MeshRenderer render;
    public Material one, two;
    public bool open;

    private void Start()
    {
        Rekey();
    }
    public void Kik()
    {
        anim.SetFloat("Speed", 1);
        open = !open;
    }
    public void Rekey()
    {
        durOne.open = open;
        durTwo.open = !open;
        anim.SetFloat("Speed", 0);
        if (open)
        {

            render.material = one;
        }
        else
        {
            render.material = two;
        }
    }
}

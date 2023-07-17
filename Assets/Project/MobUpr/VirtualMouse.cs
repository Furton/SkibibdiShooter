using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirtualMouse : MonoBehaviour
{
    public float spector;
    public Muwer muwer;
    public Touch touch;
    private float tim;
    private Vector2 pos;
    void Start()
    {
        spector = Screen.height / 2;
        muwer = Muwer.rid;
    }
    void Ondrag()
    {
        if (tim < 0.1f)
        {
            tim += Time.deltaTime;
        }
        else {
            tim = 0;
            pos = touch.position;
        }
        if (touch.phase == TouchPhase.Ended)
        {
            OffDrag();
        }
        muwer.rut = touch.position - pos;
    }
    public void OffDrag()
    {
        muwer.rut = Vector2.zero;
    }
    void Update()
    {
        if (touch.phase == TouchPhase.Began)
        {
            pos = touch.position;
        }
        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Vector3.Distance(Input.GetTouch(i).position, transform.position) < spector)
            {
                touch = Input.GetTouch(i); 
                Ondrag();
            }
        }
    }
}

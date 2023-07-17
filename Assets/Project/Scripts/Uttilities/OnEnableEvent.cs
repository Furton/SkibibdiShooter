using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnEnableEvent : MonoBehaviour
{
    public UnityEvent EnableEvent, DisableEvent;
    
    void OnEnable()
    {
        EnableEvent.Invoke();
    }

    void OnDisable()
    {
        DisableEvent.Invoke();
    }
}

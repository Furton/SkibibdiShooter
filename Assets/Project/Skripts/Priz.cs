using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Priz : MonoBehaviour
{
    public Data data;
    public Text text;
    private float timer;
    private void OnEnable()
    {
        timer = 50;
    }

    public void AdPatroni()
    {
        data.bulets += (int)timer;
    }
    void Update()
    {
        text.text = "+ " + (int)timer;
        if (timer > 0)
        {
            timer -= Time.unscaledDeltaTime;
        }
    }
}

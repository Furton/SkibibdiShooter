using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Priz : MonoBehaviour
{
    public Data data;
    public Text text;
    private float timer;
    private float speed;

    private void OnEnable()
    {
        timer = 60;
        speed = 1;
    }

    public void AdPatroni()
    {
        data.bulets += (int)timer;
        SaveAndLoad.Instance.Save();
    }


    void Update()
    {

        if (timer <= 10)
        {
            speed = -1;
        }
        if (timer >= 60)
        {
            speed = 1;
        }
        timer -= speed * Time.unscaledDeltaTime;
        text.text = "+ " + (int)timer;
    }
}

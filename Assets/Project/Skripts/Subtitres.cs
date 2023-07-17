using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Subtitres : MonoBehaviour
{
    public float interval = 3.0f;
    public Image fon;
    public Text titres;
    public string subtitres { get; set; }
    public float timer { get; set; }
    public static Subtitres regit { get; set; }

    void Awake()
    {
        OffTitres();
        if (regit == null)
        {
            regit = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void OnDestroy()
    {
        regit = null;
    }
    void OnTitres()
    {
        titres.text = subtitres;
        fon.enabled = true;
    }
    void OffTitres()
    {
        subtitres = "";
        titres.text = subtitres;
        fon.enabled = false;
    }
    void Update()
    {
        if (timer >= interval)
        {
            OffTitres();
            timer = 0;
        }
        if (subtitres != "")
        {
            OnTitres();
            timer += Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using pEventBus;
using InstantGamesBridge;

public class AutoSave : MonoBehaviour
{
    public GameObject adsPanel, pauseObject;
    public Text pauseText;
    public Language adsPanelL;


    float _time;
    string adsPanelLString, secondsString;


    void Start()
    {



        _time = Time.unscaledTime - 70f;

        if (Bridge.platform.language == "ru")
        {
            adsPanelLString = adsPanelL.ru;
        }
        else
        {
            adsPanelLString = adsPanelL.en;
        }

        StartCoroutine(SaveEnum());
    }

    private IEnumerator SaveEnum()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(5f);
            SaveAndLoad.Instance.Save();
            Show();
        }
    }



    private void Show()
    {
        if (Time.unscaledTime - _time >= 80f)
        {
            _time = Time.unscaledTime;
            StartCoroutine(ShowEnum());
        }
    }

    private IEnumerator ShowEnum()
    {
        pauseObject.SetActive(true);
        pauseText.text = adsPanelLString + " 3";
        yield return new WaitForSecondsRealtime(1f);
        pauseText.text = adsPanelLString + " 2";
        yield return new WaitForSecondsRealtime(1f);
        pauseText.text = adsPanelLString + " 1";
        adsPanel.SetActive(true);
        Time.timeScale = 0;
        Muwer.rid.muve = Vector2.zero;
        Muwer.rid.rut = Vector2.zero;
        yield return new WaitForSecondsRealtime(1f);
        adsPanel.SetActive(false);
        pauseObject.SetActive(false);
        Time.timeScale = 1;
        Muwer.rid.muve = Vector2.zero;
        Muwer.rid.rut = Vector2.zero;
        EventBus<ShowInterAds>.Raise(new ShowInterAds()
        {

        });
    }
}

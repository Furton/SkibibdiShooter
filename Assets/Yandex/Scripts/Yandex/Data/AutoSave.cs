using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using pEventBus;
using InstantGamesBridge;

public class AutoSave : MonoBehaviour
{
    public GameObject adsPanel, pauseObject;
    public Text adsPanelText;
    public Language adsPanelL;


    float _time;
    string adsPanelLString, secondsString;


    void Start()
    {



        _time = Time.unscaledTime - 60f;

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
        adsPanel.SetActive(true);
        adsPanelText.text = adsPanelLString + " 3";
        yield return new WaitForSecondsRealtime(1f);
        adsPanelText.text = adsPanelLString + " 2";
        yield return new WaitForSecondsRealtime(1f);
        adsPanelText.text = adsPanelLString + " 1";
        pauseObject.SetActive(true);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(1f);
        adsPanel.SetActive(false);
        pauseObject.SetActive(false);
        Time.timeScale = 1;
        EventBus<ShowInterAds>.Raise(new ShowInterAds()
        {

        });
    }
}

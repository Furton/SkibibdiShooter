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

    private float scale = 1;


    string adsPanelLString, secondsString;


    void Start()
    {
        if (Bridge.platform.language == "ru")
        {
            adsPanelLString = adsPanelL.ru;
        }
        else
        {
            adsPanelLString = adsPanelL.en;
        }
        StartCoroutine(SaveEnum());
        StartCoroutine(AutoShowEnum());
    }

    private IEnumerator SaveEnum()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(2f);
            SaveAndLoad.Instance.Save();
        }
    }

    private IEnumerator AutoShowEnum()
    {        
        yield return new WaitForSecondsRealtime(9f);
        Show();
        while (true)
        {
            yield return new WaitForSecondsRealtime(80f);
            Show();
        }
    }



    private void Show()
    {
            StartCoroutine(ShowEnum());
    }

    private IEnumerator ShowEnum()
    {
        Interface.rid.isAds = true;
        scale = Time.timeScale;
        pauseObject.SetActive(true);
        pauseText.text = adsPanelLString + " 3";
        yield return new WaitForSecondsRealtime(0.73f);
        pauseText.text = adsPanelLString + " 2";
        yield return new WaitForSecondsRealtime(0.73f);
        pauseText.text = adsPanelLString + " 1";
        adsPanel.SetActive(true);
        Time.timeScale = 0;
        Muwer.rid.muve = Vector2.zero;
        Muwer.rid.rut = Vector2.zero;
        yield return new WaitForSecondsRealtime(0.75f);
        adsPanel.SetActive(false);
        pauseObject.SetActive(false);
        Time.timeScale = 0;
        Muwer.rid.muve = Vector2.zero;
        Muwer.rid.rut = Vector2.zero;
        Time.timeScale = scale;
        Interface.rid.isAds = false;
        EventBus<ShowInterAds>.Raise(new ShowInterAds()
        {

        });
    }
}

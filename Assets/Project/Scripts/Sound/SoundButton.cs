using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    [SerializeField] private  Sprite soundIsOn, soundIsOff;

    [SerializeField] private Button butt;
    [SerializeField] private Image im;


    private void Start()
    {
        butt.onClick.AddListener(Change);
        SetSprite(!AudioPlayer.instance.GetMuteState());
    }

    private void SetSprite(bool stateTemp)
    {
        if (stateTemp)
        {
            im.sprite = soundIsOn;
        }
        else
        {
            im.sprite = soundIsOff;
        }
    }

    private void OnDestroy()
    {
            butt.onClick.RemoveListener(Change);
    }

    private void Change()
    {
        AudioPlayer.instance.SetMuteState(!AudioPlayer.instance.GetMuteState());
        SetSprite(!AudioPlayer.instance.GetMuteState());
    }
}

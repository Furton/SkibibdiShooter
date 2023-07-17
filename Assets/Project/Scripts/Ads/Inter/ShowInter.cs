using UnityEngine;
using InstantGamesBridge;
using InstantGamesBridge.Modules.Advertisement;
using InstantGamesBridge.Modules.Platform;




public class ShowInter: MonoBehaviour
{

    private bool isMute = false;

    void OnEnable()
    {
        Bridge.advertisement.interstitialStateChanged += Interstitial;
        Events.OnShowInterAds += Show;
    }

    void OnDisable()
    {
        Bridge.advertisement.interstitialStateChanged -= Interstitial;
        Events.OnShowInterAds -= Show;
    }

    private void Show()
    {
            var ignoreDelay = false;
            Bridge.advertisement.ShowInterstitial(ignoreDelay);
    }

    private void Interstitial(InterstitialState state)
    {
        if (state == InterstitialState.Closed)
        {
            AudioPlayer.instance.SetMuteState(isMute);
        }
        if (state == InterstitialState.Opened)
        {
            isMute = AudioPlayer.instance.GetMuteState();
            AudioPlayer.instance.SetMuteState(true);
        }
    }
}
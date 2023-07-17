using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge;
using InstantGamesBridge.Modules.Advertisement;
using UnityEngine.Events;

public class Reward : MonoBehaviour
{
    public UnityEvent OnReward;

    private bool isRewarded, isMute;

    private float scale;

    void OnEnable()
    {
        Bridge.advertisement.rewardedStateChanged += MyReward;
        isRewarded = false;
    }

    void OnDisable()
    {
        Bridge.advertisement.rewardedStateChanged -= MyReward;
    }

    public void ShowReward()
    {
        Bridge.advertisement.ShowRewarded();
    }

    void MyReward(RewardedState state)
    {

        if (state == RewardedState.Opened)
        {
            isMute = AudioPlayer.instance.GetMuteState();
            AudioPlayer.instance.SetMuteState(true);
        }

        if (state == RewardedState.Rewarded)
        {
            isRewarded = true;
        }

        if (state == RewardedState.Closed)
        {
            AudioPlayer.instance.SetMuteState(isMute);


            if (isRewarded)
            {
                isRewarded = false;
                OnReward.Invoke();
            }
        }
    }
}
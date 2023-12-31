using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge;
using InstantGamesBridge.Modules.Leaderboard;
using InstantGamesBridge.Modules.Player;
using pEventBus;


public struct OnLoadIsComplete : IEvent
{

}


public class SaveAndLoad : MonoBehaviour
{
    public static SaveAndLoad Instance { get; private set; }

    [SerializeField] private Data myData;
    [SerializeField] private string id;

    private float  record;


    public void Load()
    {
        Bridge.storage.Get(id, OnGetCompleted);
        StartCoroutine(AutoShowEnum());
    }

    public void Save()
    {
            string data = JsonUtility.ToJson(myData);
            Bridge.storage.Set(id, data, success =>
            {
                if(record < myData.record)
                {
                    record = myData.record;
                    SetBoard();
                }
            });
    }


    private void SetBoard()
    {
        var _yandexLeaderboardNameInput = "LEADER1";
        Bridge.leaderboard.SetScore(
            success =>
            {

            },
            new SetScoreYandexOptions(myData.record, _yandexLeaderboardNameInput));
    }


    public void Reset()
    {
        SetInitValue();
        Bridge.storage.Delete(id, success =>
        {
        });
    }

    void SetInitValue()
    {
        myData.record = 1;
        myData.tempRecord = 1;
        myData.bulets = 30;
        myData.soundOn = true;
    }


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        record = 0;
    }

    private void OnGetCompleted(bool success, string data)
    {
        if (success && data != null)
        {
            JsonUtility.FromJsonOverwrite(data, myData);
        }
        else
        {
            SetInitValue();
        }

        if (myData.bulets <= 3)
        {
            myData.bulets = 25;
        }

        EventBus<OnLoadIsComplete>.Raise(new OnLoadIsComplete()
        {

        });
    }

    private IEnumerator AutoShowEnum()
    {
        yield return new WaitForSecondsRealtime(8.5f);
        Events.OnShow?.Invoke();
        while (true)
        {
            yield return new WaitForSecondsRealtime(80f);
            Events.OnShow?.Invoke();
        }
    }


}

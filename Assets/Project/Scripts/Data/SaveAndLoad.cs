using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InstantGamesBridge;
using InstantGamesBridge.Modules.Leaderboard;
using InstantGamesBridge.Modules.Player;
using InstantGamesBridge.Common;
using InstantGamesBridge.Modules.Storage;



public class SaveAndLoad : Singleton<SaveAndLoad>
{
    public static SaveAndLoad Instance { get; private set; }


    [SerializeField] private string id = "defID";
    private Data myData;


    private float time;



    public void Load()
    {       
        Bridge.storage.Get(id, OnGetCompleted, StorageType.LocalStorage);
    }

    public void Save()
    {
        if (Time.unscaledTime >= time + 2f)
        {
            time = Time.unscaledTime;
            SetBoard();

        }

        string data = JsonUtility.ToJson(myData);
        Bridge.storage.Set(id, data, OnStorageSetCompleted, StorageType.LocalStorage);
    }

    private void OnStorageSetCompleted(bool success)
    {

    }


    private void SetBoard()
    {
        var _yandexLeaderboardNameInput = "LEADER1";
        Bridge.leaderboard.SetScore(
            success =>
            {

            },
            new SetScoreYandexOptions(myData.coins, _yandexLeaderboardNameInput));
    }

    private void SetToInitValues()
    {
        myData.skinNumber = 0;
        myData.backNumber = 0;


        myData.clickCost = 10;
        myData.clickUpgrateCost = 100;

        myData.autoClickCost = 20;
        myData.autoClickUpgrateCost = 150;

        myData.coins = 0;
        myData.skinCost = 200;

        myData.backCost = 200;
}


    public void Reset()
    {
        SetToInitValues();
        Bridge.storage.Delete(id, OnStorageDeleteCompleted, StorageType.LocalStorage);
    }

    void OnStorageDeleteCompleted(bool succes)
    {

    }


    protected override void Awake()
    {
        base.Awake();
        myData = Resources.Load<Data>("Data");
        time = Time.unscaledTime - 2f;
    }

    private void OnGetCompleted(bool success, string data)
    {
        if (success && data != null)
        {
            JsonUtility.FromJsonOverwrite(data, myData);
        }
        else
        {
            SetToInitValues();
        }

        Events.OnLoadComplete?.Invoke();

    }


}

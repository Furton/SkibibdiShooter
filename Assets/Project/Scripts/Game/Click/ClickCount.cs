using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCount : MonoBehaviour
{

    public Data data;
    public IntObject multiplier;

    void Start()
    {
        StartCoroutine(AutoClick());
    }

    public void Click()
    {
        data.coins += data.clickCost*multiplier.myInt;
        SaveAndLoad.instance.Save();
        Events.OnUpdateUI?.Invoke();
        Events.OnAddCoins?.Invoke(data.clickCost * multiplier.myInt);
    }

    private IEnumerator AutoClick()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            data.coins += data.autoClickCost * multiplier.myInt;
            SaveAndLoad.instance.Save();
            Events.OnUpdateUI?.Invoke();
            Events.OnAddCoins?.Invoke(data.autoClickCost * multiplier.myInt);
        }
    }
}

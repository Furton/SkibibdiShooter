using UnityEngine;
using UnityEngine.UI;
using InstantGamesBridge;

public class RewardMultiplier : MonoBehaviour
{
    public Text multiplierText;
    public Language coinReward;
    public Data data;
    public IntObject multiplier;

    private string coinRewardString;


    void Start()
    {
        if (Bridge.platform.language == "ru")
        {
            coinRewardString = coinReward.ru;
        }
        else
        {
            coinRewardString = coinReward.en;
        }

        multiplier.myInt = 1;

        Set();
    }

    void OnEnable()
    {
        Events.OnUpdateUI += Set;
    }

    void OnDsable()
    {
        Events.OnUpdateUI -= Set;
    }


    void Set()
    {
        multiplierText.text = $"{multiplier.myInt + 1}" + "x " + coinRewardString;
        
    }

    public void Reward()
    {
        multiplier.myInt++;
        SaveAndLoad.instance.Save();
        Events.OnUpdateUI?.Invoke();
    }
}

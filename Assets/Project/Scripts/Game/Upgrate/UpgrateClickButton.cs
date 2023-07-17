using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using InstantGamesBridge;

public class UpgrateClickButton : MonoBehaviour
{
    public enum TypeEnum { click, sec };
    public TypeEnum typeEnum = TypeEnum.click;


    public int delta = 1;
    public float upgrateMultiplier = 1.5f;
    public Language upgrade, forL, type;
    public Text buttonText;
    public Data data;

    private Button myButton;
    private string upgradeString, forLString, typeString;

    void Awake()
    {
        myButton = GetComponent<Button>();
    }
    
    void OnEnable()
    { 
        Events.OnUpdateUI += Check;
    }

    void OnDisable()
    {
        Events.OnUpdateUI -= Check;
    }


    void Start()
    {
        if (Bridge.platform.language == "ru")
        {
            upgradeString = upgrade.ru;
            forLString = forL.ru;
            typeString = type.ru;
        }
        else
        {
            upgradeString = upgrade.en;
            forLString = forL.en;
            typeString = type.en;
        }


        Check();
    }


    void Check()
    {
        if (typeEnum == TypeEnum.click)
        {
            buttonText.text = upgradeString + " " + $"{data.clickCost + delta}/" + typeString + " " + forLString + " " + data.clickUpgrateCost;
            myButton.interactable = (data.clickUpgrateCost <= data.coins);
        }
        else
        {
            buttonText.text = upgradeString + " " + $"{data.autoClickCost + delta}/" + typeString + " " + forLString + " " + data.autoClickUpgrateCost;
            myButton.interactable = (data.autoClickUpgrateCost <= data.coins);
        }
    }

    public void Upgrate()
    {
        if (typeEnum == TypeEnum.click)
        {
            data.clickCost += delta;
            data.coins = data.coins - data.clickUpgrateCost;
            data.clickUpgrateCost = NewCost((float)data.clickUpgrateCost);
        }
        else
        {
            data.autoClickCost += delta;
            data.coins = data.coins - data.autoClickUpgrateCost;
            data.autoClickUpgrateCost = NewCost((float)data.autoClickUpgrateCost);
        }


        Events.OnUpdateUI?.Invoke();
    }

    int NewCost(float costTemp)
    {
        return (int)(upgrateMultiplier * costTemp);
    }
}

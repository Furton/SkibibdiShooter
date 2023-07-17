using UnityEngine;
using UnityEngine.UI;
using InstantGamesBridge;

public class StatsText : MonoBehaviour
{
    public Data data;
    public IntObject multiplierInt;
    public Language forClick, everySecond, multiplier;

    private string locForClick, locEverySecond, locMultiplier;
    private Text myText;

    void Awake()
    {
        myText = GetComponent<Text>();
    }

    void OnEnable()
    {
        Events.OnUpdateUI += Set;
    }

    void OnDisable()
    {
        Events.OnUpdateUI -= Set;
    }

    void Start()
    {
        if (Bridge.platform.language == "ru")
        {
            locForClick = forClick.ru;
            locEverySecond  = everySecond.ru;
            locMultiplier = multiplier.ru;
        }
        else
        {
            locForClick = forClick.en;
            locEverySecond = everySecond.en;
            locMultiplier = multiplier.en;
        }
        Set();
    }


    void Set()
    {
        myText.text = "+" + data.clickCost + " " + locForClick + "\r\n+" +
          + data.autoClickCost + " " + locEverySecond + "\r\n" +
         locMultiplier + " " + multiplierInt.myInt + ".";

    }

}

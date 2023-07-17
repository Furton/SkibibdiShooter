using UnityEngine;
using UnityEngine.UI;
using InstantGamesBridge;

public class CoinText : MonoBehaviour
{
    public Data data;
    public Language language;
    private Text myText;
    private string loc;

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
            loc = language.ru;
        }
        else
        {
            loc = language.en;
        }

        Set();
    }


    void Set()
    {
        myText.text = loc + " " + data.coins;
    }

}

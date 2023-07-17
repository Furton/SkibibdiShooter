using UnityEngine;
using UnityEngine.UI;
using InstantGamesBridge;

public class CharacterStats : MonoBehaviour
{
    public Language character, back;
    public Data data;
    public IntObject maxNumber, maxBackNumber;

    private Text characterText;
    private string characterString, backString;

    void Awake()
    {
        characterText = GetComponent<Text>();
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
            characterString = character.ru;
            backString = back.ru;
        }
        else
        {
            characterString = character.en;
            backString = back.en;
        }
        Set();
    }


    void Set()
    {
        characterText.text = characterString + " " + $"{data.skinNumber +1}" +"/" + $"{maxNumber.myInt}" +
            $"\n\r" + backString + " " + $"{data.backNumber + 1}" + "/" + $"{maxBackNumber.myInt}";
    }
}

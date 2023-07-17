using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CharacterButton : MonoBehaviour
{
    public enum TypeEnum {character, back};
    public TypeEnum typeEnum = TypeEnum.character;

    public Data data;
    public UnityEvent OnChange;
    public Text buttonText;

    private Button myButton;


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
        Check();
    }

    void Check()
    {
        if (typeEnum == TypeEnum.character)
        {
            buttonText.text = $"{data.skinCost}";
            myButton.interactable = (data.skinCost <= data.coins);
        }
        else
        {
            buttonText.text = $"{data.backCost}";
            myButton.interactable = (data.backCost <= data.coins);
        }
    }



    public void ChangeCharacter()
    {   

        if (typeEnum == TypeEnum.character)
        {
            data.coins = data.coins - data.skinCost;
            data.skinCost = (int)(CostMultiplier() * (float)data.skinCost);
        }
        else
        {
            data.coins = data.coins - data.backCost;
            data.backCost = (int)(CostMultiplier() * (float)data.backCost);
        }


        Events.OnUpdateUI?.Invoke();
        OnChange?.Invoke();
    }

    float CostMultiplier()
    {
        int numberTemp;
        if (typeEnum == TypeEnum.character)
        {
            numberTemp = data.skinNumber;
        }
        else
        {
            numberTemp = data.backNumber;
        }

        if (numberTemp < 4)
        {
            return 1.35f;
        }
        else
        {
            if (numberTemp >= 4 && data.skinNumber < 8)
            {
                return 1.78f;
            }
            else
            {
                    return 2.5f;
            }
        }
    }


}

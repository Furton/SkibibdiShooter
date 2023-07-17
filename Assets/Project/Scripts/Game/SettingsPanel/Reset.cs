using UnityEngine;

public class Reset : MonoBehaviour
{
    public IntObject multiplier;
    
    public void ResetButton()
    {
        multiplier.myInt = 1;
        SaveAndLoad.instance.Reset();
        Events.OnUpdateUI?.Invoke();
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Data", order = 1)]
public class Data : ScriptableObject
{
    public int skinNumber, backNumber;


    public int clickCost;
    public int clickUpgrateCost;

    public int autoClickCost;
    public int autoClickUpgrateCost;

    public int coins;
    public int skinCost, backCost;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsText : MonoBehaviour
{
    public GameObject numberTextPrefab;
    
    void OnEnable()
    {
        Events.OnAddCoins += Add;
    }

    void OnDisable()
    {
        Events.OnAddCoins -= Add;
    }



    void Add(int coins)
    {
        GameObject temp = Instantiate(numberTextPrefab, transform.position, Quaternion.identity);
        temp.transform.SetParent(transform);
        temp.GetComponent<Text>().text = $"+{coins}";
    }
}

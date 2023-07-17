using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Load : MonoBehaviour
{
    [SerializeField] private Data data;

    private void LoadLevel()
    {
        SceneManager.LoadScene(1);
    }

    void OnEnable()
    {
        Events.OnLoadComplete += LoadLevel;
    }

    void OnDisable()
    {
        Events.OnLoadComplete -= LoadLevel;
    }
    
    void Start()
    {
        SaveAndLoad.instance.Load();        
    }
}

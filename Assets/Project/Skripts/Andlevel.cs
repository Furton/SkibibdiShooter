using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Andlevel : MonoBehaviour
{
    public void Reload()
    {
        SaveAndLoad.Instance.Save();
        SceneManager.LoadScene("StartScene");
        SaveAndLoad.Instance.Save();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEfekt : MonoBehaviour
{
    public Color color;
    public Texture2D tex;
    private void OnGUI()
    {
        GUI.color = color;
        GUI.DrawTexture(new Rect(0f, 0f, Screen.width, Screen.height),tex);
    }
    public void Quit()
    {
        Application.Quit();
    }
}

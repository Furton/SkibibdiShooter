using UnityEngine;

public class OpenSettingsPanel : MonoBehaviour
{
    public GameObject settingsPanel;
    
    public void Open()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using InstantGamesBridge;

public class Interface : MonoBehaviour
{
    public ShowInter se;
    public UnityEvent gameer, menue, gamover, skill, andLVL, nullBK;
    public static Interface rid { get; set; }
    void Awake()
    {
        if (rid == null)
        {
            rid = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void OnDestroy()
    {
        rid = null;
    }
    void Start()
    {
        Menu();
    }
    public void NullBK()
    {
        Muwer.rid.muve = Vector2.zero;
        Muwer.rid.rut = Vector2.zero;
        nullBK.Invoke();
        Time.timeScale = 0;
        Lock(false);
    }
    public void Menu()
    {
        Muwer.rid.muve = Vector2.zero;
        Muwer.rid.rut = Vector2.zero;
        menue.Invoke();
        Time.timeScale = 0;
        Lock(false);
    }
    public void AndLVL()
    {
        Muwer.rid.muve = Vector2.zero;
        Muwer.rid.rut = Vector2.zero;
        andLVL.Invoke();
        Time.timeScale = 0;
        Lock(false);
    }
    public void Skill()
    {
        Muwer.rid.muve = Vector2.zero;
        Muwer.rid.rut = Vector2.zero;
        skill.Invoke();
        Time.timeScale = 0;
        Lock(false);
    }

    public void Game()
    {
        gameer.Invoke();
        Time.timeScale = 1;
        Lock(true);

    }
    public void GameOver()
    {
        gamover.Invoke();
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            se.Showreklame();
        }
        Lock(false);

    }

    void Lock(bool stateTemp)
    {
        if(stateTemp && (Bridge.device.type == InstantGamesBridge.Modules.Device.DeviceType.Desktop))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }


}

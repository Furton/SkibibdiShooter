using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInterfase : MonoBehaviour
{
    public Data data;
    public Image hPbar;
    public Text bullets, record, tempRecord;
    private float mHalse;

    void Update()
    {
        hPbar.fillAmount = Gun.rid.helse / 10;
        bullets.text = "" + data.bulets;
        tempRecord.text = "" + (data.tempRecord-1);
        record.text = "" + (data.record - 1);
    }
}

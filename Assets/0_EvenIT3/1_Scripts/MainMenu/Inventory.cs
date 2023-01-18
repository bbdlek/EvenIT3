using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject ClockView, MilkView, MaskView;

    public void ClickBack()
    {
        ClockView.SetActive(false);
        MilkView.SetActive(false);
        MaskView.SetActive(false);
    }

    public void ClickClock()
    {
        ClockView.SetActive(true);
    }

    public void ClickMilk()
    {
        MilkView.SetActive(true);
    }

    public void ClickMask()
    {
        MaskView.SetActive(true);
    }
}

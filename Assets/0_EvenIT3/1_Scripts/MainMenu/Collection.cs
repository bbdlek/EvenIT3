using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour
{

    public GameObject ExView, OneView, TwoView, ThreeView, Three2View, FourView, FiveView, SixView;
    public Image ExBtn, OneBtn, TwoBtn, ThreeBtn, Three2Btn, FourBtn, FiveBtn, SixBtn;
    public Text CountTxt;
    int count = 0;


    // ¹öÇÁ
    public void ClickEx()
    {
        ExView.SetActive(true);
        OneView.SetActive(false);
        TwoView.SetActive(false);
        ThreeView.SetActive(false);
        Three2View.SetActive(false);
        FourView.SetActive(false);
        FiveView.SetActive(false);
        SixView.SetActive(false);
    }

    // 1Ã©ÅÍ
    public void ClickOne()
    {
        ExView.SetActive(false);
        OneView.SetActive(true);
        TwoView.SetActive(false);
        ThreeView.SetActive(false);
        Three2View.SetActive(false);
        FourView.SetActive(false);
        FiveView.SetActive(false);
        SixView.SetActive(false);
    }

    // 2Ã©ÅÍ
    public void ClickTwo()
    {
        ExView.SetActive(false);
        OneView.SetActive(false);
        TwoView.SetActive(true);
        ThreeView.SetActive(false);
        Three2View.SetActive(false);
        FourView.SetActive(false);
        FiveView.SetActive(false);
        SixView.SetActive(false);
    }

    // 3Ã©ÅÍ
    public void ClickThree()
    {
        ExView.SetActive(false);
        OneView.SetActive(false);
        TwoView.SetActive(false);
        ThreeView.SetActive(true);
        Three2View.SetActive(false);
        FourView.SetActive(false);
        FiveView.SetActive(false);
        SixView.SetActive(false);
    }

    public void ClickNextPageBtn()
    {
        ExView.SetActive(false);
        OneView.SetActive(false);
        TwoView.SetActive(false);
        ThreeView.SetActive(false);
        Three2View.SetActive(true);
        FourView.SetActive(false);
        FiveView.SetActive(false);
        SixView.SetActive(false);
    }

    // 4Ã©ÅÍ
    public void ClickFour()
    {
        ExView.SetActive(false);
        OneView.SetActive(false);
        TwoView.SetActive(false);
        ThreeView.SetActive(false);
        Three2View.SetActive(false);
        FourView.SetActive(true);
        FiveView.SetActive(false);
        SixView.SetActive(false);
    }

    // 5Ã©ÅÍ
    public void ClickFive()
    {
        ExView.SetActive(false);
        OneView.SetActive(false);
        TwoView.SetActive(false);
        ThreeView.SetActive(false);
        Three2View.SetActive(false);
        FourView.SetActive(false);
        FiveView.SetActive(true);
        SixView.SetActive(false);
    }

    // 6Ã©ÅÍ
    public void ClickSix()
    {
        ExView.SetActive(false);
        OneView.SetActive(false);
        TwoView.SetActive(false);
        ThreeView.SetActive(false);
        Three2View.SetActive(false);
        FourView.SetActive(false);
        FiveView.SetActive(false);
        SixView.SetActive(true);
    }

    public void Count()
    {
        CountTxt.text = "(" + count + "/20)";
        if (count > 0)
        {
            //GetComponent<Image>().material = ;
        }
    }
}

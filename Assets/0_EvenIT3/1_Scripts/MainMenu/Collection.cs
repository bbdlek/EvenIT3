
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collection : MonoBehaviour
{

    public GameObject ExView, OneView, TwoView, ThreeView, Three2View, FourView, FiveView, SixView;
    public Image ExBtn, OneBtn, TwoBtn, ThreeBtn, Three2Btn, FourBtn, FiveBtn, SixBtn;
    public Text CountTxt;


    // πˆ«¡
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

    // 1√©≈Õ
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

    // 2√©≈Õ
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

    // 3√©≈Õ
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

    // 4√©≈Õ
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

    // 5√©≈Õ
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

    // 6√©≈Õ
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
}

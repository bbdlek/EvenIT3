using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial41 : MonoBehaviour
{
    public GameObject T4View1, T4View2, T4View3;
    public Image T4Btn1, T4Btn2, T4Btn3;

    public void T4Click1()
    {
        T4View1.SetActive(false);
        T4View2.SetActive(true);
    }

    public void T4Click2()
    {
        T4View2.SetActive(false);
        T4View3.SetActive(true);
    }

    public void T4Click3()
    {
        T4View3.SetActive(false);

    }
}

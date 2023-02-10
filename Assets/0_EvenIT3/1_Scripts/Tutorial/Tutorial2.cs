using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial2 : MonoBehaviour
{
    public GameObject T2View1, T2View2, T2View3, T2View4, T2View5, T2View6, T2View7, T2View8, T2View9, T2View10, T2View11, T2View12, T2View13, T2View14, T2View15, T2View16, T2View17;
    public Image T2Btn1, T2Btn2, T2Btn3, T2Btn4, T2Btn5, T2Btn6, T2Btn7, T2Btn8, T2Btn9, T2Btn10, T2Btn11, T2Btn12, T2Btn13, T2Btn14, T2Btn15, T2Btn16, T2Btn17;

    public void T2Click1()
    {
        T2View1.SetActive(false);
        T2View2.SetActive(true);
    }

    public void T2Click2()
    {
        T2View2.SetActive(false);
        T2View3.SetActive(true);
    }

    public void T2Click3()
    {
        T2View3.SetActive(false);
        T2View4.SetActive(true);
    }

    public void T2Click4()
    {
        T2View4.SetActive(false);
        T2View5.SetActive(true);
        gameObject.SetActive(false);
    }

    public void T2Click5()
    {
        T2View5.SetActive(false);
        T2View6.SetActive(true);
    }

    public void T2Click6()
    {
        T2View6.SetActive(false);
        T2View7.SetActive(true);
    }

    public void T2Click7()
    {
        T2View7.SetActive(false);
        T2View8.SetActive(true);
    }

    public void T2Click8()
    {
        T2View8.SetActive(false);
        T2View9.SetActive(true);
    }

    public void T2Click9()
    {
        T2View9.SetActive(false);
        T2View10.SetActive(true);
    }

    public void T2Click10()
    {
        T2View10.SetActive(false);
        T2View11.SetActive(true);
    }

    public void T2Click11()
    {
        T2View11.SetActive(false);
        T2View12.SetActive(true);
    }

    public void T2Click12()
    {
        T2View12.SetActive(false);
        T2View13.SetActive(true);
    }

    public void T2Click13()
    {
        T2View13.SetActive(false);
        T2View14.SetActive(true);
    }

    public void T2Click14()
    {
        T2View14.SetActive(false);
        T2View15.SetActive(true);
    }

    public void T2Click15()
    {
        T2View15.SetActive(false);
        T2View16.SetActive(true);
    }

    public void T2Click16()
    {
        T2View16.SetActive(false);
        T2View17.SetActive(true);
    }

    public void T2Click17()
    {
        UserManager.Instance.userData.tutorial2 = true;
        FBManagerScript.Instance.UpdateCurrentUser();
        T2View17.SetActive(false);

    }
}

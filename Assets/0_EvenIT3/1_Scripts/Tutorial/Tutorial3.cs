using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial3 : MonoBehaviour
{


    public GameObject T3View1, T3View2, T3View3, T3View4, T3View5, T3View6, T3View7, T3View8, T3View9, T3View10, T3View11, T3View12, T3View13, T3View14, T3View15, T3View16, T3View17, T3View18, T3View19, T3View20;
    public Image T3Btn1, T3Btn2, T3Btn3, T3Btn4, T3Btn5, T3Btn6, T3Btn7, T3Btn8, T3Btn9, T3Btn10, T3Btn11, T3Btn12, T3Btn13, T3Btn14, T3Btn15, T3Btn16, BT3tn17, T3Btn18, T3Btn19, T3Btn20;

    public void T3Click1()
    {
        T3View1.SetActive(false);
        T3View2.SetActive(true);
    }

    public void T3Click2()
    {
        T3View2.SetActive(false);
        T3View3.SetActive(true);
    }

    public void T3Click3()
    {
        T3View3.SetActive(false);
        T3View4.SetActive(true);
    }

    public void T3Click4()
    {
        T3View4.SetActive(false);
        T3View5.SetActive(true);
    }

    public void T3Click5()
    {
        T3View5.SetActive(false);
        T3View6.SetActive(true);
    }

    public void T3Click6()
    {
        T3View6.SetActive(false);
        T3View7.SetActive(true);
    }

    public void T3Click7()
    {
        T3View7.SetActive(false);
        T3View8.SetActive(true);
    }

    public void T3Click8()
    {
        T3View8.SetActive(false);
        T3View9.SetActive(true);
    }

    public void T3Click9()
    {
        T3View9.SetActive(false);
        T3View10.SetActive(true);
    }

    public void T3Click10()
    {
        T3View10.SetActive(false);
        T3View11.SetActive(true);
    }

    public void T3Click11()
    {
        T3View11.SetActive(false);
        T3View12.SetActive(true);
    }

    public void T3Click12()
    {
        T3View12.SetActive(false);
        T3View13.SetActive(true);
    }

    public void T3Click13()
    {
        T3View13.SetActive(false);
        T3View14.SetActive(true);
    }

    public void T3Click14()
    {
        T3View14.SetActive(false);
        T3View15.SetActive(true);
    }

    public void T3Click15()
    {
        T3View15.SetActive(false);
        T3View16.SetActive(true);
    }

    public void T3Click16()
    {
        T3View16.SetActive(false);
        T3View17.SetActive(true);
    }

    public void T3Click17()
    {
        T3View17.SetActive(false);
        T3View18.SetActive(true);
    }

    public void T3Click18()
    {
        T3View18.SetActive(false);
        T3View19.SetActive(true);
    }

    public void T3Click19()
    {
        T3View19.SetActive(false);
        T3View20.SetActive(true);
    }

    public void T3Click20()
    {
        T3View20.SetActive(false);
        gameObject.SetActive(false);
        GameManager.Instance.gameState = GameManager.GameState.InGame;
        Time.timeScale = 1;
    }

}

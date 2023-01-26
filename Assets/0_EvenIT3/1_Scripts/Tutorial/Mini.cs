using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mini : MonoBehaviour
{
    public GameObject MiniView1, MiniView2, MiniView3, MiniView4, MiniView5;
    public Image MiniBtn1, MiniBtn2, MiniBtn3, MiniBtn4, MiniBtn5;

    public void MiniClick1()
    {
        MiniView1.SetActive(false);
        MiniView2.SetActive(true);
    }

    public void MiniClick2()
    {
        MiniView2.SetActive(false);
        MiniView3.SetActive(true);
    }

    public void MiniClick3()
    {
        MiniView3.SetActive(false);
        MiniView4.SetActive(true);
    }

    public void MiniClick4()
    {
        MiniView4.SetActive(false);
        MiniView5.SetActive(true);
    }

    public void MiniClick5()
    {
        MiniView5.SetActive(false);
        gameObject.SetActive(false);
    }
}

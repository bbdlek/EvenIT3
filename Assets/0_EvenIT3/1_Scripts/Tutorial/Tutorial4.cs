using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial4 : MonoBehaviour
{
    public GameObject T4View4, T4View5, T4View6, T4View7, T4View8, T4View9, T4View10, T4View11, T4View12, T4View13, T4View14, T4View15, T4View16, T4View17, T4View18;
    public Image T4Btn4, T4Btn5, T4Btn6, T4Btn7, T4Btn8, vBtn9, vBtn10, T4Btn11, T4Btn12, T4Btn13, T4Btn14, T4Btn15, T4Btn16, T4Btn17, T4Btn18;

    public GameObject Collection;

    public void T4Click4()
    {
        T4View4.SetActive(false);
        T4View5.SetActive(true);
        FindObjectOfType<MainMenuSceneUIManager>().OnClickCollectionMoveBtn();
        FindObjectOfType<MainMenuSceneUIManager>().OnClickChapter1Btn();
    }

    public void T4Click5()
    {
        T4View5.SetActive(false);
        T4View6.SetActive(true);
    }

    public void T4Click6()
    {
        T4View6.SetActive(false);
        T4View7.SetActive(true);
    }

    public void T4Click7()
    {
        T4View7.SetActive(false);
        T4View8.SetActive(true);
    }

    public void T4Click8()
    {
        T4View8.SetActive(false);
        T4View9.SetActive(true);
    }

    public void T4Click9()
    {
        T4View9.SetActive(false);
        T4View10.SetActive(true);
    }

    public void T4Click10()
    {
        T4View10.SetActive(false);
        T4View11.SetActive(true);
        FindObjectOfType<MainMenuSceneUIManager>().OnClickBuffBtn();
    }

    public void T4Click11()
    {
        T4View11.SetActive(false);
        T4View12.SetActive(true);
    }

    public void T4Click12()
    {
        T4View12.SetActive(false);
        T4View13.SetActive(true);
    }

    public void T4Click13()
    {
        T4View13.SetActive(false);
        T4View14.SetActive(true);
    }

    public void T4Click14()
    {
        T4View14.SetActive(false);
        T4View15.SetActive(true);
    }

    public void T4Click15()
    {
        T4View15.SetActive(false);
        T4View16.SetActive(true);
    }

    public void T4Click16()
    {
        T4View16.SetActive(false);
        gameObject.SetActive(false);
        UserManager.Instance.userData.tutorial4 = true;
        UserManager.Instance.userData.snackList[0] += 10;
        Mathf.Clamp(UserManager.Instance.userData.snackList[0], 0, 20);
        FBManagerScript.Instance.UpdateCurrentUser();
        FindObjectOfType<MainMenuSceneUIManager>().SetCollectionNum();
        FindObjectOfType<MainMenuSceneUIManager>().InitCollection();
        FindObjectOfType<MainMenuSceneUIManager>().InitProfileCollection();
    }

    public void T4Click17()
    {
        T4View17.SetActive(false);
        T4View18.SetActive(true);
    }

    public void T4Click18()
    {
        T4View18.SetActive(false);
        gameObject.SetActive(false);
        UserManager.Instance.userData.snackList[0] += 10;
        Mathf.Clamp(UserManager.Instance.userData.snackList[0], 0, 20);
        FBManagerScript.Instance.UpdateCurrentUser();
        FindObjectOfType<MainMenuSceneUIManager>().SetCollectionNum();
        FindObjectOfType<MainMenuSceneUIManager>().InitCollection();
        FindObjectOfType<MainMenuSceneUIManager>().InitProfileCollection();
    }
}

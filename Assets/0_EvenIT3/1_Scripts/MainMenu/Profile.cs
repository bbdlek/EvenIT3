using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
    public Image profile, edge;

    public void Start()
    {
        edge.transform.SetSiblingIndex(-1);
    }

    // 프로필 누르면 호출
    public void ClickProfileEdit()
    {
        gameObject.SetActive(true);
    }

    // 바깥 누르면 호출
    public void ClickBack()
    {
        gameObject.SetActive(false);
    }

    public void ClickProfile()
    {
        profile.transform.SetSiblingIndex(1);
        edge.transform.SetSiblingIndex(-1);
    }

    public void ClickEdge()
    {
        profile.transform.SetSiblingIndex(-1);
        edge.transform.SetSiblingIndex(1);
    }
}

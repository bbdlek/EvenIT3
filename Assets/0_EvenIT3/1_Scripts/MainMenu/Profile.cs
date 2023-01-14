using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile : MonoBehaviour
{
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
}

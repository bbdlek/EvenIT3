using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Profile : MonoBehaviour
{
    // ������ ������ ȣ��
    public void ClickProfileEdit()
    {
        gameObject.SetActive(true);
    }

    // �ٱ� ������ ȣ��
    public void ClickBack()
    {
        gameObject.SetActive(false);
    }
}

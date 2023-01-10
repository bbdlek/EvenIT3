using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject Gachaview, Itemview, PackageView, PaidView;
    public Image GachaBtn, ItemBtn, PackageBtn, PaidBtn;
    public Color red, yellow;
    public bool isGacha, isItem, isPackage, isPaid;

    // ���� ��ư�� ������ ȣ��
    public void ClickShop()
    {
        gameObject.SetActive(true);
    }

    // ���ư��� ��ư�� ������ ȣ��
    public void ClickBack()
    {
        gameObject.SetActive(false);
    }

    // ��í
    public void ClickGacha()
    {
        Gachaview.SetActive(true);
        Itemview.SetActive(false);
        PackageView.SetActive(false);
        PaidView.SetActive(false);

        isGacha = true;
        isItem = false;
        isPackage = false;
        isPaid = false;

        GachaBtn.color = red;
        ItemBtn.color = yellow;
        PackageBtn.color = yellow;
        PaidBtn.color = yellow;
    }

    // ������
    public void ClickItem()
    {
        Gachaview.SetActive(false);
        Itemview.SetActive(true);
        PackageView.SetActive(false);
        PaidView.SetActive(false);

        isGacha = false;
        isItem = true;
        isPackage = false;
        isPaid = false;

        GachaBtn.color = yellow;
        ItemBtn.color = red;
        PackageBtn.color = yellow;
        PaidBtn.color = yellow;
    }

    // ��Ű��
    public void ClickPackage()
    {
        Gachaview.SetActive(false);
        Itemview.SetActive(false);
        PackageView.SetActive(true);
        PaidView.SetActive(false);

        isGacha = false;
        isItem = false;
        isPackage = true;
        isPaid = false;

        GachaBtn.color = yellow;
        ItemBtn.color = yellow;
        PackageBtn.color = red;
        PaidBtn.color = yellow;
    }

    // ������ȭ
    public void ClickPaid()
    {
        Gachaview.SetActive(false);
        Itemview.SetActive(false);
        PackageView.SetActive(false);
        PaidView.SetActive(true);

        isGacha = false;
        isItem = false;
        isPackage = false;
        isPaid = true;

        GachaBtn.color = yellow;
        ItemBtn.color = yellow;
        PackageBtn.color = yellow;
        PaidBtn.color = red;
    }
}

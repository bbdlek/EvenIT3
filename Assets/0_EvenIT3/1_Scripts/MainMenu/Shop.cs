using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject GachaView, ItemView, PackageView, PaidView, BuyCheckView;
    public Image GachaBtn, ItemBtn, PackageBtn, PaidBtn;
    public Color red, yellow;

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
        GachaView.SetActive(true);
        ItemView.SetActive(false);
        PackageView.SetActive(false);
        PaidView.SetActive(false);

        GachaBtn.color = red;
        ItemBtn.color = yellow;
        PackageBtn.color = yellow;
        PaidBtn.color = yellow;
    }

    // ������
    public void ClickItem()
    {
        GachaView.SetActive(false);
        ItemView.SetActive(true);
        PackageView.SetActive(false);
        PaidView.SetActive(false);

        GachaBtn.color = yellow;
        ItemBtn.color = red;
        PackageBtn.color = yellow;
        PaidBtn.color = yellow;
    }

    // ��Ű��
    public void ClickPackage()
    {
        GachaView.SetActive(false);
        ItemView.SetActive(false);
        PackageView.SetActive(true);
        PaidView.SetActive(false);

        GachaBtn.color = yellow;
        ItemBtn.color = yellow;
        PackageBtn.color = red;
        PaidBtn.color = yellow;
    }

    // ������ȭ
    public void ClickPaid()
    {
        GachaView.SetActive(false);
        ItemView.SetActive(false);
        PackageView.SetActive(false);
        PaidView.SetActive(true);

        GachaBtn.color = yellow;
        ItemBtn.color = yellow;
        PackageBtn.color = yellow;
        PaidBtn.color = red;
    }

    public void ClickBuy()
    {
        BuyCheckView.SetActive(true);
    }

    public void ClickBuyYes()
    {
        BuyCheckView.SetActive(false);
    }

    public void ClickBuyNo()
    {
        BuyCheckView.SetActive(false);
    }
}

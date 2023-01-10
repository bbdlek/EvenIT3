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

    // 매점 버튼을 누르면 호출
    public void ClickShop()
    {
        gameObject.SetActive(true);
    }

    // 돌아가기 버튼을 누르면 호출
    public void ClickBack()
    {
        gameObject.SetActive(false);
    }

    // 가챠
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

    // 아이템
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

    // 패키지
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

    // 유료재화
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

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GachaManager : MonoBehaviour
{
    enum GachaType
    {
        epic,
        normal
    };

    [SerializeField] private GachaType gachaType;

    [SerializeField] private GameObject normalGacha;
    [SerializeField] private GameObject epicGacha;
    [SerializeField] private GameObject rewardPopup;

    public void DoNormalGachaOnce()
    {
        for (int c = 0; c < rewardList.transform.childCount; c++)
        {
            Destroy(rewardList.transform.GetChild(c).gameObject);
        }
        gachaRewardCounts = new int[45];
        DoNormalGacha();
        normalGacha.SetActive(true);
    }
    
    public void DoNormalGachaFifth()
    {
        for (int c = 0; c < rewardList.transform.childCount; c++)
        {
            Destroy(rewardList.transform.GetChild(c).gameObject);
        }
        gachaRewardCounts = new int[45];
        for(int i = 0; i < 5; i++) 
        {
            DoNormalGacha();
        }
        normalGacha.SetActive(true);
    }

    public void DoEpicGachaOnce()
    {
        for (int c = 0; c < rewardList.transform.childCount; c++)
        {
            Destroy(rewardList.transform.GetChild(c).gameObject);
        }
        gachaRewardCounts = new int[45];
        DoEpicGacha();
        epicGacha.SetActive(true);
    }

    public void DoEpicGachaFifth()
    {
        for (int c = 0; c < rewardList.transform.childCount; c++)
        {
            Destroy(rewardList.transform.GetChild(c).gameObject);
        }
        gachaRewardCounts = new int[45];
        for (int i = 0; i < 5; i++)
        {
            DoEpicGacha();
        }
        epicGacha.SetActive(true);
    }
    
    public void DoNormalGacha()
    {
        int random = Random.Range(0, 10000);
        if (random < 1332)
        {
            gachaRewardCounts[0] += 3;
            UserManager.Instance.userData.clockItem += 3;
        }
        else if (random < 2664)
        {
            gachaRewardCounts[1] += 4;
            UserManager.Instance.userData.maskItem += 4;
        }
        else if (random < 3996)
        {
            gachaRewardCounts[2] += 4;
            UserManager.Instance.userData.milkItem += 4;
        }
        else if (random < 4746)
        {
            //bread
            int rand = Random.Range(0, 10);
            UserManager.Instance.userData.snackList[rand] += 1;
            gachaRewardCounts[3 + rand] += 1;
        }
        else if (random < 5496)
        {
            //Candy
            int rand = Random.Range(11, 20);
            UserManager.Instance.userData.snackList[rand] += 1;
            gachaRewardCounts[3 + rand] += 1;
        }
        else if (random < 6246)
        {
            //Snack
            int rand = Random.Range(21, 30);
            UserManager.Instance.userData.snackList[rand] += 1;
            gachaRewardCounts[3 + rand] += 1;
        }
        else if (random < 6996)
        {
            //Cookie
            int rand = Random.Range(31, 40);
            UserManager.Instance.userData.snackList[rand] += 1;
            gachaRewardCounts[3 + rand] += 1;
        }
        else if (random < 8246)
        {
            gachaRewardCounts[43] += 1500;
            UserManager.Instance.userData.Commodities.Silver += 2500;
        }
        else if (random < 8996)
        {
            gachaRewardCounts[43] += 2500;
            UserManager.Instance.userData.Commodities.Silver += 3500;
        }
        else if (random < 9496)
        {
            gachaRewardCounts[43] += 3000;
            UserManager.Instance.userData.Commodities.Silver += 4500;
        }
        else if (random < 9746)
        {
            gachaRewardCounts[44] += 10;
            UserManager.Instance.userData.Commodities.Gold += 10;
        }
        else if (random < 9896)
        {
            gachaRewardCounts[44] += 15;
            UserManager.Instance.userData.Commodities.Gold += 15;
        }
        else
        {
            gachaRewardCounts[44] += 20;
            UserManager.Instance.userData.Commodities.Gold += 20;
        }
    }
    
    public void DoEpicGacha()
    {
        int random = Random.Range(0, 10000);
        if (random < 833)
        {
            gachaRewardCounts[0] += 5;
            UserManager.Instance.userData.clockItem += 5;
        }
        else if (random < 1666)
        {
            gachaRewardCounts[1] += 5;
            UserManager.Instance.userData.maskItem += 5;
        }
        else if (random < 2499)
        {
            gachaRewardCounts[2] += 5;
            UserManager.Instance.userData.milkItem += 5;
        }
        else if (random < 3499)
        {
            //bread
            int rand = Random.Range(0, 10);
            UserManager.Instance.userData.snackList[rand] += 3;
            gachaRewardCounts[3 + rand] += 3;
        }
        else if (random < 4499)
        {
            //Candy
            int rand = Random.Range(11, 20);
            UserManager.Instance.userData.snackList[rand] += 3;
            gachaRewardCounts[3 + rand] += 3;
        }
        else if (random < 5499)
        {
            //Snack
            int rand = Random.Range(21, 30);
            UserManager.Instance.userData.snackList[rand] += 3;
            gachaRewardCounts[3 + rand] += 3;
        }
        else if (random < 6499)
        {
            //Cookie
            int rand = Random.Range(31, 40);
            UserManager.Instance.userData.snackList[rand] += 3;
            gachaRewardCounts[3 + rand] += 3;
        }
        else if (random < 7999)
        {
            gachaRewardCounts[43] += 1500;
            UserManager.Instance.userData.Commodities.Silver += 1500;
        }
        else if (random < 8899)
        {
            gachaRewardCounts[43] += 2500;
            UserManager.Instance.userData.Commodities.Silver += 2500;
        }
        else if (random < 9499)
        {
            gachaRewardCounts[43] += 3000;
            UserManager.Instance.userData.Commodities.Silver += 3000;
        }
        else if (random < 9749)
        {
            gachaRewardCounts[44] += 15;
            UserManager.Instance.userData.Commodities.Gold += 15;
        }
        else if (random < 9899)
        {
            gachaRewardCounts[44] += 20;
            UserManager.Instance.userData.Commodities.Gold += 20;
        }
        else
        {
            gachaRewardCounts[44] += 25;
            UserManager.Instance.userData.Commodities.Gold += 25;
        }
    }

    [SerializeField] private Sprite[] gachaRewardImages = new Sprite[45];
    [SerializeField] private int[] gachaRewardCounts = new int[45];

    [SerializeField] private GameObject rewardList;
    [SerializeField] private GameObject rewardRoster;
    

    public void NormalGachaAnimation()
    {
        FBManagerScript.Instance.UpdateCurrentUser();
        for (int i = 0; i < gachaRewardCounts.Length; i++)
        {
            if (gachaRewardCounts[i] != 0)
            {
                GameObject tempRoster = Instantiate(rewardRoster, rewardList.transform);
                if(i < 3 || i > 42)
                {
                    tempRoster.GetComponent<Image>().sprite = gachaRewardImages[i];
                }
                else
                {
                    tempRoster.GetComponent<Image>().sprite =
                        Resources.Load<Sprite>("Snacks/" + DBManagerScript.Instance.snackDB[i - 3].name);
                }

                tempRoster.GetComponentInChildren<TMP_Text>().text = "X " + gachaRewardCounts[i];
            }
        }
        rewardPopup.SetActive(true);
        normalGacha.SetActive(false);
    }
    
    public void EpicGachaAnimation()
    {
        FBManagerScript.Instance.UpdateCurrentUser();
        for (int i = 0; i < gachaRewardCounts.Length; i++)
        {
            if (gachaRewardCounts[i] != 0)
            {
                GameObject tempRoster = Instantiate(rewardRoster, rewardList.transform);
                if(i < 3 || i > 42)
                {
                    tempRoster.GetComponent<Image>().sprite = gachaRewardImages[i];
                }
                else
                {
                    tempRoster.GetComponent<Image>().sprite =
                        Resources.Load<Sprite>("Snacks/" + DBManagerScript.Instance.snackDB[i - 3].name);
                }
                
                tempRoster.GetComponentInChildren<TMP_Text>().text = "X " + gachaRewardCounts[i];
            }
        }
        rewardPopup.SetActive(true);
        epicGacha.SetActive(false);
    }
}

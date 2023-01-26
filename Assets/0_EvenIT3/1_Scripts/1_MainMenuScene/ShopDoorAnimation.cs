using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDoorAnimation : MonoBehaviour
{
    public void GoToShop()
    {
        FindObjectOfType<MainMenuSceneUIManager>().ChangeUI(MainMenuSceneUIManager.MainMenuScenePanels.ShopPanel);
    }
}

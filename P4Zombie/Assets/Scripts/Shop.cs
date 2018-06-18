using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<WeaponBase> shopWeaponHolder;
    public GameObject manager;

    void Start()
    {
        manager = GameObject.FindWithTag("Manager");
    }

    void Update()
    {
        ExitShop();
    }

    public void ShopIndex()
    {
        
    }
    /*
     * button 1 == index 1
     */
    public void ExitShop()
    {
        if(manager.GetComponent<UI>().shopPanel == true && Input.GetButtonDown("Interact") == true)
        {
            Debug.Log("CloseShop");
            
            manager.GetComponent<UI>().CloseShopText.SetActive(false);
            manager.GetComponent<UI>().openShopText.SetActive(false);

            manager.GetComponent<UI>().openShopPanel.SetActive(false);
            manager.GetComponent<UI>().shopPanel.SetActive(false);

            manager.GetComponentInChildren<UI>().enabled = true;
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().shopOpenBool = false;

            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<WeaponBase> shopWeaponHolder;

    void Start()
    {
        
    }

    void Update()
    {
        CheckCurrency();
        ExitShop();
    }

    public void CheckCurrency()
    {
        foreach (WeaponBase weapon in shopWeaponHolder)
        {
            if(weapon.ownValue <= GameObject.FindWithTag("Player").GetComponent<PlayerController>().money)
            {
                Debug.Log("Buyeble");
                
            }
            if (shopWeaponHolder[1].ownValue <= GameObject.FindWithTag("Player").GetComponent<PlayerController>().money)
            {
                
            }
        }
    }

    public void ExitShop()
    {
        if(GameObject.FindWithTag("Manager").GetComponent<UI>().openShopPanel && Input.GetButtonDown("Interact") == true)
        {
            Debug.Log("CloseShop");

            GameObject.FindWithTag("Manager").GetComponent<UI>().openShopPanel.SetActive(false);
            GameObject.FindWithTag("Manager").GetComponent<UI>().shopPanel.SetActive(false);
            GameObject.FindWithTag("Manager").GetComponent<UI>().CloseShopText.SetActive(false);
            GameObject.FindWithTag("Manager").GetComponent<UI>().openShopText.SetActive(false);

            GameObject.FindWithTag("Plyer").GetComponentInChildren<UI>().enabled = true;

            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

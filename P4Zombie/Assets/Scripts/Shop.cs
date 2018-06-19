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
        
    }
    
    public void ExitShop()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().shopOpenBool = false;

        manager.GetComponent<UI>().CloseShopText.SetActive(false);
        manager.GetComponent<UI>().shopPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;

        Debug.Log("Shop is closed");
    }
}

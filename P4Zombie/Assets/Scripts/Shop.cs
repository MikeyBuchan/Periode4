using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public List<WeaponBase> shopWeaponHolder;
    GameObject manager;

    void Start()
    {
        manager = GameObject.FindWithTag("Manager");
    }

    void Update()
    {
        
    }
    
    public void ExitShop()
    {
        if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().shopOpenBool == false)
        {
            GameObject.FindWithTag("Player").GetComponentInChildren<LookAround>().enabled = true;
            GameObject.FindWithTag("Player").GetComponent<PlayerController>().moveSpeed = moveSpeedBaseValue;

            manager.GetComponent<UI>().CloseShopText.SetActive(false);
            manager.GetComponent<UI>().shopPanel.SetActive(false);

            Cursor.lockState = CursorLockMode.Locked;

            Debug.Log("Shop is closed");
        }
    }
}

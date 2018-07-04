using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContact : MonoBehaviour
{
    [Header("OpenShop")]
    public int hitShopRange;
    public RaycastHit hitShop;
    public bool shopOpenBool = false;
    public Sprite WireHolder;
    GameObject manager;

    void Start()
    {
        manager = GameObject.FindWithTag("Manager");
        WireHolder = GameObject.FindWithTag("WireTag").GetComponent<Image>().sprite;
    }

    void Update()
    {
        OpenShop();
        GeneratorSwitch();
        VictorySwitch();
        PickUpAccu();
        LookAtBarricade();
    }

    public void OpenShop()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitShop, hitShopRange) && hitShop.transform.tag == ("Shop"))
        {
            if (shopOpenBool == false)
            {
                manager.GetComponent<UI>().openShopPanel.SetActive(true);
            }

            if (hitShop.transform.tag == ("Shop") && Input.GetButtonDown("Interact"))
            {
                Debug.Log("shop is opend");
                manager.GetComponent<UI>().openShopPanel.SetActive(false);
                manager.GetComponent<UI>().shopPanel.SetActive(true);
                manager.GetComponent<UI>().closeShopPanel.SetActive(true);

                gameObject.GetComponentInChildren<LookAround>().enabled = false;
                gameObject.GetComponent<PlayerController>().moveSpeed = 0;
                Cursor.lockState = CursorLockMode.None;

                shopOpenBool = true;
                Debug.Log(shopOpenBool);
                if (Input.GetButton("Back") == true)
                {
                    GameObject.FindWithTag("Shop").GetComponent<Shop>().ExitShop();
                }
            }

        }
        else
        {
            manager.GetComponent<UI>().openShopPanel.SetActive(false);
            manager.GetComponent<UI>().shopPanel.SetActive(false);

            shopOpenBool = false;
        }
        Debug.DrawRay(transform.position, transform.forward * hitShopRange, Color.cyan);
    }

    public void GeneratorSwitch()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitShop, hitShopRange) && hitShop.transform.tag == ("Generator"))
        {
            if (WireHolder != null)
            {
                Debug.Log("Got Wire");
                manager.GetComponent<UI>().generatorGotWirePanel.SetActive(true);
                if (manager.GetComponent<UI>().generatorGotWirePanel == true && Input.GetButton("Interact") == true)
                {
                    GameObject.FindWithTag("WireTag").GetComponent<Image>().sprite = null;
                    WireHolder = null;
                    GameObject.FindWithTag("Generator").GetComponent<Generator>().OpenNewArea();
                    manager.GetComponent<UI>().generatorGotWirePanel.SetActive(false);
                }
            }
            else
            {
                Debug.Log("Need Wire");
                manager.GetComponent<UI>().generatorNeedWirePanel.SetActive(true);
            }
        }
        else
        {
            manager.GetComponent<UI>().generatorGotWirePanel.SetActive(false);
            manager.GetComponent<UI>().generatorNeedWirePanel.SetActive(false);
        }
    }

    public void PickUpAccu()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitShop, hitShopRange) && hitShop.transform.tag == ("EscapeAccu"))
        {
            if (WireHolder == null)
            {
                manager.GetComponent<UI>().accuPanel.SetActive(true);
                if (manager.GetComponent<UI>().accuPanel == true && Input.GetButton("Interact") == true)
                {
                    GameObject.FindWithTag("WireTag").GetComponent<Image>().sprite = manager.GetComponent<UI>().carAccu;
                    WireHolder = manager.GetComponent<UI>().carAccu;
                    manager.GetComponent<UI>().accuPanel.SetActive(false);
                }
            }
            else
            {
                Debug.Log("Open New Area First");
            }
        }
    }

    public void VictorySwitch()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitShop, hitShopRange) && hitShop.transform.tag == ("EscapeCar"))
        {
            if (WireHolder != null)
            {
                if (WireHolder == manager.GetComponent<UI>().carAccu)
                {
                    Debug.Log("Got Accu");
                    manager.GetComponent<UI>().vicPanel.SetActive(true);
                    manager.GetComponent<UI>().needAccuPanel.SetActive(false);
                    if (manager.GetComponent<UI>().vicPanel == true && Input.GetButton("Interact") == true)
                    {
                        GameObject.FindWithTag("WireTag").GetComponent<Image>().sprite = null;
                        WireHolder = null;
                        manager.GetComponent<UI>().YouWin();
                        manager.GetComponent<UI>().vicPanel.SetActive(false);
                    }
                }
                else
                {
                    Debug.Log("Need accu");
                    manager.GetComponent<UI>().needAccuPanel.SetActive(true);
                }
            }
            else
            {
                manager.GetComponent<UI>().needAccuPanel.SetActive(true);
            }
        }
    }

    public void LookAtBarricade()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitShop, hitShopRange) && hitShop.transform.tag == ("Baricade"))
        {
            manager.GetComponent<UI>().BarricadePanel.SetActive(true);
        }
        else
        {
            manager.GetComponent<UI>().BarricadePanel.SetActive(false);
        }
    }

}

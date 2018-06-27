﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [Header("Stamina")]
    public float maxStamina;
    public float stamina;
    public float timeTillStaminaRegen;
    public float staminaRegenRate;

    [Header("Jumping")]
    public float jumpHeight;
    public float jumpStaminaDrain;
    bool canJump = false;

    [Header("Sprinting")]
    public float sprintMultiplier;
    public float sprintStaminaDrain;
    bool canSprint = false;

    [Header("Movement")]
    public float moveSpeed;
    public float moveSpeedBaseValue;
    float moveSpeedReset;
    Vector3 movementVector;

    [Header("OpenShop")]
    public int hitShopRange;
    public RaycastHit hitShop;

    [Header("Rest")]
    public int money;
    public Sprite WireHolder;
    public bool shopOpenBool = false;
    public List<GameObject> Weapons = new List<GameObject>();
    GameObject manager;
    float timeSinceStaminaUse;

    void Start()
    {
        stamina = maxStamina;
        moveSpeedReset = moveSpeed;

        manager = GameObject.FindWithTag("Manager");
        WireHolder = GameObject.Find("WireHolder").GetComponent<Image>().sprite;
    }

    void Update ()
    {
        timeSinceStaminaUse += Time.deltaTime;

        if(timeSinceStaminaUse >= timeTillStaminaRegen && stamina <= maxStamina)
        {
            StaminaRegen();
        }

        if(Input.GetButton("Sprint") == true && stamina > 0 && canSprint == true)
        {
            Sprint();
        }
        if(Input.GetButtonUp("Sprint") == true)
        {
            moveSpeed = moveSpeedReset;
        }

        //cantSprint is false while walking backwards
        if(Input.GetAxis("Vertical") < 0)
        {
            canSprint = false;
        }
        else
        {
            canSprint = true;
        }

        OpenShop();
        GeneratorSwitch();

        if (shopOpenBool == true && Input.GetButtonDown("Back"))
        {
            Debug.Log("CloseShop is called");
            GameObject.FindWithTag("Shop").GetComponent<Shop>().ExitShop();
        }
    }

    private void FixedUpdate()
    {
        Move();

        if (Input.GetButtonDown("Jump") == true && canJump == true && stamina >= jumpStaminaDrain)
        {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }

    void Jump()
    {
        Vector3 x = Vector3.zero;
        x.y = jumpHeight;
        gameObject.GetComponent<Rigidbody>().AddForce(x);
        canJump = false;

        stamina -= jumpStaminaDrain;
        timeSinceStaminaUse = 0;
    }

    void StaminaRegen()
    {
        stamina += staminaRegenRate * Time.deltaTime;
    }

    void Sprint()
    {
        moveSpeed = moveSpeedReset * sprintMultiplier;
        stamina -= sprintStaminaDrain * Time.deltaTime;
        timeSinceStaminaUse = 0;
    }

    void Move()
    {
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.z = Input.GetAxis("Vertical");
        transform.Translate(movementVector * moveSpeed * Time.deltaTime);
    }

    public void OpenShop()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hitShop, hitShopRange) && hitShop.transform.tag == ("Shop"))
        {
            if(shopOpenBool == false)
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
                moveSpeed = 0;
                Cursor.lockState = CursorLockMode.None;

                shopOpenBool = true;
                Debug.Log(shopOpenBool);
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
                manager.GetComponent<UI>().GeneratorGotWirePanel.SetActive(true);
                if (manager.GetComponent<UI>().GeneratorGotWirePanel == true && Input.GetButton("Interact") == true)
                {
                    GameObject.FindWithTag("Generator").GetComponent<Generator>().OpenNewArea();
                    WireHolder = null;
                }
            }
            else
            {
                Debug.Log("Need Wire");
                manager.GetComponent<UI>().GeneratorNeedWirePanel.SetActive(true);
            }
        }
        else
        {
            manager.GetComponent<UI>().GeneratorGotWirePanel.SetActive(false);
            manager.GetComponent<UI>().GeneratorNeedWirePanel.SetActive(false);
        }
    }

}

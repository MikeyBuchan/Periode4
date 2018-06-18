using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    Vector3 movementVector;
    float moveSpeedReset;

    [Header("OpenShop")]
    public int hitShopRange;
    public RaycastHit hitShop;
    public List<GameObject> Weapons = new List<GameObject>();
    
    [Header("Rest")]
    public int money;
    float timeSinceStaminaUse;
    public GameObject manager;
    public bool shopOpenBool = false;

    WeaponBase equippedWeapon;

    private void Start()
    {
        stamina = maxStamina;
        moveSpeedReset = moveSpeed;
        moveSpeedBaseValue = moveSpeed;

        manager = GameObject.FindWithTag("Manager");
        
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

    private void Move()
    {
        movementVector.x = Input.GetAxis("Horizontal");
        movementVector.z = Input.GetAxis("Vertical");
        transform.Translate(movementVector * moveSpeed * Time.deltaTime);
    }

    public void OpenShop()
    {
        if(Physics.Raycast(transform.position, transform.forward, out hitShop, hitShopRange))
        {
            if (hitShop.transform.tag == ("Shop"))
            {
                if(shopOpenBool == false)
                {
                    manager.GetComponent<UI>().openShopPanel.SetActive(true);
                    manager.GetComponent<UI>().openShopText.SetActive(true);
                    
                }

                if (hitShop.transform.tag == ("Shop") && Input.GetButtonDown("Interact"))
                {
                    Debug.Log("shop is opend");

                    shopOpenBool = true;


                    manager.GetComponent<UI>().openShopText.SetActive(false);
                    manager.GetComponent<UI>().shopPanel.SetActive(true);
                    manager.GetComponent<UI>().CloseShopText.SetActive(true);
                    
                    gameObject.GetComponentInChildren<LookAround>().enabled = false;
                    moveSpeed = 0;
                    Cursor.lockState = CursorLockMode.None;
                }
            }
        }
        else
        {
            manager.GetComponent<UI>().openShopPanel.SetActive(false);
            manager.GetComponent<UI>().shopPanel.SetActive(false);
            manager.GetComponent<UI>().CloseShopText.SetActive(false);
            manager.GetComponent<UI>().shopPanel.SetActive(false);
            gameObject.GetComponentInChildren<LookAround>().enabled = true;


            shopOpenBool = false;
            
            Cursor.lockState = CursorLockMode.Locked;
        }
        Debug.DrawRay(transform.position, transform.forward * hitShopRange, Color.cyan);
    }
}

using System.Collections;
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
        //WireHolder = GameObject.FindWithTag("WireTag").GetComponent<Image>().sprite;

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

        //canSprint is false while walking backwards
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
        VictorySwitch();
        PickUpAccu();

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

    //Open things
    public void OpenShop()
    {
        if(Physics.Raycast(transform.position,transform.forward, out hitShop, hitShopRange) && hitShop.transform.tag == ("Shop"))
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
                    manager.GetComponent<UI>().generatorGotWirePanel.SetActive(false);
                    GameObject.FindWithTag("Generator").GetComponent<Generator>().CheckBrokenWire();
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
        else
        {
            manager.GetComponent<UI>().needAccuPanel.SetActive(false);
        }
    }
}

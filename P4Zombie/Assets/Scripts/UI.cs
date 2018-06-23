using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject openShopPanel;

    public GameObject openShopText;
    public GameObject CloseShopText;

    public Button button1;
    public Button button2;
    public Button button3;

	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;

        shopPanel.SetActive(false);
        openShopPanel.SetActive(false);

        openShopText.SetActive(false);
        CloseShopText.SetActive(false);

	}

	void Update ()
    {

	}
}

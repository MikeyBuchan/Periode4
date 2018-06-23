using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject shopPanel;
    public GameObject openShopPanel;
    public GameObject closeShopPanel;

	void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;

        shopPanel.SetActive(false);
        openShopPanel.SetActive(false);
        closeShopPanel.SetActive(false);

	}

	void Update ()
    {

	}
}

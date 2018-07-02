using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : HealthBase
{
    public int playerHealth;
    public GameObject hpNumber;
    public string playerHealthText;

    void Update ()
    {
        playerHealthText = "" + playerHealth;
        hpNumber.GetComponent<Text>().text = playerHealthText;
        if (playerHealth == 0)
        {
            Debug.Log("gameOver");
            GameObject.FindWithTag("Manager").GetComponent<UI>().gameOverPanel.SetActive(true);
            GameObject.FindWithTag("Manager").GetComponent<UI>().gameOverCamera.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Destroy(gameObject);
        }
    }
}

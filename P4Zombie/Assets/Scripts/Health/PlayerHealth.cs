using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : HealthBase
{
    public int playerHealth;

    void Update ()
    {
        if (playerHealth == 0)
        {
            Debug.Log("gameOver");
            GameObject.FindWithTag("Manager").GetComponent<UI>().gameOverPanel.SetActive(true);
            GameObject.FindWithTag("Manager").GetComponent<UI>().gameOverCamera.SetActive(true);
            Destroy(gameObject);
        }
    }
}

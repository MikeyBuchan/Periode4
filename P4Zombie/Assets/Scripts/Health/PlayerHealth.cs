using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : HealthBase
{
    public Slider healthbar;
    public float MaxHealth;
    public float CurrentHealth;

    public void Start()
    {
        MaxHealth = CurrentHealth;
        healthbar.value = CalculatedHealth();
     
    }
    float CalculatedHealth()
    {
        return CurrentHealth / MaxHealth;
    }

    void Update ()
    {
        if (CurrentHealth == 0)
        {
            Debug.Log("gameOver");
            GameObject.FindWithTag("Manager").GetComponent<UI>().gameOverPanel.SetActive(true);
            GameObject.FindWithTag("Manager").GetComponent<UI>().gameOverCamera.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Destroy(gameObject);
        }
    }
}

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
        }
    }
}

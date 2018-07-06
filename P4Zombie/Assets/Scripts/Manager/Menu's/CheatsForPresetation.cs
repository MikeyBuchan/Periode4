using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatsForPresetation : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown ("l"))
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().CurrentHealth = GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().MaxHealth;
        }

    }

}

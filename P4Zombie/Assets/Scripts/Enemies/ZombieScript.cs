﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public int currency;

    Transform targetTransform;
    public float targetDistance;
    public float attackRange;
    public int damage;
    public int maxDamage;
    public bool canDoDammage;
    public float waitTimeForDamage;

    void Start()
    {
        targetTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        canDoDammage = true;
    }


    void Update()
    {
        DoDamageRange();

        if (targetDistance < attackRange)
        {
            DoDamage();
        }
    }


    void DoDamageRange()
    {
        targetDistance = Vector3.Distance(targetTransform.position, transform.position);
    }

    public void DoDamage()
    {
        if (canDoDammage == true)
        {
            GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().CurrentHealth -= damage;
            canDoDammage = false;
            StartCoroutine(DoDamageTimer());
            Debug.Log("PalyerHealth"+ GameObject.FindWithTag("Player").GetComponent<PlayerHealth>().CurrentHealth);
        }
    }

    IEnumerator DoDamageTimer()
    {
        yield return new WaitForSeconds(waitTimeForDamage);
        canDoDammage = true;
    }
}

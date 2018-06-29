using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public int meleeDamage;
    public int meleeDamageBase;
    public int emptyStanimaDamage;
    public float staminaDrain;
    public float range;
    public float attackspeed;

    RaycastHit meleeHit;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            MeleeAttack();
        }
    }

    void MeleeAttack()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().stamina -= staminaDrain;

        if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().stamina <= 20)
        {
            meleeDamage = emptyStanimaDamage;
        }
        if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().stamina > 20)
        {
            meleeDamage = meleeDamageBase;
        }

        if (Physics.Raycast(GameObject.FindWithTag("MainCamera").GetComponent<Transform>().position, GameObject.FindWithTag("MainCamera").GetComponent<Transform>().forward, out meleeHit, range))
        {
            if (meleeHit.transform.tag == "Zombie")
            {
                meleeHit.transform.GetComponent<ZombieHealth>().zombieHealth -= meleeDamage;
                Debug.Log(meleeHit.transform.GetComponent<ZombieHealth>().zombieHealth);

                if (meleeHit.transform.GetComponent<ZombieHealth>().zombieHealth <= 0)
                {
                    GameObject.FindWithTag("Player").GetComponentInParent<PlayerController>().money += meleeHit.transform.GetComponent<ZombieScript>().currency;
                    Debug.Log("cur knife ++");
                }
            }
            Debug.DrawRay(transform.position, transform.forward * range, Color.green);
        }
    }


}

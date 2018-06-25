using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public int damage;
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
        Debug.Log("hdhhdhdhd");
        if (Physics.Raycast(GameObject.FindWithTag("MainCamera").GetComponent<Transform>().position, GameObject.FindWithTag("MainCamera").GetComponent<Transform>().forward, out meleeHit, range))
        {
            if (meleeHit.transform.tag == "Zombie")
            {
                meleeHit.transform.GetComponent<ZombieHealth>().mobHealth -= damage;

                if (meleeHit.transform.GetComponent<ZombieHealth>().mobHealth <= 0)
                {
                    GameObject.FindWithTag("Player").GetComponentInParent<PlayerController>().money += meleeHit.transform.GetComponent<ZombieScript>().currency;
                    Debug.Log("cur ++");
                }
            }
        }
        Debug.DrawRay(transform.position, transform.forward * range, Color.green);
    }


}

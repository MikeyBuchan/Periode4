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
    GameObject weaponLoc;

    private void Start()
    {
        weaponLoc = GameObject.FindWithTag("MainCamera");
    }

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

        if (Physics.Raycast(weaponLoc.gameObject.transform.position, weaponLoc.gameObject.transform.forward, out meleeHit, range))
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
            Debug.DrawRay(weaponLoc.gameObject.transform.position,weaponLoc.gameObject.transform.forward * range, Color.green);
        }
    }


}

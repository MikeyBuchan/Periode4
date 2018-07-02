﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBase : MonoBehaviour
{
    public int damage;
    public int range;
    public float fireRate;
    public bool automatic;
    public bool canFire = true;
    public float reloadTime;
    public int bulletInClip;
    public int clipSize;
    public int ammo;

    public RaycastHit hit;
    public int ownValue;

    public ParticleSystem mf;

    private void Start()
    {
        Instantiate(mf, transform.position + Vector3.forward, transform.rotation);

        bulletInClip = clipSize;
    }

    void Update ()
    {
        if(Input.GetButtonDown("Fire1") == true && canFire == true && bulletInClip > 0 && automatic == false)
        {
            Shoot();

            StartCoroutine("TimeBetweenShots");
        }
        else if(Input.GetButton("Fire1") == true && canFire == true && bulletInClip > 0 && automatic == true)
        {
            Shoot();

            StartCoroutine("TimeBetweenShots");
        }

        if(Input.GetButtonDown("Reload") == true && bulletInClip < clipSize)
        {
            Reload();
        }
	}

    public virtual void Shoot()
    {
        mf.Play();

        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if(hit.transform.tag == "Zombie")
            {
                hit.transform.GetComponent<ZombieHealth>().zombieHealth -= damage;
                if(hit.transform.GetComponent<ZombieHealth>().zombieHealth <= 0)
                {
                    GameObject.FindWithTag("Player").GetComponentInParent<PlayerController>().money += hit.transform.GetComponent<ZombieScript>().currency;
                    Debug.Log("cur ++");
                }
            }
        }
        canFire = false;

        bulletInClip -= 1;
        Debug.Log("Gun Fired");
    }

    public virtual void Reload()
    {
        StartCoroutine("ReloadTime");
    }


    public virtual IEnumerator TimeBetweenShots()
    {
        yield return new WaitForSeconds(fireRate);
        canFire = true;
    }

    public virtual IEnumerator ReloadTime()
    {
        canFire = false;
        yield return new WaitForSeconds(reloadTime);
        ammo -= clipSize;
        bulletInClip = clipSize;
        canFire = true;
        Debug.Log("reloaded");
    }
}

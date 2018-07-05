using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : HealthBase
{
    GameObject zomSpawner;
    GameObject man;
    public int ownIndex;
    public int zombieHealth;

    void Start()
    {
        zomSpawner = GameObject.FindWithTag("ZomSpawner");
        man = GameObject.FindWithTag("Manager");
    }

    void Update()
    {
        if (zombieHealth <= 0)
        {
            man.GetComponent<Manager>().curAmountZombie.RemoveAt(ownIndex);
            CheckOwnIndex();
            Destroy(gameObject);
            if (man.GetComponent<Manager>().curAmountZombie.Count == 0)
            {
                Debug.Log("New Wave");
                zomSpawner.GetComponent<ZombieSpawn>().StartNewWave();
            }
        }
    }


    public void CheckOwnIndex()
    {
        for (int i = 0; i < man.GetComponent<Manager>().curAmountZombie.Count; i++)
        {
            if (gameObject == man.GetComponent<Manager>().curAmountZombie[i])
            {
                ownIndex = i;
                break;
            }
        }
    }
}

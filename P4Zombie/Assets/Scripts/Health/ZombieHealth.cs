using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : HealthBase
{
    GameObject zomSpawner;
    public int ownIndex;
    public int mobHealth;

    void Start()
    {
        zomSpawner = GameObject.FindWithTag("ZomSpawner");
    }

    void Update ()
    {
        if (mobHealth <= 0)
        {
            zomSpawner.GetComponent<ZombieSpawn>().curAmountZombie.RemoveAt(ownIndex);
            CheckOwnIndex();
            Destroy(gameObject);
            if (zomSpawner.GetComponent<ZombieSpawn>().curAmountZombie.Count == 0)
            {
                Debug.Log("New Wave");
                zomSpawner.GetComponent<ZombieSpawn>().StartNewWave();
            }
        }
    }


    public void CheckOwnIndex()
    {
        for (int i = 0; i < zomSpawner.GetComponent<ZombieSpawn>().curAmountZombie.Count; i++)
        {
            if (gameObject == zomSpawner.GetComponent<ZombieSpawn>().curAmountZombie[i])
            {
                ownIndex = i;
                break;
            }
        }
    }
}

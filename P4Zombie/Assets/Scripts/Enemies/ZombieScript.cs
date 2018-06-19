using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public int health;
    public int currency;
    int ownindex;

    GameObject zomSpawner;

    void Start()
    {
        zomSpawner = GameObject.FindWithTag("ZomSpawner");
    }


    void Update()
    {
        if (health <= 0)
        {
            zomSpawner.GetComponent<ZombieSpawn>().curAmountZombie.RemoveAt(ownindex);
            CheckOwnIndex();
            Destroy(gameObject);
        }
    }

    public void CheckOwnIndex()
    {
        for (int i = 0; i < zomSpawner.GetComponent<ZombieSpawn>().curAmountZombie.Count; i++)
        {
            if(gameObject == zomSpawner.GetComponent<ZombieSpawn>().curAmountZombie[i])
            {
                ownindex = i;
                break;
            }
        }
    }
}

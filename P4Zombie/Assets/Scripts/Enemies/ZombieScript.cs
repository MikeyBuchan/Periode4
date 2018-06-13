using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public int health;
    public int currency;
    public int ownIndex;

    void Update()
    {
        if(health <= 0)
        {
            GameObject.FindWithTag("ZomSpawner").GetComponent<ZombieSpawn>().curAmountZombie.RemoveAt(ownIndex);
            Destroy(gameObject);
        }
    }
}

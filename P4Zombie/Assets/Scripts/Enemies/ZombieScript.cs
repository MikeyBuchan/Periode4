using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public int health;
    public int currency;
    public int ownIndex;

    void Start()
    {
        ownIndex = GameObject.FindWithTag("ZomSpawner").GetComponent<MobSpawner>().curAmountZombie.Count;
        for (int i = 0; i < ownIndex; i++)
        {
            Debug.Log(ownIndex);
            CheckMobhealth();
        }
    }

    void Update()
    {
        CheckMobhealth();
    }

    public void CheckMobhealth()
    {
        if (health <= 0)
        {
            GameObject.FindWithTag("ZomSpawner").GetComponent<ZombieSpawn>().curAmountZombie.RemoveAt(ownIndex);
            Destroy(gameObject);
        }
    }
}

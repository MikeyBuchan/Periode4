using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public int health;
    public int currency;
    public int index;
    public int ownIndex;

    void Start()
    {
        index = GameObject.FindWithTag("ZomSpawner").GetComponent<MobSpawner>().curAmountZombie.Count;
        for (int i = 0; i < index; i++)
        {
            index = ownIndex;
            Debug.Log(ownIndex);
            break;
        }
    }

    void Update()
    {
        if (health <= 0)
        {
            GameObject.FindWithTag("ZomSpawner").GetComponent<ZombieSpawn>().curAmountZombie.RemoveAt(ownIndex);
            Destroy(gameObject);
        }
    }
}

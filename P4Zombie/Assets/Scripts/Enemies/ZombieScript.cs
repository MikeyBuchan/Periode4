using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieScript : MonoBehaviour
{
    public int health;
    public int currency;
    int ownindex;

    public float targetPosition;
    public Transform targetTransform;
    public float targetDistance;

    public float attackRange;
    public int damage;

    GameObject zomSpawner;

    void Start()
    {
        zomSpawner = GameObject.FindWithTag("ZomSpawner");
        targetTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();
        
    }


    void Update()
    {
        if (health <= 0)
        {
            zomSpawner.GetComponent<ZombieSpawn>().curAmountZombie.RemoveAt(ownindex);
            CheckOwnIndex();
            Destroy(gameObject);
            if (zomSpawner.GetComponent<ZombieSpawn>().curAmountZombie.Count == 0)
            {
                Debug.Log("New Wave");
                zomSpawner.GetComponent<ZombieSpawn>().StartNewWave();
            }
        }

        DoDamageRange();

        if (targetDistance < attackRange)
        {
            DoDamage();
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

    void DoDamageRange()
    {
        targetDistance = Vector3.Distance(targetTransform.position, transform.position);
    }

    public void DoDamage()
    {
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().playerHealth -= damage;
        Debug.Log(GameObject.FindWithTag("Player").GetComponent<PlayerController>().playerHealth);
    }
}

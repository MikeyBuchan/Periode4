using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject zombie;
    public float spawTime;
    public bool maySpawn;

    public List<GameObject> curAmountZombie;
    public int spawnAmount;
    public int curSpawned;

    void Start()
    {
        maySpawn = true;
    }

    void Update()
    {
        SpawnZombie();
    }

    void CheckWave()
    {
        if(curSpawned <= spawnAmount)
        {
            maySpawn = true;

            if (curAmountZombie.Count == spawnAmount)
            {
                StopCoroutine(Spawner());

                if (curAmountZombie == null)
                {
                    StartNewWave();
                }

            }
        }

    }

    void StartNewWave()
    {
        curSpawned = 0;
        spawnAmount *= 2;
        SpawnZombie();
    }

    void SpawnZombie()
    {
        if (maySpawn == true)
        {
            StartCoroutine(Spawner());
        }
    }

    IEnumerator Spawner()
    {
        maySpawn = false;
        GameObject g = Instantiate(zombie, transform.position, transform.rotation);
        curAmountZombie.Add(g);
        yield return new WaitForSeconds(spawTime);
        curSpawned++;
        CheckWave();
    }
}

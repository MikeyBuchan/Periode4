using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject zombie;
    public float spawTime;
    public bool maySpawn;
    public int spawnAmount;
    public int spawAmountForNewWave;
    public int curSpawned;
    GameObject man;

    void Start()
    {
        maySpawn = true;
        man = GameObject.FindWithTag("Manager");
    }

    void Update()
    {
        SpawnZombie();
    }

    void CheckWave()
    {
        if(curSpawned < spawnAmount)
        {
            maySpawn = true;

            if (man.GetComponent<Manager>().curAmountZombie.Count == spawnAmount)
            {
                StopCoroutine(Spawner());
            }
        }

    }

    public virtual void StartNewWave()
    {
        curSpawned = 0;
        spawnAmount += spawAmountForNewWave;
        man.GetComponent<Manager>().waveCounter++;
        maySpawn = true;
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
        man.GetComponent<Manager>().curAmountZombie.Add(g);
        yield return new WaitForSeconds(spawTime);
        curSpawned++;
        CheckWave();
    }
}

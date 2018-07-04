using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject zombie;
    public float spawTime;
    public bool maySpawn;
    public bool spawnerActive;
    public int spawnAmount;
    public int curSpawned;
    GameObject man;
    GameObject gen;

    void Start()
    {
        maySpawn = true;
        man = GameObject.FindWithTag("Manager");
        gen = GameObject.FindWithTag("Generator");
    }

    void Update()
    {
        SpawnZombie();
    }

    void CheckWave()
    {
        if (curSpawned < spawnAmount)
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
        man.GetComponent<Manager>().waveCounter++;
        GameObject.FindWithTag("Zombie").GetComponent<ZombieHealth>().zombieHealth += man.GetComponent<Manager>().AddHealthForNewWave;
        if (GameObject.FindWithTag("Zombie").GetComponent<ZombieScript>().damage < GameObject.FindWithTag("Zombie").GetComponent<ZombieScript>().maxDamage)
        {
            GameObject.FindWithTag("Zombie").GetComponent<ZombieScript>().damage += man.GetComponent<Manager>().addDamageForNewWave;
        }
        maySpawn = true;
        CheckForSpawner();
    }

    public void CheckForSpawner()
    {
        for (int i = 0; i < gen.GetComponent<Generator>().spawnersArr.Length; i++)
        {
            if (gen.GetComponent<Generator>().spawnersArr[i].gameObject.GetComponent<ZombieSpawn>().spawnerActive == true)
            {
                Debug.Log(gen.GetComponent<Generator>().spawnersArr[i]);
                gen.GetComponent<Generator>().spawnersArr[i].gameObject.GetComponent<MobSpawner>().curSpawned = 0;
                gen.GetComponent<Generator>().spawnersArr[i].gameObject.GetComponent<MobSpawner>().spawnAmount += man.GetComponent<Manager>().spawAmountForNewWave;
                man.GetComponent<Manager>().CheckSpawner();
                
            }
        }
    }

    public void SpawnZombie()
    {
        if (maySpawn == true)
        {
            StartCoroutine(Spawner());
        }
    }

    public virtual IEnumerator Spawner()
    {
        maySpawn = false;
        GameObject g = Instantiate(zombie, transform.position, transform.rotation);
        man.GetComponent<Manager>().curAmountZombie.Add(g);
        yield return new WaitForSeconds(spawTime);
        curSpawned++;
        CheckWave();
    }
}

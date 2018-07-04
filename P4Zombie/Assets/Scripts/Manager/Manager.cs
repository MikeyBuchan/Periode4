using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public List<GameObject> curAmountZombie;
    public int waveCounter = 1;
    public int spawAmountForNewWave;

    public void CheckSpawner()
    {
        for (int i = 0; i < GameObject.FindWithTag("Generator").GetComponent<Generator>().spawnersArr.Length; i++)
        {
            if (GameObject.FindWithTag("ZomSpawner").GetComponent<ZombieSpawn>().spawnerActive == true)
            {
                GameObject.FindWithTag("ZomSpawner").GetComponent<ZombieSpawn>().SpawnZombie();
                
            }
        }
    }
}

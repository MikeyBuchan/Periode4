using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] barricade;
    public GameObject[] spawnersArr;

    void Start()
    {
        
    }

    public void OpenNewArea()
    {
        for (int i = 0; i < barricade.Length; i++)
        {
            if (barricade[i].gameObject.activeSelf == true)
            {
                Debug.Log(i + "New Zone");
                barricade[i].SetActive(false);
                break;
            }
        }

        for (int i = 0; i < spawnersArr.Length; i++)
        {
            if (spawnersArr[i].gameObject.activeSelf == false)
            {
                Debug.Log(i + "New Spawner");
                spawnersArr[i].SetActive(true);
                spawnersArr[i].gameObject.GetComponent<ZombieSpawn>().spawnerActive = true;
                break;
            }
        }
    }
}

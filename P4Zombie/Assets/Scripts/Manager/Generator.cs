using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] barricade;
    public GameObject[] spawnersArr;
    public GameObject[] lightsArr;

    void Start()
    {
        
    }

    public void OpenNewArea()
    {
        for (int i = 0; i < barricade.Length; i++)
        {
            if (barricade[i].gameObject.activeSelf == true)
            {
                barricade[i].SetActive(false);
                break;
            }
        }

        for (int i = 0; i < spawnersArr.Length; i++)
        {
            if (spawnersArr[i].gameObject.activeSelf == false)
            {
                spawnersArr[i].SetActive(true);
                spawnersArr[i].gameObject.GetComponent<ZombieSpawn>().spawnerActive = true;
                break;
            }
        }

        for (int i = 0; i < lightsArr.Length; i++)
        {
            lightsArr[i].SetActive(true);
            break;

            if (lightsArr[i].gameObject.activeSelf == false)
            {

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject spawnerZone1;
    public GameObject spawnerZone2;
    public GameObject spawnerZone3;
    public GameObject spawnerZone4;
    public GameObject spawnerZone5;

    public GameObject[] barricade;
    public GameObject[] spawners;

    void Start()
    {
        /*spawnerZone2.SetActive(false);
        spawnerZone3.SetActive(false);
        spawnerZone4.SetActive(false);
        spawnerZone5.SetActive(false);*/
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

        for (int i = 0; i < spawners.Length; i++)
        {
            if (spawners[i].gameObject.activeSelf == false)
            {
                Debug.Log(i + "New Spawner");
                spawners[i].SetActive(true);
                break;
            }
        }
    }
}

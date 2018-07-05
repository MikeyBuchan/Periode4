using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] barricade;
    public GameObject[] spawnersArr;
    public GameObject[] lightsArr;
<<<<<<< HEAD
    public GameObject[] leverArr;
    public GameObject[] brokeWireArr;
=======
    public GameObject[] brokenWireArr;
    public GameObject[] LeverArr;
>>>>>>> 8b84d0affa4368b465f6ae70458b0b16f4cbdf77

    public void CheckBrokenWire()
    {
<<<<<<< HEAD
        for (int i = 0; i < brokeWireArr.Length; i++)
        {
            if (brokeWireArr[i].gameObject.activeSelf == true)
            {
                brokeWireArr[i].gameObject.SetActive(false);
                GameObject.FindWithTag("Lever").GetComponent<Lever>().active = true;
                CheckLever();
            }
        }
    }

    public void CheckLever()
    {
        for (int i = 0; i < leverArr.Length; i++)
        {
            if (leverArr[i].gameObject.GetComponent<Lever>().active == true) 
            {
                leverArr[i].gameObject.GetComponent<Lever>().FlipSwitch();
                break;
=======

    }

    public void CheckBrokenWire()
    {
        for (int i = 0; i < brokenWireArr.Length; i++)
        {
            if (brokenWireArr[i].gameObject.activeSelf == true)
            {
                brokenWireArr[i].gameObject.SetActive(false);

            }
        }

        for (int i = 0; i < LeverArr.Length; i++)
        {
            if (LeverArr[i])
            {

>>>>>>> 8b84d0affa4368b465f6ae70458b0b16f4cbdf77
            }
        }
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
        }
    }
}

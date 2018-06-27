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

    public GameObject barricade1;
    public GameObject barricade2;
    public GameObject barricade3;
    public GameObject barricade4;

    void Start()
    {
        spawnerZone2.SetActive(false);
        spawnerZone3.SetActive(false);
        spawnerZone4.SetActive(false);
        spawnerZone5.SetActive(false);
    }
}

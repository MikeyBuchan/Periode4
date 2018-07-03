using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireBuy : MonoBehaviour
{
    void BuyWire()
    {
        GameObject.FindGameObjectWithTag("WireTag").SetActive(true);
        GameObject.FindGameObjectWithTag("Player")
    }
}

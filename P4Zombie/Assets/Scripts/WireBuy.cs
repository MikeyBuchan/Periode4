using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WireBuy : MonoBehaviour
{
    public void BuyWire()
    {
        GameObject.FindGameObjectWithTag("WireTag").SetActive(true);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerContact>().WireHolder = GameObject.FindWithTag("Manager").GetComponent<UI>().wireSpriteHolder;
        GameObject.FindWithTag("WireTag").GetComponent<Image>().sprite = GameObject.FindWithTag("Manager").GetComponent<UI>().wireSpriteHolder;
    }
}

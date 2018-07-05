using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WireBuy : MonoBehaviour
{
    GameObject playerCon;

    void Start()
    {
        playerCon = GameObject.FindWithTag("Player");
    }

    public void BuyWire(Button b)
    {
        if (playerCon.GetComponent<PlayerInteract>().WireHolder == null)
        {
            playerCon.GetComponent<PlayerInteract>().WireHolder = GameObject.FindWithTag("Manager").GetComponent<UI>().wireSpriteHolder;
            GameObject.FindWithTag("WireTag").GetComponent<Image>().sprite = GameObject.FindWithTag("Manager").GetComponent<UI>().wireSpriteHolder;
            Debug.Log("You bought a wire");
        }
        else
        {
            Debug.Log("you already have a wire");
        }
    }
}

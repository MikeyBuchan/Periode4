using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAddScript : MonoBehaviour {
    public PlayerController playerScript;
    public GameObject weaponGameobject;
    public int value;
    public GameObject worthBox;
    public string displayPrice;

    public void Weapon()
    {
        if (playerScript.Weapons.Count < 2)
        {
            if (playerScript.money >= value)
            {
                {
                    Debug.Log("IT DOES SOMETHING");
                    playerScript.Weapons.Add(weaponGameobject);
                    playerScript.money -= value;
                }
            }
        }
    }

    public void OnMouseOver()
    {
        Debug.Log("it works");
        displayPrice = "" + value;
        worthBox.GetComponent<Text>().text = displayPrice;
    }
}

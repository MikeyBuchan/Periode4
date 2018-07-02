using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponAddScript : MonoBehaviour
{
    public PlayerController playerScript;
    public GameObject weaponGameobject;
    public int value;
    public GameObject worthBox;
    public string displayPrice;

    public void Weapon()
    {
        if (playerScript.Weapons.Count < 2 & playerScript.money >= value)
        {
            playerScript.Weapons.Add(weaponGameobject);
            playerScript.money -= value;
        }
        else
        {
            playerScript.Weapons[playerScript.gameObject.GetComponent<WeaponSwitch>().activeIndex] = weaponGameobject;
        }
    }

    public void OnMouseOver()
    {
        displayPrice = "" + value;
        worthBox.GetComponent<Text>().text = displayPrice;
    }
}

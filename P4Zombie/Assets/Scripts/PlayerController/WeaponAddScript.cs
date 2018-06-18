using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAddScript : MonoBehaviour {
    public PlayerController playerScript;
    public GameObject weaponGameobject;

    public void Weapon()
    {
        Debug.Log("IT DOES SOMETHING");
        playerScript.Weapons.Add(weaponGameobject);
    }
}

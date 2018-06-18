using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAddScript : MonoBehaviour {
    public PlayerController playerScript;
    public GameObject weaponGameobject;
    public int value;

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
}

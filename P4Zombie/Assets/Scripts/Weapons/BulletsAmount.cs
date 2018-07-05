using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletsAmount : MonoBehaviour {
    public GameObject weapon;
    public GameObject player;
    public int ammo;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        weapon = player.GetComponent<PlayerController>().Weapons[0];
        ammo = weapon.GetComponent<WeaponBase>().bulletInClip;
        gameObject.GetComponent<Text>().text = "" + ammo;
	}
}

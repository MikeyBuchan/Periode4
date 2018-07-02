using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {

    int activeIndex;
    GameObject player;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
    {
		if(Input.GetButtonDown("WeaponSwitch") == true)
        {
            Switch();
        }
	}

    void Switch()
    {
        if(player.GetComponent<PlayerController>().Weapons.Count > 1)
        {
            if (activeIndex == 0)
            {
                activeIndex = 1;
 
                transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                activeIndex = 0;
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }

            if (transform.childCount != 2)
            {
                GameObject x = Instantiate(player.GetComponent<PlayerController>().Weapons[activeIndex], transform.position, transform.rotation);
                x.transform.SetParent(transform);
                x.SetActive(false);
                x = null;
            }
        }
    }
}

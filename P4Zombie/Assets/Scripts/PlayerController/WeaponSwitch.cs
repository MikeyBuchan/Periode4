using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour {

    public int activeIndex;
    GameObject player;

	void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	void Update ()
    {
		if(Input.GetButtonDown("WeaponSwitch") == true)
        {
            if (transform.childCount != 2 && player.GetComponent<PlayerController>().Weapons.Count != 0)
            {
                GameObject x = Instantiate(player.GetComponent<PlayerController>().Weapons[1], transform.position, transform.rotation);
                x.transform.SetParent(transform);
                x.SetActive(false);
                x = null;
            }

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
                transform.GetChild(1).gameObject.SetActive(true);
                transform.GetChild(0).gameObject.SetActive(false);
            }
            else
            {
                activeIndex = 0;
                transform.GetChild(0).gameObject.SetActive(true);
                transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }
}

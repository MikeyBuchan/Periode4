using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool leverIsSwitch;

    public void SwitchLever()
    {
        if (leverIsSwitch == true)
        {
            //play animation
            GameObject.FindWithTag("Generator").GetComponent<Generator>().OpenNewArea();

        }
    }
}

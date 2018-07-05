using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool active;

    public void FlipSwitch()
    {
        if (active == true)
        {
            //play animation
            GameObject.FindWithTag("Generator").GetComponent<Generator>().OpenNewArea();
        }
    }

}

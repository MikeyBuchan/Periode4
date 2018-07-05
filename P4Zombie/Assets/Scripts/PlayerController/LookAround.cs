using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAround : MonoBehaviour
{
    public float sensitivity;
    private Transform player;
    private Vector3 v;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        transform.Rotate((-Input.GetAxis("Mouse Y")) * sensitivity * Time.deltaTime, 0, 0);
        player.Rotate(0, (Input.GetAxis("Mouse X")) * sensitivity * Time.deltaTime, 0);
    }
}

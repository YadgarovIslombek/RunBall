using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class ControlBall : MonoBehaviour
{
    private Rigidbody rb;

    //bu o'nga chapga burilish tezligi
    [Tooltip("bu o'nga chapga burilish tezligi")]
    [Range(0,10)]
    public float dodgeSpeed = 5 ;

    //bu to'griga tezlik
    [Tooltip("bu to'griga tezlik")]
     [Range(0,15)]
    public float roolSpeed = 5;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var horizontalSpeed = Input.GetAxis("Horizontal") * dodgeSpeed;
        rb.AddForce(horizontalSpeed,0,roolSpeed);
        
    }
}

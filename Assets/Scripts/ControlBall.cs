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
    [Tooltip("bu onga chapga burilish tezligi")]
    [Range(0, 100)]
    public float dodgeSpeed = 5;

    //bu to'griga tezlik
    [Tooltip("bu togriga tezlik")]
    [Range(0, 15)]
    public float roolSpeed = 5;


    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        // Check if we're moving to the side
        var horizontalSpeed = Input.GetAxis("Horizontal")
        * dodgeSpeed;
        /* Check if we are running either in the Unity
        editor or in a * standalone build.*/
    #if UNITY_STANDALONE || UNITY_WEBPLAYER || UNITY_EDITOR
        /* If the mouse is held down (or the screen is
        tapped * on Mobile */
        if (Input.GetMouseButton(0))
        {
            var screenPos = Input.mousePosition;
            horizontalSpeed =
            CalculateMovement(screenPos);
        }
    /* Check if we are running on a mobile device */
    #elif UNITY_IOS || UNITY_ANDROID


// Check if Input has registered more than
// zero touches
if (Input.touchCount > 0)
{
/* Store the first touch detected */
var firstTouch = Input.touches[0];
var screenPos = firstTouch.position;
horizontalSpeed =
CalculateMovement(screenPos);
}
#endif
rb.AddForce(horizontalSpeed, 0, roolSpeed);
       
       
       
       
       
        //agar mobile da bo'lsa
        // if(Input.GetMouseButton(0)){
        //     var cam = Camera.main;

        //     var screenPos = Input.mousePosition;
        //     var viewPos = cam.ScreenToViewportPoint(screenPos);
        //     float xMove = 0;


        //     //agar biz onga bossak
        //     if(viewPos.x<0.5f){
        //         xMove = -1;
        //     }else{
        //         xMove = 1;
        //     }
        //      horizontalSpeed = xMove * dodgeSpeed;
        // }
        // rb.AddForce(horizontalSpeed,0,roolSpeed);

        // /* Check if Input has registered more than 0 touches */
        // if (Input.touchCount > 0)
        // {
        //     var cam = Camera.main;


        //     var firstTouch = Input.touches[0];
        //     /* Converts mouse position to a 0 to 1 range
        //     */
        //     var screenPos = firstTouch.position;
        //     var viewPos = cam.ScreenToViewportPoint(screenPos);

        //     float xMove = 0;

        //     /* If we press the right side of the screen */
        //     if (viewPos.x < 0.5f)
        //     {
        //         xMove = -1;
        //     }
        //     else
        //     {
        //         /* Otherwise we're on the left */
        //         xMove = 1;
        //     }
        //     horizontalSpeed = xMove * dodgeSpeed;

        // }

        // rb.AddForce(horizontalSpeed, 0, roolSpeed);
    }


 private float CalculateMovement(Vector3 screenPos)
    {
        /* Get a reference to the camera for converting
        * between spaces */
        var cam = Camera.main;
        /* Converts mouse position to a 0 to 1 range */
        var viewPos =
        cam.ScreenToViewportPoint(screenPos);
        float xMove = 0;
        /* If we press the right side of the screen */
        if (viewPos.x < 0.5f)
        {

            xMove = -1;
        }
        else
        {
            /* Otherwise we're on the left */
            xMove = 1;
        }
        /* Replace horizontalSpeed with our own value */
        return xMove * dodgeSpeed;
    }
   
}



using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;


    /// <summary>
        /// Will adjust the camera to follow and face a target
    /// </summary>

public class CameraBehaviour : MonoBehaviour
{
    [Tooltip("На какой объект должна смотреть камера")]
    public  Transform target;

    [Tooltip("Kamera targetga qanchalik mos keladi")]
    public Vector3 offset = new Vector3(0,3,-6);

    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null){
            // Set our position to an offset of our target
            transform.position = target.position + offset;
            // Change the rotation to face target
            transform.LookAt(target);
        }
        
    }
}

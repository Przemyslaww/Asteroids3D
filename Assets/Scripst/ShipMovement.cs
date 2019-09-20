using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] float movSpeed = 50f;
    [SerializeField] float turnSpeed = 70f;
    [SerializeField] Thruster[] thruster;
    Transform shipTrans;
   
    void Start()
    {
        shipTrans = transform;
    }

    void Update()
    {
        Thrust();
        Turn();
    
    }

    void Turn()
    {
        //yaw - y Axis
        //roll - z Axis
        //pitch - x Axis

        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Yaw");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch");
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll");
        shipTrans.Rotate(pitch, yaw, roll);
    }

    void Thrust()
    {
        if(Input.GetAxis("Vertical") > 0 )
        {
            shipTrans.position += shipTrans.forward * movSpeed * Time.deltaTime * Input.GetAxis("Vertical");
            
        }
        else
        {

        }
    }


}

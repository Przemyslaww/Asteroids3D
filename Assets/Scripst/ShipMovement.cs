using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] float movSpeed = 50f;
    [SerializeField] float turnSpeed = 70f;

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

        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal");
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Vertical");
        shipTrans.Rotate(-pitch, yaw, 0);
    }

    void Thrust()
    {
        shipTrans.position += shipTrans.forward * movSpeed * Time.deltaTime;
    }



}

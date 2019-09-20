using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Light))]
[RequireComponent(typeof(LineRenderer))]
public class Laser : MonoBehaviour
{
    [SerializeField] float laserTime = 0.5f;
    [SerializeField] float maxDistance = 300f;
    [SerializeField] float fireDelay = 2f;

    LineRenderer lr;
    Light laserLight;
    bool canFire;


    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        laserLight = GetComponent<Light>();
    }
 
    void Start()
    {
        lr.enabled = false;
        laserLight.enabled = false;
        canFire = true;

    }



    Vector3 CastRay()
    {
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward) * maxDistance;
        if(Physics.Raycast(transform.position, forward, out hit))
        {
            Debug.Log("We hit: " + hit.transform.name);
            Explosion temp = hit.transform.GetComponent<Explosion>();
            if (temp != null)
                temp.HitByLaser(hit.point);
            return hit.point;
        }
        else
        {
            Debug.Log("Miss");
            return transform.position + (transform.forward * maxDistance);
        }

        
    }
    public void FireLaser()
    { 
        if(canFire)
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, CastRay());
            lr.enabled = true;
            laserLight.enabled = true;
            canFire = false;
            Invoke("TurnOffLaser", laserTime);
            Invoke("CanFire", fireDelay);
        }
    }

    void TurnOffLaser()
    {
        lr.enabled = false;
        laserLight.enabled = false;
        canFire = true;
    }

    public float Distance
    {
        get { return maxDistance; }
    } 

    void CanFire()
    {
        canFire = true;
    }
}

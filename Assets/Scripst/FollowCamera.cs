using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Vector3 defaultDistance = new Vector3(0f, 3f, -12f);
    [SerializeField] float distanceDamp = 0.5f;

    private Vector3 velocity = Vector3.one;
    Transform cameraTrans;

    private void Awake()
    {
        cameraTrans = transform;
    }

    void Start()
    {
        
    }

    void LateUpdate()
    {
        SmoothFollow();   
    }

    void SmoothFollow()
    {
        Vector3 toPos = target.position + (target.rotation * defaultDistance);
        Vector3 currentPos = Vector3.SmoothDamp(cameraTrans.position, toPos, ref velocity, distanceDamp);

        cameraTrans.position = currentPos;
        cameraTrans.LookAt(target, target.up);
    }


}

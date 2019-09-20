using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] float minScale = 0.8f;
    [SerializeField] float maxScale = 1.2f;
    [SerializeField] float rotationOffset = 50f;

    Vector3 randomRotation;
    Transform asteroidTrans;

    private void Awake()
    {
        asteroidTrans = transform;
    }

    void Start()
    {
        RandomScale();
        RandomRotation();
    }

    void Update()
    {
        asteroidTrans.Rotate(randomRotation * Time.deltaTime);
    }

    void RandomScale()
    {
        Vector3 scale = Vector3.one;
        scale.x = Random.Range(minScale, maxScale);
        scale.y = Random.Range(minScale, maxScale);
        scale.z = Random.Range(minScale, maxScale);

        asteroidTrans.localScale = scale;
    }

    void RandomRotation()
    {
        randomRotation.x = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.y = Random.Range(-rotationOffset, rotationOffset);
        randomRotation.z = Random.Range(-rotationOffset, rotationOffset);
    }
}

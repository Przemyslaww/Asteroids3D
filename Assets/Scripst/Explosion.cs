using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject[] explosion;
    public void HitByLaser(Vector3 pos)
    {
        int i = Random.Range(0, explosion.Length);
        GameObject go = Instantiate(explosion[i], pos, Quaternion.identity, transform) as GameObject;
        Destroy(go, 3f);
    }
}

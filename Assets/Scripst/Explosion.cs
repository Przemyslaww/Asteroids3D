using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Explosion : MonoBehaviour
{
    [SerializeField] GameObject[] explosion;
    [SerializeField] Asteroid smallAsteroid;
    [SerializeField] Asteroid mediumAsteroid;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip audioClip;

    private bool alreadyHit = false;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioClip;
    }

    public void HitByLaser(Vector3 pos)
    {
        if(!alreadyHit)
        {
            int i = Random.Range(0, explosion.Length);  // if i want more than one explosion effect
            GameObject go = Instantiate(explosion[i], pos, Quaternion.identity, null) as GameObject;
            Destroy(go, 2f);
            audioSource.Play(); // needs to be fixed
            if (gameObject.tag == "MediumAsteroid")
            {
                InstantiateAsteroid(pos, "SmallAsteroid", 2);
            }
            else if (gameObject.tag == "BigAsteroid")
            {
                InstantiateAsteroid(pos, "MediumAsteroid", 2);
            }
            Destroy(gameObject);
            alreadyHit = true;
        }
    }

    void InstantiateAsteroid(Vector3 pos, string asteroidTag, int howMany)
    {
        for (int i = 0; i < howMany; i++)
        {
            if (asteroidTag == smallAsteroid.tag)
            {
                Instantiate(smallAsteroid, pos, Quaternion.identity);
            }
            else if (asteroidTag == mediumAsteroid.tag)
            {
                Instantiate(mediumAsteroid, pos, Quaternion.identity);
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] Asteroid[] asteroid;

    [SerializeField] int gridCellsOnAxis = 10;
    [SerializeField] int gridSpacing = 30;

    Transform gridTrans;

    void Start()
    {
        gridTrans = transform;
        PlaceAsteroids();
    }

    void Update()
    {
        
    }

    void PlaceAsteroids()
    {
        for(int x = 0; x < gridCellsOnAxis; x++)
        {
            for (int y = 0; y < gridCellsOnAxis; y++)
            {
                for (int z = 0; z < gridCellsOnAxis; z++)
                {
                    InstantiateRandomAsteroid(x, y, z);
                }
            }
        }
    }

    void InstantiateRandomAsteroid(int x, int y, int z)
    {
        int i = Random.Range(0,asteroid.Length);
        Instantiate(asteroid[i], 
        new Vector3(gridTrans.position.x + (x * gridSpacing) + AsteroidOffset(),
                    gridTrans.position.y + (y * gridSpacing) + AsteroidOffset(),
                    gridTrans.position.z + (z * gridSpacing) + AsteroidOffset()),
                    Quaternion.identity,
                    gridTrans );
    }



    float AsteroidOffset()
    {
       return Random.Range(-gridSpacing / 2f, gridSpacing / 2f);
    }
}

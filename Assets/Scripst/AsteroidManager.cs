using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] Asteroid asteroid;
    [SerializeField] int gridCellsOnAxis = 10;
    [SerializeField] int gridSpacing = 30;

    Transform gridTrans;

    // Start is called before the first frame update
    void Start()
    {
        gridTrans = transform;
        PlaceAsteroids();
    }

    // Update is called once per frame
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
                    InstantiateAsteroid(x, y, z);
                }
            }
        }
    }

    void InstantiateAsteroid(int x, int y, int z)
    {
        Instantiate(asteroid,
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

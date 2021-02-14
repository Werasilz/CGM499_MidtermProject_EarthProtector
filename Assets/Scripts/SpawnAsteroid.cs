using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    public static SpawnAsteroid instance;

    public GameObject asteroid;
    public GameObject[] spawnPoint;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {

    }

    public void StartRandom()
    {
        StartCoroutine(RandomSpawnAsteroid());
    }

    void Update()
    {

    }

    public IEnumerator RandomSpawnAsteroid()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            int i = Random.Range(1, 5);

            //North SpawnPoint 0
            if(i == 1)
            {
                Instantiate(asteroid, new Vector3(Random.Range(-2, 3), spawnPoint[0].transform.position.y, spawnPoint[0].transform.position.z), Quaternion.identity);
            }
            //East SpawnPoint 1
            else if (i == 2)
            {
                Instantiate(asteroid, new Vector3(spawnPoint[1].transform.position.x, spawnPoint[1].transform.position.y, Random.Range(-2, 3)), Quaternion.identity);
            }
            //South SpawnPoint 2
            else if (i == 3)
            {
                Instantiate(asteroid, new Vector3(Random.Range(-2, 3), spawnPoint[2].transform.position.y, spawnPoint[2].transform.position.z), Quaternion.identity);
            }
            //West SpawnPoint 3
            else if (i == 4)
            {
                Instantiate(asteroid, new Vector3(spawnPoint[3].transform.position.x, spawnPoint[3].transform.position.y, Random.Range(-2, 3)), Quaternion.identity);
            }
        }
    }
}

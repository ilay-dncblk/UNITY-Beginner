using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    //put obstacles in platform 

    public GameObject obstacle;
    public GameObject[] obstacles;

    public float spawnZ = 0f;
    public float obstacleLength = 10f;
    public int amountOfObstacles = 5;

    public GameObject gold;
    public GameObject[] golds;

    public float spawnZGold = 0f;
    public float goldLength = 10f;
    public int amountOfGold = 5;

    //spawn obstacles along the platform

    // Start is called before the first frame update
    void Start()
    {
        obstacles = new GameObject[amountOfObstacles];
        for (int i = 0; i < amountOfObstacles; i++)
        {
            obstacles[i] = Instantiate(obstacle, new Vector3(0, 0, 0), Quaternion.identity);
            obstacles[i].transform.SetParent(transform);
        }
        SpawnObstacles();

        golds = new GameObject[amountOfGold];
        for (int i = 0; i < amountOfGold; i++)
        {
            golds[i] = Instantiate(gold, new Vector3(0, 0, 0), Quaternion.identity);
            golds[i].transform.SetParent(transform);
        }
        SpawnGold();
    }

    public void SpawnObstacles()
    {
        for (int i = 0; i < amountOfObstacles; i++)
        {
            obstacles[i].transform.position = new Vector3(Random.Range(-2.5f, 2.5f), 0.5f, spawnZ);
            spawnZ += obstacleLength;
        }
    }

    public void SpawnGold()
    {
        for (int i = 0; i < amountOfGold; i++)
        {
            golds[i].transform.position = new Vector3(Random.Range(-2.5f, 2.5f), Random.Range(.75f,1.75f), spawnZGold);
            spawnZGold += goldLength;
        }
    }
}

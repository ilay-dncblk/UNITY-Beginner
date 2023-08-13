using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obst : MonoBehaviour
{

    public int x;
    public float y;
    public int z;
    public GridSystem gridSystem;
    public GameObject[,,] grid;
    public GameObject obstPrefab;
    public GameObject obst;

    public int inBoardObstCount = 5;

    public int outBoardObstCount = 200;

    // Start is called before the first frame update
    void Start()
    {
        grid = gridSystem.GetGrid();

        for (int i = 0; i < inBoardObstCount; i++)
        {
            SpawnInBoardObst();
        }

        for (int i = 0; i < outBoardObstCount; i++)
        {
            SpawnOutBoardObst();
        }

    }

    public void SpawnInBoardObst()
    {
        x = Random.Range(0, gridSystem.width);
        y = 0.5f;
        z = Random.Range(0, gridSystem.depth);
        obst = Instantiate(obstPrefab, new Vector3(x, y, z), Quaternion.identity);
        obst.transform.parent = transform;

        obst.GetComponent<Renderer>().material.color = Color.gray;

        obst.AddComponent<ObstCollision>();
    }

    public void SpawnOutBoardObst()
    {
        x = Random.Range(-gridSystem.width, gridSystem.width * 2);
        y = 1f;
        z = Random.Range(-gridSystem.depth, gridSystem.depth * 2);
        obst = Instantiate(obstPrefab, new Vector3(x, y, z), Quaternion.identity);
        if (x < 0 || x > gridSystem.width - 1 || z < 0 || z > gridSystem.depth - 1)
        {
        }
        else
        {
            Destroy(obst);
        }
        obst.transform.parent = transform;

        obst.GetComponent<Renderer>().material.color = Color.green;

        obst.AddComponent<ObstCollision>();
    }

}

public class ObstCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            print("Game Over");
            collision.gameObject.transform.position = collision.gameObject.GetComponent<Player>().temp.transform.position;
        }
    }
}

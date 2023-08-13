using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int x;
    public float y;
    public int z;
    public GridSystem gridSystem;
    public GameObject[,,] grid;
    public GameObject enemyPrefab;
    public GameObject enemy;

    public Player player;

    public int enemyCount = 5;

    // Start is called before the first frame update
    void Start()
    {
        grid = gridSystem.GetGrid();

        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
        }

    }

    public void SpawnEnemy()
    {
        x = Random.Range(3, gridSystem.width);
        y = 0.5f;
        z = Random.Range(3, gridSystem.depth);
        enemy = Instantiate(enemyPrefab, new Vector3(x, y, z), Quaternion.identity);
        enemy.transform.parent = transform;
        enemy.tag = "Enemy";
        enemy.transform.rotation = new Quaternion(-90, 0, 0, 90);
        enemy.GetComponent<Renderer>().material.color = Color.red;

        enemy.GetComponent<BoxCollider>().isTrigger = true;

        enemy.AddComponent<EnemyCollision>();
        enemy.GetComponent<EnemyCollision>().player = player;



        player.enemies.Add(enemy);
    }
}

public class EnemyCollision: MonoBehaviour
{
    public Player player;
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            player.enemies.Remove(gameObject);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            print("Game Over");

            Time.timeScale = 0;
        }
    }
}

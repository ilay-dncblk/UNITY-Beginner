using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int x;
    public int y;
    public int z;
    public GridSystem gridSystem;
    public GameObject[,,] grid;
    public GameObject playerPrefab;
    public GameObject player;
    public bool isMoving;
    public bool isMovingX;
    public bool isMovingY;
    public bool isMovingZ;

    public Transform temp;

    public Transform cam;

    public List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        grid = gridSystem.GetGrid();
        player = Instantiate(playerPrefab, new Vector3(x, y, z), Quaternion.identity);
        player.transform.parent = transform;

        

        StartCoroutine(MoveEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) && !isMoving) {
            if(x > 0) {
                temp = player.transform;
                x--;
                isMoving = true;
                isMovingX = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.D) && !isMoving) {
            if(x < gridSystem.width - 1) {
                temp = player.transform;
                x++;
                isMoving = true;
                isMovingX = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.S) && !isMoving) {
            if(z > 0) {
                temp = player.transform;
                z--;
                isMoving = true;
                isMovingZ = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.W) && !isMoving) {
            if(z < gridSystem.depth - 1) {
                temp = player.transform;
                z++;
                isMoving = true;
                isMovingZ = true;
            }
        }

        if(Input.GetKeyDown(KeyCode.Space)) {
            GameObject closestEnemy = ClosestEnemy();
            if(closestEnemy != null) {
                GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                bullet.transform.position = player.transform.position;
                bullet.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                bullet.AddComponent<Rigidbody>();
                bullet.GetComponent<Rigidbody>().AddForce((closestEnemy.transform.position - player.transform.position) * 5000 * Time.deltaTime);
                bullet.GetComponent<Rigidbody>().useGravity = false;
                bullet.GetComponent<SphereCollider>().isTrigger = true;
                bullet.tag = "Bullet";

                if(bullet != null) {
                    Destroy(bullet, 5f);
                }
            }
        }      

    }

    private void LateUpdate() {
        if(isMoving) {
            if(isMovingX) {
                player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(x, y, z), 5 * Time.deltaTime);
                if(player.transform.position.x == x) {
                    isMovingX = false;
                }
            }
            if(isMovingY) {
                player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(x, y, z), 5 * Time.deltaTime);
                if(player.transform.position.y == y) {
                    isMovingY = false;
                }
            }
            if(isMovingZ) {
                player.transform.position = Vector3.MoveTowards(player.transform.position, new Vector3(x, y, z), 5 * Time.deltaTime);
                if(player.transform.position.z == z) {
                    isMovingZ = false;
                }
            }
            if(!isMovingX && !isMovingY && !isMovingZ) {
                isMoving = false;
            }
        }

        cam.position = new Vector3(player.transform.position.x, player.transform.position.y + 8, player.transform.position.z - 8);

        if(enemies.Count == 0) {
            enemies.Clear();
            for(int i = 0; i < 5; i++) {
                GameObject.Find("EnemyManager").GetComponent<Enemy>().SpawnEnemy();
            }
        }
    }

    public IEnumerator MoveEnemies() {
        
        yield return new WaitForSeconds(1f);
        foreach(GameObject enemy in enemies) {
            
            int location = Random.Range(0, 4);
            if(location == 0) {
                if(enemy.transform.position.x > 0) {
                    enemy.transform.position = new Vector3(enemy.transform.position.x - 1, enemy.transform.position.y, enemy.transform.position.z);
                }
            }
            if(location == 1) {
                if(enemy.transform.position.x < gridSystem.width - 1) {
                    enemy.transform.position = new Vector3(enemy.transform.position.x + 1, enemy.transform.position.y, enemy.transform.position.z);
                }
            }
            if(location == 2) {
                if(enemy.transform.position.z > 0) {
                    enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z - 1);
                }
            }
            if(location == 3) {
                if(enemy.transform.position.z < gridSystem.depth - 1) {
                    enemy.transform.position = new Vector3(enemy.transform.position.x, enemy.transform.position.y, enemy.transform.position.z + 1);
                }
            }
            
        }
        
        StartCoroutine(MoveEnemies());
    }

    public GameObject ClosestEnemy() {
        GameObject closestEnemy = null;
        float closestDistance = 50f;
        foreach(GameObject enemy in enemies) {
            float distance = Vector3.Distance(player.transform.position, enemy.transform.position);
            if(distance < closestDistance) {
                closestDistance = distance;
                closestEnemy = enemy;
            }
        }
        return closestEnemy;
    }
}

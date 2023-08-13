using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    public int width;
    public int height;
    public int depth;
    public GameObject[,,] grid;
    public GameObject gridPrefab;

    public GameObject[,,] GetGrid()
    {
        return grid;
    }

    void Start()
    {
        grid = new GameObject[height, width , depth];
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                for (int y = 0; y < height; y++)
                {
                    GameObject gridObj = Instantiate(gridPrefab, new Vector3(x, y, z), Quaternion.identity);
                    gridObj.transform.parent = transform;
                }
            }
        }
    }
}

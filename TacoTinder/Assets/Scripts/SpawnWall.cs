using UnityEngine;
using System.Collections;

public class SpawnWall : MonoBehaviour
{
    public GameObject wallPrefab;

    void Update()
    {
        if (Input.anyKeyDown) buildWall(); 
    }

    void buildWall()
    {
        //Wall left
        GameObject wallLeft = Instantiate(wallPrefab, new Vector3(-2.21f, -0.04f, 0), Quaternion.Euler(0, 0, 353.66f)) as GameObject;
        //Wall right
        GameObject wallRight = Instantiate(wallPrefab, new Vector3(2.45f, -0.11f, 0), Quaternion.Euler(0, 0, -181.4f)) as GameObject;
        //Wall bottom
        GameObject wallBottom = Instantiate(wallPrefab, new Vector3(0.14f, -2.2f, 0), Quaternion.Euler(0, 0, -270.3f)) as GameObject;
        
    }


}


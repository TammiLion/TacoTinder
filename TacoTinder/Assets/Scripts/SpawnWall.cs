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
        GameObject wallLeft = Instantiate(wallPrefab, new Vector3(-2.64f, -0.06f, 0), Quaternion.Euler(0, 0, -0.66f)) as GameObject;
        //Wall right
        GameObject wallRight = Instantiate(wallPrefab, new Vector3(2.81f, -0.21f, 0), Quaternion.Euler(0, 0, 170.7f)) as GameObject;
        //Wall bottom
        GameObject wallBottom = Instantiate(wallPrefab, new Vector3(0.13f, -2.71f, 0), Quaternion.Euler(0, 0, 87.7f)) as GameObject;
        //wallBottom.transform.localScale += new Vector3(0.6f, 0.4f, 0.6f);
    }


}


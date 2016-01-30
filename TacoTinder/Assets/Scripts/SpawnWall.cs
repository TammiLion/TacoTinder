using UnityEngine;
using System.Collections;

public class SpawnWall : MonoBehaviour
{
    public GameObject wall;

    void buildWall()
    {
        GameObject newWall1 = Instantiate(wall, new Vector3(-2.3f, 0, 0), Quaternion.Euler(0, 0, 90)) as GameObject;
        GameObject newWall2 = Instantiate(wall, new Vector3(0, -2.3f, 0), Quaternion.identity) as GameObject;
        GameObject newWall3 = Instantiate(wall, new Vector3(2.3f, 0, 0), Quaternion.Euler(0, 0, 90)) as GameObject;
    }


}


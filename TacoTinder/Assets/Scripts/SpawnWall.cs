using UnityEngine;
using System.Collections;

public class SpawnWall : MonoBehaviour
{

    public GameObject[] players;
    public float timeToDestroy;
    public GameObject wall;
    public float offsetRatio;

    Vector3 offset;

    void Start() { buildWall(); }

    void buildWall()
    {
        Debug.Log("start");
        players = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject player in players)
        {
            Debug.Log(player);
            offset = Vector3.zero;
            if (player.name != "inca")
            {

                if (player.transform.position.y == 0)
                {
                    offset.y -= player.transform.position.x / offsetRatio;
                }
                else {
                    offset.x -= player.transform.position.y / offsetRatio;
                }

                GameObject newWall = Instantiate(wall, player.transform.position + offset, player.transform.rotation) as GameObject;
                Destroy(newWall, timeToDestroy);
            }
        }
    }
}



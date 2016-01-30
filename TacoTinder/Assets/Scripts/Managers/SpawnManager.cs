using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{

    public GameObject mob;
    public Vector2[] spawnPositions;
    public float cooldownTimer;
    public float firstSpawnTime;
 
    Vector2 vectorPos;
    Vector2 dir;


    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnWaves", firstSpawnTime, cooldownTimer); 
    }

    void SpawnWaves()
    {
        //get a random spawn position
        vectorPos = spawnPositions[Random.Range(0, 3)];

        //et direction towards the center
        dir = Vector2.zero - vectorPos;
        dir.Normalize ();

        //instantiate new mob
        Mob newMob = Instantiate(mob, vectorPos , Quaternion.Euler(dir.x,0,dir.y) ) as Mob;
        newMob.type = "rock";
        newMob.isSuper = true;

        //wait this many seconds until it runs again
        
    }
}
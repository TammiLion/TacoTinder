using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{

    public Mob mob;
    public Vector2[] spawnPositions;
    public float cooldownTimer;
    public float firstSpawnTime;
 
    Vector2 vectorPos;
    Vector2 dir;

    string[] gods = { "Mayan", "Egyptian", "Greek", "Japanese", "African"};

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("SpawnMobs", firstSpawnTime, cooldownTimer); 
    }

    void SpawnMobs()
    {
        //get a random spawn position
        vectorPos = spawnPositions[Random.Range(0, spawnPositions.Length)];

        //set direction towards the center and normalize vector
        dir = Vector2.zero - vectorPos;
        dir.Normalize ();

        //instantiate new mob
        Mob newMob = Instantiate(mob, vectorPos , Quaternion.identity ) as Mob;  //rotation not working Quaternion.Euler(dir.x,0,dir.y)

        //make it face the center
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        newMob.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //assign mob attributes
        newMob.god = gods[Random.Range(0,gods.Length)];
        newMob.isSuper = (Random.value > 0.5f);
        newMob.isPossessed = (Random.value > 0.5f);

    }
}
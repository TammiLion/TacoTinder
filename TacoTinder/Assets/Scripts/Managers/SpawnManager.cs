using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{

    public Mob mob;
    public GameObject[] spawnPositions;
    public float cooldownTimer;
    public float firstSpawnTime;
 
    Vector3 spawnLocation;
    Vector2 dir;
	public int maxFatties = 1;
	private int fattiesSpawned = 0;

	private bool isTimedRound = false;

	public void startSpawning(bool timedRound) {
		isTimedRound = timedRound;
		InvokeRepeating("SpawnMobs", firstSpawnTime, cooldownTimer); 
	}
	
	public void stopSpawning() {
		CancelInvoke ();
	}

    void SpawnMobs()
    {
        //get a random spawn position
		spawnLocation = spawnPositions[Random.Range(0, spawnPositions.Length)].transform.position;

        //set direction towards the center and normalize vector
		dir = Vector3.zero - spawnLocation;
        dir.Normalize ();

        //instantiate new mob
		Mob newMob = Instantiate(mob, spawnLocation , Quaternion.identity ) as Mob;  //rotation not working Quaternion.Euler(dir.x,0,dir.y)

        //make it face the center
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //TODO uncommented rotation
		//newMob.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //assign mob attributes
		newMob.god = God.GODS[Random.Range(0, God.GODS.Length)];
        newMob.isSuper = (Random.value < 0.3f);
        newMob.isPossessed = (Random.value < 0.2f);
		if (!isTimedRound && (fattiesSpawned < maxFatties) && Random.value < 0.01f) {
			newMob.isFattyMcFatFuck = true;
			fattiesSpawned += 1;
		}

    }
}
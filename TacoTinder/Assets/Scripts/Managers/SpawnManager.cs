using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{

    public Mob mob;
    public GameObject[] spawnPositions;
	public GameObject fattySpawnPosition;
    public float cooldownTimer;
    public float firstSpawnTime;

	public float fattyRate = 0.01f;
	public float superRate = 0.3f;
	public float possedRate = 0.2f;
 
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
		bool spawnFatty = (!isTimedRound && (fattiesSpawned < maxFatties) && Random.value < fattyRate);

		if (spawnFatty) {
			spawnLocation = fattySpawnPosition.transform.position;
		} else {
			//get a random spawn position
			spawnLocation = spawnPositions [Random.Range (0, spawnPositions.Length)].transform.position;
		}

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
		newMob.isSuper = (Random.value < superRate);
        newMob.isPossessed = (Random.value < possedRate);
		if (spawnFatty) {
			newMob.isFattyMcFatFuck = true;
			fattiesSpawned += 1;
		}

    }
}
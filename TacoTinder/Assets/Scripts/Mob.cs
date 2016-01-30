using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {

    public string type;
    public bool isSuper;
    public Player target;
    public const float INITIAL_SPEED = 1;

    int points;
    float speed = INITIAL_SPEED;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    //update the speed of the mob
	}

    int GetPoints()
    {
        if (isSuper) points += 10;

        if (type = target.type) points ++;

        return points;
    }
}

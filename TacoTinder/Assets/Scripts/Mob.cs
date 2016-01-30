using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {

    public string god;
    public bool isSuper;
    public bool isPossessed;
    public Player target;
    public const float INITIAL_SPEED = 1;

    int points;

    float speed = INITIAL_SPEED;

	// Use this for initialization
	void Start () {
	
	}


	public void getHit (Player player) {
		Debug.Log ("Arrow from" + player + "hit me!");
	}
	
	// Update is called once per frame
	void Update () {
	    //update the speed of the mob
	}

    public int GetPoints()
    {
        if (isSuper) points += 10;

        //if (isPossessed && god != target.god) points -=3;   

        //if (god = target.god) points ++;   

        return points;
    }
}

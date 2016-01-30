using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {

    public string god;
    public bool isSuper = false;
    public bool isPossessed = false;
    public Player target;
    int points = 1;
	
	// Use this for initialization
	void Start () {
		if (target == null) {
			GetComponent<Moveable>().direction = new Vector2(0,0) - new Vector2(transform.position.x, transform.position.y);
		}
		if (isSuper) {
			gameObject.transform.localScale+= new Vector3(0.3f, 0.3f, 0.3f);
		}
		if(isPossessed) {
			gameObject.GetComponent<SpriteRenderer>().color = Color.green;
		}
	}

	public void getHit (Player player) {
		if (target != player) {
			target = player;
			GetComponent<Moveable>().speed+=0.1f;
		}
	}

    public int GetPoints(Player player)
    {
        if (isSuper) points += 10;

        //if (isPossessed && god != target.god) points -=3;   

        //if (god = target.god) points ++;   

        return points;
    }
}

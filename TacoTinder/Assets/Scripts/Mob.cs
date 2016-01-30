﻿using UnityEngine;
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
			moveToPlayer();
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
			if(isPossessed) {
				points--;
			} else {
				points++;
			}
			GetComponent<Moveable>().direction = player.getPosition() - new Vector2(transform.position.x, transform.position.y);
			GetComponent<Moveable>().speed+=0.1f;
		}
	}

    public int GetPoints(Player player)
    {
		if (isSuper) {
			if(isPossessed) {
				if(god == target.god) {
					return points - 3;
				} else {
					return points - 10;
				}
			}
			return points + 10;
		}

		if (isPossessed) {
			if(god == target.god) {
				return points;
			} else {
				return points -3;
			}
		}
        return points;
    }

	public void moveToPlayer() {
		GetComponent<Moveable>().direction = new Vector2(0,0) - new Vector2(transform.position.x, transform.position.y);
	}
}

﻿using UnityEngine;
using System.Collections;
using System;

public class Base : MonoBehaviour
{
	public Player player;
    public int points = 0;
	public UnityEngine.UI.Text scoreText;

	public event EventHandler onEnterBase;
	
	public void onEnterBaseEvent() {
		EventHandler handler = onEnterBase;
		if (handler != null) {
			handler(this, System.EventArgs.Empty);
		}
	}

	public event EventHandler onBadEnterBase;
	
	public void onBadEnterBaseEvent() {
		EventHandler handler = onBadEnterBase;
		if (handler != null) {
			handler(this, System.EventArgs.Empty);
		}
	}
	
    void OnTriggerEnter2D(Collider2D coll)
    {
		if (coll.tag == "Mob") {
			if(coll.GetComponent<Mob>().isPossessed) {
				onBadEnterBaseEvent();
			} else {
				onEnterBaseEvent();
			}
			points += coll.GetComponent<Mob> ().GetPoints (player);
			setPoints();
			Destroy (coll.gameObject);
			checkWinCondition();
		} else if (coll.tag == "Projectile") {
			Destroy (coll.gameObject);
		}
    }

	public void setPoints() {
		scoreText.text = "Score: " + points;
	}

	private void checkWinCondition() {
		if (points >= GameManager.WIN_POINTS) {
			GameObject.Find ("Manager").GetComponent<GameManager>().onWinConditionSucces(this);
		}
	}

	public Vector2 getPosition() {
		return new Vector2(transform.position.x, transform.position.y);
	}
}

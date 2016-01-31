using UnityEngine;
using System.Collections;

public class Mob : MonoBehaviour {	
	public GameObject auraPrefab;
	private Aura aura;
	public Sprite fatty;
	public Sprite possessedFatty;
	public Sprite possessed;
	public Sprite[] affiliations;

    public string god = "neutral";
	public bool isFattyMcFatFuck = false;
    public bool isSuper = false;
    public bool isPossessed = false;
    public Player target;
    int points = 1;

	private Vector2 previousDirection;

	// Use this for initialization
	void Start () {
		if (target == null) {
			moveToPlayer();
		}
		
		aura = Instantiate(auraPrefab).GetComponent<Aura> ();
		aura.gameObject.transform.SetParent (this.transform);
		aura.transform.localPosition = Vector3.zero;

		setMobSizeAndSprite ();
	}

	private void setMobSizeAndSprite() {
		for (int i = 0; i<God.GODS.Length; i++) {
			if(God.GODS[i] == god) {
				GetComponent<SpriteRenderer>().sprite = affiliations[i];
			}
		}
		if (isFattyMcFatFuck) {
			if(isPossessed) {
				GetComponent<SpriteRenderer>().sprite = possessedFatty;
			} else {
				GetComponent<SpriteRenderer>().sprite = fatty;
			}
			gameObject.transform.localScale= new Vector3(1f, 1f, 1f);
			GetComponent<Moveable>().speed = 0.1f;
			if (isSuper) {
				gameObject.transform.localScale+= new Vector3(0.3f, 0.3f, 0.3f);
			}
			return;
		}
		if (isSuper) {
			gameObject.transform.localScale+= new Vector3(0.3f, 0.3f, 0.3f);
		}
		if(isPossessed) {
			GetComponent<SpriteRenderer>().sprite = possessed;
		}
	}

	public bool getHit (Player player) {
		if (target != player) {

			// Make the new player the target.
			target = player;

			// Set the aura to the current target. 
			this.aura.setAura (player.playerID - 1);

			// Modify point value
			if (isPossessed) {
				points--;
			} else {
				points++;
			}

			Base baseObject = GameObject.FindGameObjectWithTag(player.god).GetComponent<Base> ();
			GetComponent<Moveable> ().direction = baseObject.getPosition () - new Vector2 (transform.position.x, transform.position.y);

			if(isFattyMcFatFuck) {
				GetComponent<Moveable> ().speed += 0.01f;
			} else {
				GetComponent<Moveable> ().speed += 0.1f;
			}
			// Let the projectile know we hit a new player.
			return true;
		} else {
			// Must have hit the same player.
			return false;
		}
	}

    public int GetPoints(Player player)
    {
		if (isFattyMcFatFuck) {
			if(isPossessed) {
				if(isSuper) {
					return points - 30;
				} else {
					return points - 20;
				}
			} else if(isSuper) {
				if(player.god == god) {
					return points + 30;
				} else {
					return points + 20;
				}
			} else {
				if(player.god == god) {
					return points + 20;
				} else {
					return points + 15;
				}
			}
		}

		if (isSuper) {
			if(isPossessed) {
					return points - 10;
			}
			if(player.god == god) {
				return points + 10;
			} else {
				return points + 5;
			}
		}

		if (isPossessed) {
				return points -3;
		}

		if (player.god == god) {
			return points+1;
		} else {
			return points;
		}
    }

	public void fear()
	{
		previousDirection = GetComponent<Moveable> ().direction;
		GetComponent<Moveable>().direction = new Vector2(Random.Range(-180, 180) , Random.Range(-180, 180) );
	}

	public void cancelFear () {
		GetComponent<Moveable> ().direction = previousDirection;
	}

	public void moveToPlayer() {
		GetComponent<Moveable>().direction = new Vector2(0,0) - new Vector2(transform.position.x, transform.position.y);
	}
}

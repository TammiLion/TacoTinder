using UnityEngine;
using System.Collections;

public class Aura : MonoBehaviour
{
	public Sprite[] auraSprites;
	public float rotationSpeed = 1.0F;

	// Use this for initialization
	void Start ()
	{
	
	}

	public void setAura(int godIndex) {
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = this.auraSprites [godIndex];
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Rotate(0, 0, rotationSpeed);
	}
}


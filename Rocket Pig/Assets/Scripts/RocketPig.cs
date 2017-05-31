using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPig : MonoBehaviour
{
	public Rigidbody2D upwardForce;
	public GameObject pig;
	public bool flipped = false;
	public static bool die = false;
	// Use this for initialization
	void Start ()
	{
		pig = GameObject.Find ("Pig");
		upwardForce = pig.GetComponent<Rigidbody2D> ();


	}
	
	// Update is called once per frame
	void Update ()
	{
		//flyyyyy
		if (PlayGameScene.blastOffTriggered) {
			transform.Translate (Input.acceleration.x * 35, 0, 0);
			Invoke ("stopFlying", PlayGameScene.pointsCounter/2);

		}
		//resrict sides
		if (transform.position.x>700) {
			Vector3 pos = transform.position;
			pos.x = 700;
			transform.position = pos;
		}
		if (transform.position.x<100) {
			Vector3 pos = transform.position;
			pos.x = 100;
			transform.position = pos;
		}
	}

	void stopGravity(){
		upwardForce.gravityScale = 0;


	}

	 void stopFlying ()
	{
		die = true;
		//Debug.Log ("stop flying");
		scroll.speed = 0f;
		upwardForce.gravityScale = 75;
		if (transform.localScale.y > 0 && !flipped) {
			transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
			flipped = true;
		}
	
	
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.tag == "Enemy") {
			Debug.Log ("Collision!");
			die = true;
			stopFlying ();
		}
	
	}



}

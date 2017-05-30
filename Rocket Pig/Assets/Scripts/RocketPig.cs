using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPig : MonoBehaviour
{
	public Rigidbody2D upwardForce;
	public GameObject pig;
	public bool flipped = false;
	public bool die = false;
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
		if (PlayGameScene.blastOffTriggered && die==false) {
			//tilt
			transform.Translate (Input.acceleration.x * 25, 0, 0);
			// force upwards
			upwardForce.gravityScale = -25;
			Invoke ("stopGravity", 2f);
			upwardForce.gravityScale = 0;
		

			//no fuel
		} else if (PlayGameScene.blastOffTriggered && die == false) {
			//wait how long the fuel was then stop
			Invoke ("stopFlying",PlayGameScene.pointsCounter);
			die = true;
		}

	}

	 void stopFlying ()
	{
		//Debug.Log ("stop flying");
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

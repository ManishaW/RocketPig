using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPig : MonoBehaviour
{
	public Rigidbody2D upwardForce;
	public GameObject pig;
	public bool flipped = false;
	public static bool die = false;
	public bool invinsible = true;
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
			//Invoke ("stopFlying", PlayGameScene.pointsCounter/2);
			upwardForce.AddForce(new Vector2 (1,1));
			if (FuelScript.fuelout == true) {
				stopFlying ();
			}
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

		//give em some fuel :P
		if (PlayGameScene.starCounter % 10 == 0 && PlayGameScene.starCounter!=0) {
			PlayGameScene.fuelCounter += 10;
		}
	}

	void stopGravity(){
		upwardForce.gravityScale = 0;


	}


	 void stopFlying ()
	{
		die = true;
		Invoke ("destroyPig", 3);
		//Debug.Log ("stop flying");
		ScrollSky.speed = 0f;
		upwardForce.gravityScale = 75;
		if (transform.localScale.y > 0 && !flipped) {
			transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
			flipped = true;
		}
	
	
	}

	void OnCollisionEnter2D (Collision2D col)
	{

		if (col.gameObject.name == "COMET(Clone)" && invinsible==false) {
			die = true;
			stopFlying ();
		}

	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "star(Clone)") {
			Destroy (col.gameObject);
			PlayGameScene.starCounter += 1;
			MainMenuSceneScript.starCaught.Play ();

		}
		if (col.gameObject.name == "powerup(Clone)") {
			Destroy (col.gameObject);
			//be invincible, maybe new image
			//probs a boolean
			Destroy (col.gameObject);
			invinsible = true;
			upwardForce.isKinematic = true;
			this.GetComponent<Collider2D> ().enabled = false;
			Invoke ("doneInvinsible", 3);

		}

	}
	void destroyPig(){
		Destroy (pig);
	}
	void doneInvinsible(){
		invinsible = false;
		upwardForce.isKinematic = false;;
		this.GetComponent<Collider2D> ().enabled = true;

	}


}

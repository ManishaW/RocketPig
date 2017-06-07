using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketPig : MonoBehaviour
{
	public Rigidbody2D upwardForce;
	public GameObject pig;
	public bool flipped = false;
	public static bool die = false;
	public static bool invincible = false;
	public Sprite invinciblePig;
	public Sprite normalPig;

	public Text starsFinal;
	public Text fuelFinal;
	public static Text totalCounter;


	// Use this for initialization
	void Start ()
	{
		pig = GameObject.Find ("Pig");
		upwardForce = pig.GetComponent<Rigidbody2D> ();
		die = false;
		starsFinal = GameObject.Find ("starsScoreFinal").GetComponent<Text> ();
		fuelFinal = GameObject.Find ("fuelScoreFinal").GetComponent<Text> ();
		totalCounter = GameObject.Find ("totalScoreFinal").GetComponent<Text> ();
		normalPig=pig.GetComponent<Image> ().sprite;
		FuelScript.fuelout = false;

	}
	
	// Update is called once per frame
	void Update ()
	{
		//make pig fly when blastOff was triggered (in PlaySceneScene)
		if (PlayGameScene.blastOffTriggered) {
			//tilt 
			transform.Translate (Input.acceleration.x * 35, 0, 0);

			//if the fuel is out, stop flying
			if (FuelScript.fuelout == true) {
				stopFlying ();
			}
		}

		//resrict sides, do not let the pig move outside the screen
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


	void stopFlying ()
	{
		die = true;
		Invoke ("destroyPig", 3);
		//stop the sky from scrolling, let the pig fall
		ScrollSky.speed = 0f;
		upwardForce.gravityScale = 75;
		if (transform.localScale.y > 0 && !flipped) {
			transform.localScale = new Vector3 (transform.localScale.x, transform.localScale.y * -1, transform.localScale.z);
			flipped = true;
		}

		//final scores on gameover screen
		starsFinal.text = PlayGameScene.starCounter.ToString ("00");
		fuelFinal.text = PlayGameScene.fuelCounter.ToString ("00");
		totalCounter.text = "= " + (PlayGameScene.fuelCounter + PlayGameScene.starCounter).ToString ("00") ;
			
	}

	//pig physics collision with another object
	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.gameObject.name == "COMET(Clone)" && invincible==false) {
			die = true;
			stopFlying ();
		}

	}

	//non-physics collision with another object
	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.name == "star(Clone)") {
			//destory upon catching star and increment star counter, play sound
			Destroy (col.gameObject);
			PlayGameScene.starCounter += 1;
			MainMenuOptions.starCaught.Play ();

		}
		if (col.gameObject.name == "powerup(Clone)") {
			//start invinsible, destroy the powerup object
			Destroy (col.gameObject);
			invincible = true;
			//turn the collider box into a trigger
			pig.GetComponent<Collider2D> ().isTrigger = true;
			//change the sprite of the pig to the bubble protected
			pig.GetComponent<Image> ().sprite = pig.GetComponent<SpriteRenderer> ().sprite;
			Invoke ("doneInvincible", 5);

		}

	}

	void destroyPig(){
		//destroy pig object when it dies
		Destroy (pig);
	}

	void doneInvincible(){
		//finish invincible
		invincible = false;
		//change the sprite of the pig back to normal
		pig.GetComponent<Image> ().sprite = normalPig;
		// turn the colliber box back to a normal collider
		pig.GetComponent<Collider2D> ().isTrigger = false;

	}


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPig : MonoBehaviour {
	public Rigidbody2D upwardForce;
	public GameObject pig;
	public bool flipped = false;
	// Use this for initialization
	void Start () {
		pig = GameObject.Find ("Pig");
		upwardForce= pig.GetComponent<Rigidbody2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (PlayGameScene.blastOffTrigger) {
			transform.Translate(Input.acceleration.x*25, 0, 0);
			upwardForce.gravityScale = -25;
			Invoke ("stopFlying", PlayGameScene.pointsCounter);
		}

	}
	public void stopFlying(){
		Debug.Log ("stop flying");
		Debug.Log (transform.localScale.y);
		upwardForce.gravityScale = 75;

		if (transform.localScale.y > 0 && !flipped) {
			transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y *-1, transform.localScale.z);
			flipped = true;
			Debug.Log ("flip");
		}
	
	}

}

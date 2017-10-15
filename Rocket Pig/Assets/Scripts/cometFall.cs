using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CometFall : MonoBehaviour {
	public GameObject comet;
	public GameObject newComet;

	void Start(){
		float randoTime = Random.Range (0.7f, 2);
		InvokeRepeating ("makeComet", 7f, randoTime);

	}
	void makeComet(){
		if (RocketPig.die == false && PlayGameScene.fuelCounter>0 && PlayGameScene.blastOffTriggered) {
			Debug.Log ("Create comet");
			Vector3 position = new Vector3 (Random.Range (-350, 350), 800, 30);
			comet.GetComponent<Rigidbody2D> ().gravityScale = Random.Range (10, 20);
			comet.transform.localScale= new Vector3 (1,1,0);
			float scale = Random.Range (-0.5f,0.5f);
			comet.transform.localScale += new Vector3 (scale, scale, 0);
		
			newComet = Instantiate (comet, position, Quaternion.identity) as GameObject;
			newComet.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
		}
	}

	void Update(){

	}


}

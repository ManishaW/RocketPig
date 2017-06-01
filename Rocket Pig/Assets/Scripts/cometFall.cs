using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometFall : MonoBehaviour {
	public GameObject comet;
	public GameObject newComet;

	void Start(){
		float randoTime = Random.Range (1.5f, 3);
		InvokeRepeating ("makeComet", 7f, randoTime);

	}
	void makeComet(){
		if (RocketPig.die == false && PlayGameScene.fuelCounter>0) {
			
			Vector3 position = new Vector3 (Random.Range (-350, 350), 700, 0);
			comet.GetComponent<Rigidbody2D> ().gravityScale = Random.Range (4, 15);
			comet.transform.localScale= new Vector3 (1,1,0);
			float scale = Random.Range (-0.5f, 0.5f);
			comet.transform.localScale += new Vector3 (scale, scale, 0);

			newComet = Instantiate (comet, position, Quaternion.identity) as GameObject;
			newComet.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
		}
	}

	void Update(){

	}


}

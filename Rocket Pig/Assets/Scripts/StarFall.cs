using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFall : MonoBehaviour {
	public GameObject star;
	public GameObject newStar;
	// Use this for initialization
	void Start () {
		float randoTime = Random.Range (1f, 1.8f);
		InvokeRepeating ("makeStar", 7f, randoTime);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void makeStar(){
		if (RocketPig.die == false && PlayGameScene.fuelCounter>0 && PlayGameScene.blastOffTriggered) {
			Vector3 position = new Vector3 (Random.Range (-350, 350), 800, 0);
			newStar = Instantiate (star, position, Quaternion.identity) as GameObject;
			newStar.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
		}
	}
}

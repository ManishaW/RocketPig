using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFall : MonoBehaviour {
	public GameObject star;
	public GameObject newStar;
	// Use this for initialization
	void Start () {
		float randoTime = Random.Range (1, 3);
		InvokeRepeating ("makeStar", 7f, randoTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void makeStar(){
		if (RocketPig.die == false && PlayGameScene.fuelCounter>0) {

			Vector3 position = new Vector3 (Random.Range (-350, 350), 700, 0);
			newStar = Instantiate (star, position, Quaternion.identity) as GameObject;
			newStar.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
		}
	}
}

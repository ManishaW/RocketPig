using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//in the future, there will be an array of powerup. Randomize and drop one

public class PowerUpFall : MonoBehaviour {
	public GameObject powerUp;
	public GameObject newPowerUp;

	// Use this for initialization
	void Start () {
		float randoTime = Random.Range(15,30);
		InvokeRepeating ("makePowerUp", 15f, randoTime);

	}

	// Update is called once per frame
	void Update () {

	}

	void makePowerUp(){
		if (RocketPig.die == false && PlayGameScene.fuelCounter>0) {
			Vector3 position = new Vector3 (Random.Range (-400, 400), 700, 0);		
			newPowerUp = Instantiate (powerUp, position, Quaternion.identity) as GameObject;
			newPowerUp.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarFall : MonoBehaviour {
	public GameObject star;
	public GameObject newStar;
	public SpriteRenderer sprite_renderer;
	// Use this for initialization
	void Start () {
		float randoTime = Random.Range (1f, 2f);
		InvokeRepeating ("makeStar", 7f, randoTime);
		sprite_renderer = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void makeStar(){
		if (RocketPig.die == false && PlayGameScene.fuelCounter>0 && PlayGameScene.blastOffTriggered) {
			Vector3 position = new Vector3 (Random.Range (-350, 350), 700, 0);
			newStar = Instantiate (star, position, Quaternion.identity) as GameObject;
			sprite_renderer.sortingOrder = 20;
			newStar.transform.SetParent (GameObject.FindGameObjectWithTag ("Canvas").transform, false);
		}
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scroll : MonoBehaviour {
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayGameScene.blastOffTriggered == true) {
			
			Vector2 bgPos = new Vector2 (0, Time.time * speed);
			GetComponent<Renderer> ().material.mainTextureOffset = bgPos;
		}
	}

}

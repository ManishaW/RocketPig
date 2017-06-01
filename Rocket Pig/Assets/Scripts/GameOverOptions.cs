using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverOptions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void restartOnClick ()
	{
		Application.LoadLevel ("Play page");
		RocketPig.die = false;
	}

	public void backToMainMenuOnClick ()
	{
		Application.LoadLevel ("Main menu");
		RocketPig.die = false;

	}
}

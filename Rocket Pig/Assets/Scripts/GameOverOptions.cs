using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOptions : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void restartOnClick ()
	{
		SceneManager.LoadScene("Play page");
		RocketPig.die = false;
	}



	public void backToMainMenuOnClick ()
	{
		SceneManager.LoadScene("Main menu");
		RocketPig.die = false;

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour {
	public Canvas pauseCanvas;
	public Canvas defaultCanvas;
	public GameObject pig;

	// Use this for initialization
	void Start () {
		pig = GameObject.Find ("Pig");
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void pauseClick ()
	{
		Debug.Log ("pause button clicked");
		pauseCanvas.gameObject.SetActive(true);
		defaultCanvas.GetComponent<CanvasGroup> ().interactable = false;
		Time.timeScale = 0;
		pig.SetActive (false);


		

	}

	public void restartOnClick ()
	{
		SceneManager.LoadScene("Play page");
		RocketPig.die = false;
		Time.timeScale = 1;
	}

	public void resumeClick ()
	{
		Debug.Log ("resume from pause menu button clicked");
		pauseCanvas.gameObject.SetActive(false);
		defaultCanvas.GetComponent<CanvasGroup> ().interactable = true;
		Time.timeScale = 1;
		pig.SetActive (true);
	}

}

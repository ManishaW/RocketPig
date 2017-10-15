using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour {
	public Canvas pauseCanvas;
	public GameObject pig;
	public Canvas defaultCanvas;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void pauseClick ()
	{
		Debug.Log ("pause button clicked");
		//StartCoroutine (playSound ());
		pauseCanvas.gameObject.SetActive(true);
		defaultCanvas.GetComponent<CanvasGroup> ().interactable = false;
		Time.timeScale = 0;
		

	}


	public void resumeClick ()
	{
		Debug.Log ("resume from pause menu button clicked");
		//StartCoroutine (playSound ());
		pauseCanvas.gameObject.SetActive(false);
		defaultCanvas.GetComponent<CanvasGroup> ().interactable = true;
		Time.timeScale = 1;
	}

}

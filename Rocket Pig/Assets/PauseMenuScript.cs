using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour {
	public Canvas pauseCanvas;

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

	}



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloaderScene : MonoBehaviour
{
	private CanvasGroup fadeGroup;
	private float loadTime;
	private float minimumLogoTime = 2.0f;


	// Use this for initialization
	void Start ()
	{
		fadeGroup = FindObjectOfType<CanvasGroup> ();
		fadeGroup.alpha = 1;
		//preload game!

		//if loadtime is longgg
		if (Time.time < minimumLogoTime)
			loadTime = minimumLogoTime;
		else
			loadTime = Time.time;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//fade in 
		if (Time.time < minimumLogoTime) {
			fadeGroup.alpha = 1 - Time.time;
		}
		if (Time.time > minimumLogoTime && loadTime != 0) {
			fadeGroup.alpha = Time.time - minimumLogoTime;
			if (fadeGroup.alpha >= 1) {
				SceneManager.LoadScene ("Main Menu");;
			}
		}
			

	}
}

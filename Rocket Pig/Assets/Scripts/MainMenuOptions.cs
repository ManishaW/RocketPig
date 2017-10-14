﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuOptions : MonoBehaviour
{
	public  AudioSource[] allAudio;

	public static AudioSource BGM;
	public AudioSource soundClick;
	public AudioSource playGameMusic;
	public static AudioSource starCaught;
	public static AudioSource fuelWarning;

	public static bool muteAllSounds;

	void Start ()
	{
		allAudio = GetComponents<AudioSource> ();
		BGM = allAudio [0];
		//Debug.Log (allAudio.Length);
		soundClick = allAudio [1];
		playGameMusic = allAudio [2];
		starCaught = allAudio [3];
		fuelWarning = allAudio [4];
		muteAllSounds = false;

		if (SceneManager.GetActiveScene().name==("Main menu")){
			BGM.Play ();
		}
		if (SceneManager.GetActiveScene().name==("Play page")){
			BGM.Stop ();
			playGameMusic.Play ();
		}
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}


	
	// Update is called once per frame
	void Update ()
	{
		

	}

	public void playOnClick ()
	{
		Debug.Log ("play button clicked, go to play page");
		StartCoroutine (playSound ());

		SceneManager.LoadScene("Play page");
		

	}

	IEnumerator playSound ()
	{
		if (muteAllSounds == false) {
			Debug.Log ("play click sound!");
			soundClick.Play ();
			yield return new WaitForSeconds (0.3f);
		}
	}

	public void highScoreOnClick ()
	{
		Debug.Log ("high score button clicked");
		StartCoroutine (playSound ());
	}

	public void shopOnClick ()
	{
		Debug.Log ("shop button clicked");
		StartCoroutine (playSound ());
	}

	public void settingsOnClick ()
	{
		StartCoroutine (playSound ());
	}

	public void helpOnClick ()
	{
		Debug.Log ("help button clicked");
		StartCoroutine (playSound ());
	}

	public void soundOnClick ()
	{
		
		StartCoroutine (playSound ());
		if (BGM.mute == false) {
			BGM.mute = true;
			muteAllSounds = true;
			Debug.Log ("unmute");
		} else {
			BGM.mute = false;
			muteAllSounds = false;
			Debug.Log ("mute");
		}
	}
}


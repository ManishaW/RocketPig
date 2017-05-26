﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenuScene : MonoBehaviour
{
	public  AudioSource[] allAudio;
	public static AudioSource BGM;
	public AudioSource soundClick;
	public static bool muteAllSounds;

	void Start ()
	{
		Debug.Log ("play music");
		allAudio = GetComponents<AudioSource> ();
		BGM = allAudio [0];
		soundClick = allAudio [1];
		muteAllSounds = false;
		BGM.Play ();
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void playOnClick ()
	{
		Debug.Log ("play button clicked, go to play page");
		StartCoroutine (playSound ());
		Application.LoadLevel ("Play page");

	}

	IEnumerator playSound ()
	{
		if (muteAllSounds==false) {
			Debug.Log ("play click sound!");
			soundClick.Play ();
			yield return new WaitForSeconds (0.3f);
		}

	} 

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

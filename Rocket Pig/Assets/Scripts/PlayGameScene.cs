﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGameScene : MonoBehaviour
{
	//declare variables
	public static int starCounter;
	public static int fuelCounter;
	public Button leftFinger;
	public Button rightFinger;
	public Text countdownText;
	public float CountdownTimer;
	public Text starCounterScore;
	public Text fuelCounterScore;
	public bool startCountdownTrigger;
	public static bool blastOffTriggered;
	public static float startTime;
	public static bool tenStarFuelUpTrigger;
	int tempStars;
	float countdownstarttime;
	float restseconds;
	
	void Start ()
	{
		//set objects
		leftFinger = GameObject.Find ("leftFinger").GetComponent<Button> ();
		rightFinger = GameObject.Find ("rightFinger").GetComponent<Button> ();
		countdownText = GameObject.Find ("Countdown").GetComponent<Text> ();
		fuelCounterScore = GameObject.Find ("fuelCount").GetComponent<Text> ();
		starCounterScore = GameObject.Find ("starsScore").GetComponent<Text> ();
		tempStars = -1;
		//to be reset each time game is played
		blastOffTriggered = false;
		starCounter=0;
		fuelCounter=0;
		CountdownTimer = 3; //starting integer for timer (easily changeable)
		startCountdownTrigger = false;
		tenStarFuelUpTrigger = false;


	}
	 
	void timerMode()
	{
		float guitime = Time.time - countdownstarttime;
		Debug.Log (Time.time);
		Debug.Log (countdownstarttime);
		restseconds = CountdownTimer - guitime;
		countdownText.text = Mathf.RoundToInt(restseconds).ToString();
	}
	// Update is called once per frame
	void Update ()
	{
		//update the scores 
		starCounterScore.text = (starCounter).ToString ("00");
		fuelCounterScore.text = (fuelCounter).ToString ("00");
		//do the 3 second countdown timer
		Debug.Log("countdown: " + CountdownTimer);
		Debug.Log ("time: " + Time.deltaTime);
		if (CountdownTimer>0 && startCountdownTrigger==true) {
			CountdownTimer = CountdownTimer - Time.deltaTime;
			string displayTime = CountdownTimer.ToString ("0");
			countdownText.text = displayTime;
		}


		//countdown is 0 and pig is not flying yet
		if (countdownText.text.Equals ("0") && blastOffTriggered == false) {
			countdownText.text = "Blast off!";
			ScrollSky.speed = 0.8f;
			leftFinger.gameObject.SetActive (false);
			rightFinger.gameObject.SetActive (false);
			countdownText.fontSize = 175;

			//start flying
			Invoke ("blastOff", 1.5f);

		}

			

		
	}

	//left tap
	public void clickLeftFinger ()
	{
		if (leftFinger.interactable == true) {
			fuelCounter += 1;
			leftFinger.interactable = false;
			rightFinger.interactable = true;
			if (startCountdownTrigger == false) {
				startCountdownTrigger = true;
			}
		}
	}

	//right tap
	public void clickRightFinger ()
	{
		if (rightFinger.interactable == true) {
			fuelCounter += 1;
			rightFinger.interactable = false;
			leftFinger.interactable = true;
			if (startCountdownTrigger == false) {
				startCountdownTrigger = true;

			}
		}
	}

	//start flying
	private void blastOff (){
		//get rid off counddown
		if (blastOffTriggered == false) {
			//Debug.Log ("blastOff!");
			countdownText.gameObject.SetActive (false);
			blastOffTriggered = true;
			startTime = Time.time;

		}
}
}


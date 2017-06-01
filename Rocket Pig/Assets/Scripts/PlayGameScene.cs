using System.Collections;
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
	public float CountdownFrom;
	public float CountdownTimer;
	public Text starCounterScore;
	public Text fuelCounterScore;
	public static bool blastOffTriggered=false;



	void Start ()
	{
		
		//set objects
		CountdownTimer = CountdownFrom - Time.timeSinceLevelLoad;
		leftFinger = GameObject.Find ("leftFinger").GetComponent<Button> ();
		leftFinger.enabled = false;
		rightFinger = GameObject.Find ("rightFinger").GetComponent<Button> ();
		rightFinger.enabled = false;
		countdownText = GameObject.Find ("Countdown").GetComponent<Text> ();
		fuelCounterScore = GameObject.Find ("fuelScore").GetComponent<Text> ();
		starCounterScore = GameObject.Find ("starsScore").GetComponent<Text> ();

	}

	// Update is called once per frame
	void Update ()
	{
		starCounterScore.text = (starCounter).ToString ("00");
		fuelCounterScore.text = (fuelCounter).ToString ("00");

		//do the 5 second countdown timer
		if (CountdownTimer >= -7f) {
			CountdownTimer = CountdownFrom - Time.timeSinceLevelLoad;
			string displayTime = (7 + (CountdownTimer * 1)).ToString ("0");
			if ((7 + (CountdownTimer * 1)) <= 5) {
				countdownText.text = displayTime;
				rightFinger.enabled = true;
				leftFinger.enabled = true;
			}
		}
		if (countdownText.text.Equals ("0") && blastOffTriggered==false) {
			countdownText.text = "Blast off!";
			ScrollSky.speed = 0.4f;
			leftFinger.gameObject.SetActive (false);
			rightFinger.gameObject.SetActive (false);
			countdownText.fontSize = 175;

			Invoke ("blastOff", 1.5f);
			//Handheld.Vibrate(); //not sure efficiency
			}

			
		
	}

	//left tap
	public void clickLeftFinger ()
	{
		if (leftFinger.interactable == true) {
			fuelCounter += 1;
			leftFinger.interactable = false;
			rightFinger.interactable = true;
		}


	}

	//right tap
	public void clickRightFinger ()
	{
		if (rightFinger.interactable == true) {
			fuelCounter += 1;
			rightFinger.interactable = false;
			leftFinger.interactable = true;
		}
	}

	private void blastOff ()
	{
		//get rid off counddown
		countdownText.gameObject.SetActive (false);
		blastOffTriggered = true;
	}
}

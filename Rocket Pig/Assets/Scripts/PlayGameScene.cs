using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGameScene : MonoBehaviour
{
	//declare variables
	public static int pointsCounter;
	public Button leftFinger;
	public Button rightFinger;
	public Text countdownText;
	public float CountdownFrom;
	public float CountdownTimer;
	public Text score;
	public static bool blastOffTriggered=false;

	// Use this for initialization
	void Awake(){
		DontDestroyOnLoad (MainMenuScene.BGM);
	}

	void Start ()
	{
		//set objects
		CountdownTimer = CountdownFrom - Time.timeSinceLevelLoad;
		leftFinger = GameObject.Find ("leftFinger").GetComponent<Button> ();
		rightFinger = GameObject.Find ("rightFinger").GetComponent<Button> ();
		countdownText = GameObject.Find ("Countdown").GetComponent<Text> ();
		score = GameObject.Find ("score").GetComponent<Text> ();

	}

	// Update is called once per frame
	void Update ()
	{
		score.text = pointsCounter.ToString ("00");
		//do the 5 second countdown timer
		if (CountdownTimer >= -5f) {
			CountdownTimer = CountdownFrom - Time.timeSinceLevelLoad;
			string displayTime = (5 + (CountdownTimer * 1)).ToString ("0");
			countdownText.text = displayTime;
		}
			
		if (countdownText.text.Equals ("0") && blastOffTriggered==false) {
			countdownText.text = "Blast off!";
			scroll.speed = 0.35f;
			Debug.Log ("blasttttt");
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
			pointsCounter += 1;
			leftFinger.interactable = false;
			rightFinger.interactable = true;
		}


	}

	//right tap
	public void clickRightFinger ()
	{
		if (rightFinger.interactable == true) {
			pointsCounter += 1;
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

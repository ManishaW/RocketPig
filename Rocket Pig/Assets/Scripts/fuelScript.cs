using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelScript : MonoBehaviour {
	[SerializeField]
	private float fillAmount;
	[SerializeField]
	private Image content;
	public static bool fuelout;
	public float fuelstart;
	public float fuelPresent;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		handleBar ();
	}
	void handleBar(){
		//fuel up
		if (PlayGameScene.blastOffTriggered == false) {
			float amount = ((float)PlayGameScene.fuelCounter / 100);
			content.fillAmount = amount;
			fuelstart = (float)PlayGameScene.fuelCounter;
		} 
		//fuel loss over time
		if (PlayGameScene.blastOffTriggered == true && fuelout==false && RocketPig.die==false) {

			fuelPresent = fuelstart/100 - ((Time.time-PlayGameScene.startTime)/100) ;
//			if (PlayGameScene.tenStarFuelUpTrigger == true) {
//				Debug.Log ("FUEL UP");
//				fuelPresent =+ 0.25f;
//				PlayGameScene.tenStarFuelUpTrigger = false;
//			} 
//			Debug.Log ("this scene start time: " + (PlayGameScene.startTime).ToString());
//			Debug.Log ("delta time: " + (Time.time- (float)PlayGameScene.startTime).ToString());
			content.fillAmount = fuelPresent;
			Debug.Log ("fuel running out " + fuelPresent );

			if (fuelPresent <= 0.25f) {
				//call animation
				//MainMenuOptions.fuelWarning.Play();
				Debug.Log ("play warning");
			}
			//fuel is out!
			if (fuelPresent <= 0) {
				//Debug.Log ("fuel out! " + fuelPresent );				
				fuelout = true;

			}

					
		}
	
	}
}

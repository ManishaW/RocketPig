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
		} 
		//fuel loss over time
		if (PlayGameScene.blastOffTriggered == true && fuelout==false && RocketPig.die==false) {
			fuelstart=((float)PlayGameScene.fuelCounter);
			fuelPresent = fuelstart/100 - ((Time.time-PlayGameScene.startTime)/100);
			Debug.Log ("this scene start time: " + (PlayGameScene.startTime).ToString());
			Debug.Log ("delta time: " + (Time.time- (float)PlayGameScene.startTime).ToString());
			content.fillAmount = fuelPresent;
			Debug.Log ("fuel running out " + fuelPresent );
			//still needs work, Warning that fuel is running out
			if (fuelPresent <= 0.25) {
				//call animation
				MainMenuOptions.fuelWarning.Play();

			}
			//fuel is out!
			if (fuelPresent <= 0) {
				Debug.Log ("fuel out! " + fuelPresent );				
				fuelout = true;

			}
					
		}
	
	}
}

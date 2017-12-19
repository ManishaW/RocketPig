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
	public GameObject myAnimator;
	public Animation clip;
	float amount;

	// Use this for initialization
	void Start () {
		clip = myAnimator.GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		handleBar ();
	}
	void handleBar(){
		//fuel up
		if (PlayGameScene.blastOffTriggered == false) {
			amount = ((float)PlayGameScene.fuelCounter / 50);
			content.fillAmount = amount;
			fuelstart = (float)PlayGameScene.fuelCounter;
		} 
		//fuel loss over time
		if (PlayGameScene.blastOffTriggered == true && fuelout==false && RocketPig.die==false) {

			fuelPresent = fuelstart/50 - ((Time.time-PlayGameScene.startTime)/50) ;

			content.fillAmount = fuelPresent;
			Debug.Log ("fuel running out " + fuelPresent );

			if (fuelPresent <= 0.2f) {
//				//call animation
				MainMenuOptions.fuelWarning.Play();
				Debug.Log ("play warning"+clip.name);
				clip.Play ();
			}
			//fuel is out!
			if (fuelPresent <= 0) {
				//Debug.Log ("fuel out! " + fuelPresent );				
				fuelout = true;

			}

					
		}
	
	}
}

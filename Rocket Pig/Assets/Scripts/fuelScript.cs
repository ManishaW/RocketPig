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
	public GameObject myAnimator;
	public Animation clip;

	// Use this for initialization
	void Start () {
		clip = myAnimator.GetComponentInChildren<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		handleBar ();
	}
	void handleBar(){
		if (PlayGameScene.blastOffTriggered == false) {
			float amount = ((float)PlayGameScene.fuelCounter / 100);
			content.fillAmount = amount;
		} 
		if (PlayGameScene.blastOffTriggered == true && fuelout==false && RocketPig.die==false) {
			float fuel=((float)PlayGameScene.fuelCounter);
		
			fuel = fuel - ((Time.time-0.4f)/10)-0.5f;
			//Debug.Log ("fuel: " + fuel);
			content.fillAmount = fuel/100;
			if (fuel <= 1) {
				//call animation
				MainMenuSceneScript.fuelWarning.Play();
				clip.Play();

			}
			if (fuel <= 0) {
				fuelout = true;

			}
					
		}
	
	}
}

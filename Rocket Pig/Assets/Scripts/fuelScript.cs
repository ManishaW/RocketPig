using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fuelScript : MonoBehaviour {
	[SerializeField]
	private float fillAmount;
	[SerializeField]
	private Image content;
	public bool fuelout;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		handleBar ();
	}
	void handleBar(){
		if (PlayGameScene.blastOffTriggered == false) {
			float amount = ((float)PlayGameScene.pointsCounter / 100);
			content.fillAmount = amount;
		} 
		if (PlayGameScene.blastOffTriggered == true && fuelout==false) {
			float fuel=((float)PlayGameScene.pointsCounter)/100;
		
			fuel = fuel - ((Time.time/50)-0.04f);
			content.fillAmount = fuel;
			Debug.Log ("fuel: " + fuel + "time " + ((Time.time/100)-0.05f)+ "points"+(float)PlayGameScene.pointsCounter/100);
			if (fuel <= 0) {
				fuelout = true;
			}
					
		}
	
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAnimations : MonoBehaviour {
	public GameObject myAnimator;
	public Animation clip;
	public bool playonce=false;

	// Use this for initialization
	void Start () {
		clip = myAnimator.GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		//animate if game over
		if (RocketPig.die==true && playonce==false){
			Invoke ("gameOverAnimate", 0f);
		}
		
	}
	
	void gameOverAnimate(){
		clip.Play ();
		Debug.Log (myAnimator.name+ " called GameOver"+ RocketPig.die +" "+ playonce + " fuel status: "+ FuelScript.fuelout);
		playonce = true;


	}
}

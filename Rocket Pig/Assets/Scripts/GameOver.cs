using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
	public GameObject myAnimator;
	public Animation clip;
	public bool playonce=false;
	// Use this for initialization
	void Start () {
		//clip = myAnimator.GetClip ("animateGameOver");
		clip = myAnimator.GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (RocketPig.die==true && playonce==false){
			Invoke ("gameOverAnimate", 0f);
		}
		
	}

	void gameOverAnimate(){
		if (RocketPig.die==true && playonce==false){
		clip.Play ();
		}
		Debug.Log (myAnimator.name+ " called GameOver"+ RocketPig.die +" "+ playonce);
		playonce = true;

	}
}

using UnityEngine;
using System.Collections;

public class AnimationManager : MonoBehaviour 
{
	public GameObject youranimatableObject;
	private Animator[] yourAnimator;

	void Start()
	{      
		yourAnimator = youranimatableObject.GetComponents<Animator>();
	}

//	void moveOutCornFence(){
//		yourAnimator[0].animation.play("OpenAnime");


//	}


	void Update()
	{

	}


}
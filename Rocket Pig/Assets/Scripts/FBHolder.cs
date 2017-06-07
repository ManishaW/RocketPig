using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Facebook.Unity;


public class FBHolder : MonoBehaviour {
	public GameObject fbLoggedIn, fbnotloggedIn, fbUserName;
	
	public void Awake()
	{
		//FB.Init (SetInit, OnHideUnity);
		if (!FB.IsInitialized) {
			FB.Init (SetInit, onHideUnity);
		} else {
			Debug.Log ("Facebook already init");
		}
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoginWithPublishPermission()
	{
		var perms = new List<string>() { "publish_actions" };
		FB.LogInWithPublishPermissions(perms, AuthCallback);
	}

	public void SetInit(){
		Debug.Log ("fbinit works!");
		if (FB.IsLoggedIn) {
			Debug.Log ("FB is logged in");
		} else {
			Debug.Log ("FB is not logged in");
		}
	}

	public void onHideUnity(bool isGameShown){
		if (!isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}
	//dont need this
	IEnumerator FBLogin()
	{
		List <string> permissions = new List<string> ();
		permissions.Add ("public_profile");
		FB.LogInWithReadPermissions (permissions, AuthCallback);
		yield return new WaitForSeconds(2f);
	}
	//dont need
	void AuthCallback(IResult res){
		if (FB.IsLoggedIn) {
			Debug.Log ("FB is logg in works");
		} else {
			Debug.Log ("FB is log in doesnt work");
		}
	}

	//dont need
	public void fbMenu(bool isLoggedIn){
		fbLoggedIn.SetActive (true);
		fbnotloggedIn.SetActive (false);
		
	}

	public void shareWithFriends(){
		
		FB.FeedShare (
			string.Empty, 
			new System.Uri("https://www.facebook.com/TheRocketPig"), 
			"Rocket Pig is so much fun! Check out my score: " + RocketPig.totalCounter, //linkName
			"Rocket Pig", //linkCaption
			"The best game ever", //linkDescription
			null, //picture
			string.Empty, //mediaSource
			shareCallBack //callback
		);

	}



	void shareCallBack(IResult res){
		if (res.Cancelled) {
			Debug.Log ("not Shared");
		} else if (!string.IsNullOrEmpty (res.Error)) {
			Debug.Log ("error");

		} else {
			Debug.Log ("FB share works");
		}
	}



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cometFall : MonoBehaviour {
	public GameObject comet;
	GameObject clone;
	// Use this for initialization
	void Start () {
		clone = Instantiate (comet, transform.position, Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("heya");
		Instantiate (comet, transform.position, transform.rotation);
	}
}

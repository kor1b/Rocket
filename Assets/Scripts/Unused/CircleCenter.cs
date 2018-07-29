using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleCenter : MonoBehaviour {

	CircleRotation circleRotation;

	void Start(){
		GameObject circleRotationObject = GameObject.FindWithTag ("CircleHazard");
		if (circleRotationObject != null)
			circleRotation = circleRotationObject.GetComponent<CircleRotation> ();

	}
	void OnTriggerEnter2D (Collider2D player){
	
		if (player.gameObject.CompareTag ("Player"))
			circleRotation.StartRotation ();
	}

}

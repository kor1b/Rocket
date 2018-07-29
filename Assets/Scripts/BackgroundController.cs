using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

	public GameObject[] gradients;

	public void ChangeBackground(){
	
		for (int i = 0; i < gradients.Length; i++) {
			gradients [i].SetActive (false);
		}
		gradients [Random.Range (0, gradients.Length)].SetActive (true);
	}
}

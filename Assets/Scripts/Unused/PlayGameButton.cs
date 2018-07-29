using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGameButton : MonoBehaviour {

	GameObject arrow;
	public ScreenFader screenFader;

	void Start(){

		arrow = GameObject.Find ("Arrow");

	}

	public void OnMouseUpAsButton(){
	
		StartCoroutine (Play());
	
	}

	IEnumerator Play(){
	
		arrow.GetComponent<Animator> ().enabled = true;

		screenFader.fadeState = ScreenFader.FadeState.In;

		yield return new WaitForSeconds (1);
		SceneManager.LoadScene ("Main");

	}
}

using UnityEngine;

public class MainMenuController : MonoBehaviour {

	public GameObject gameOver;
	public BackgroundController backgroundController;

	void Start(){

		backgroundController.ChangeBackground ();
	}

	void OnEnabled () {

		gameOver.SetActive (false);
	}
	}


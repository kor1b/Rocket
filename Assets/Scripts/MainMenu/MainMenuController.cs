using UnityEngine;

public class MainMenuController : MonoBehaviour {

	public GameObject gameOver;
	public BackgroundController backgroundController;

	void Start(){

		PlayerPrefs.SetString("FromGameOver", "False");//чтобы не было багов с тем, что не прогружается главное меню
		backgroundController.ChangeBackground ();
	}

	void OnEnabled () {

		gameOver.SetActive (false);
	}
	}


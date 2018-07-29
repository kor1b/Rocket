using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	public GameObject shopBG;
	public GameObject mainMenu;
	public GameObject mainScene;
	public GameObject settings;
	public GameObject gameOver;

	public ScreenFader screenFader;

	public bool reloadPressed;

    public void OnMouseUpAsButton(){
		switch (gameObject.name) {

		case "PlayGame":
			StartCoroutine (Play ());
			break;

		case "GameOverShop":
			PlayerPrefs.SetString ("FromGameOver", "True");

			break;

		case "Back":

			shopBG.SetActive (false);
			settings.SetActive (false);

                if (PlayerPrefs.GetString ("FromGameOver") == "True") {
				gameOver.SetActive (true);
			} else
				mainMenu.SetActive (true);
			
			PlayerPrefs.SetString ("FromGameOver", "False");
			break;

		case "Reload":
			reloadPressed = true;
			screenFader.fadeState = ScreenFader.FadeState.In;
			PlayerPrefs.SetString ("ReloadKey", "Reload");
			SceneManager.LoadScene ("Main");
			break;

		case "Home":
			PlayerPrefs.SetString ("ReloadKey", "Zero");
			gameOver.SetActive (false);
			mainScene.SetActive (false);
			mainMenu.SetActive (true);
            System.GC.Collect();//запрашиваем GC
			break;

		case "Settings":
			settings.SetActive (true);
			mainMenu.SetActive (false);
			break;
		}
	}


	IEnumerator Play(){

		yield return new WaitForSeconds (0.1f);
		PlayerPrefs.SetString ("ReloadKey", "Reload");
		SceneManager.LoadScene ("Main");

	}
}

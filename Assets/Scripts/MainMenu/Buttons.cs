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

	private void Update()
	{
		if (Application.platform == RuntimePlatform.Android)
		{
		if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
		{
			Debug.Log("lol");
			Back();
		}
		}
	}

	void Back()
	{
		shopBG.SetActive(false);
		settings.SetActive(false);

		if (PlayerPrefs.GetString("FromGameOver") == "True")
		{
			gameOver.SetActive(true);
		}
		else
			mainMenu.SetActive(true);

		PlayerPrefs.SetString("FromGameOver", "False");
	}

	public void OnMouseUpAsButton(){
		switch (gameObject.name) {

		case "PlayGame":
			StartCoroutine (Play ());
			break;

		case "GameOverShop":
			PlayerPrefs.SetString ("FromGameOver", "True");

			break;

		case "Back":
		    Back();
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
		}
	}


	IEnumerator Play(){

		yield return new WaitForSeconds (0.1f);
		PlayerPrefs.SetString ("ReloadKey", "Reload");
		SceneManager.LoadScene ("Main");

	}
}

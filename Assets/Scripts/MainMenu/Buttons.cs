using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour {

	public GameObject shopBG;
	public GameObject mainMenu;
	public GameObject mainScene;
	public GameObject settings;
	public GameObject gameOver;
	public GameObject gameOverGeneralMenu;

	public ScreenFader screenFader;
	
	public bool reloadPressed;

	private void Update()
	{
#if UNITY_ANDROID
			if (Input.GetKey(KeyCode.Escape))
			{
				Back();
			}	
#endif
	}
	void Back()
	{
		//если включена панель меню проигрыша, то возвращаемся в главное меню (кнопка Home)
		if (gameOverGeneralMenu.activeSelf && gameOver.activeSelf)
		{
			PlayerPrefs.SetString("ReloadKey", "Zero");
			gameOver.SetActive(false);
			mainScene.SetActive(false);
			mainMenu.SetActive(true);
			System.GC.Collect();//запрашиваем GC
		}

		//в ином случае - выходим из панели (кнопка Back)
		else
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
			Back();
			break;

		case "Stats":
				Debug.Log("Leaderboard");
			Social.ShowLeaderboardUI();
			break;
		}
	}


	IEnumerator Play(){

		yield return new WaitForSeconds (0.1f);
		PlayerPrefs.SetString ("ReloadKey", "Reload");
		SceneManager.LoadScene ("Main");

	}
}

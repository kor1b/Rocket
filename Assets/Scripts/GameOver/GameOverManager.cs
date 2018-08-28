using UnityEngine;

public class GameOverManager : MonoBehaviour {

	public Buttons buttons;

	Animator anim;

	public CoinsCount coinsCount;
	//public ADSController adsController;

	bool animShowed;//показывалась ли уже анимация появления gameover

	void Start() {

		animShowed = false;
		PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + coinsCount.coins);
        anim = GetComponent<Animator>();
    }
		
	public void GameOverMenuAppear() {
			if (animShowed == false) {//появление gameover
				anim.SetTrigger ("GameOver");
				animShowed = true;
			   // adsController.ShowInterstitial();
		}

		PlayerPrefs.SetString ("ReloadKey", "Zero");
			if (buttons.reloadPressed == true)
				PlayerPrefs.SetString ("ReloadKey", "Reload");
		}
	}


using UnityEngine;

public class GameController : MonoBehaviour {

	public PlayerController playerController;
	public BackgroundController backgroundController;
    public GameOverManager gameOverManager;
	AudioManager audioManager;
	public ADSController adsController;

	public GameObject player;
	public GameObject explosion;
	public GameObject trail;
	public GameObject teachingText;//текст обучения

	[HideInInspector]
	public bool gameHasEnded = false;

	SpriteRenderer playerSprite;

	void Start(){
		backgroundController.ChangeBackground ();
		playerSprite = player.GetComponent<SpriteRenderer> ();
		audioManager = FindObjectOfType<AudioManager>();

	}

	void Update(){
        if (Input.GetMouseButtonDown(0))//при тапе, выключается текст обучения
            teachingText.SetActive(false);
	}

	public void EndGame(){
		Debug.Log(PlayerPrefs.GetInt("no_adsBought"));
        if (gameHasEnded == false)
        {
            Instantiate(explosion, player.transform.position, Quaternion.identity);//создаем взрыв
		    if (audioManager.CheckEnabled("Explosion"))//еслт звуки не выключены
				audioManager.Play("Explosion");

            gameHasEnded = true;
        }
			playerController.enabled = false;

        teachingText.SetActive(false); ;//выключение обучаещего текста

		Destroy (trail);//уничтожаем след игрока
		playerSprite.color = Color.clear;//переводим игрока в режим невидимости


        gameOverManager.GameOverMenuAppear();//появление меню проигрыша

		if (PlayerPrefs.GetInt("no_adsBought") != 1)//если не куплен отказ от рекламы, то показываем межстраничный баннер
		adsController.ShowInterstitial();

			Destroy (player, 2f);//уничтожаем игрока

	}
}

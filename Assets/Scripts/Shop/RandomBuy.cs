using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomBuy : MonoBehaviour {

	public List<GameObject> closeArrows;//некупленные скины
	public GameObject[] allArrows;
	public Button back;
	public Image selectSprite;
	public Image previewArrowSprite;
    Image _previewArrowSpriteImage;

	public Text notEnoughCoinsText;//префаб "Недостаточно монет"
	public Button watchVideoBtn;
    RectTransform _watchVideoBtnRectTransform;

	public int removeNum;

	public int price;

	GameObject previousRandGO;
	GameObject randGO;

	Animator anim;

    WaitForSeconds timeBtwBlinking;//время между морганием

    public CoinsCount coinsCount;
    AudioManager audioManager;

	void CheckMoney(){
		//если достаточно денег, то запускаем анимацию
		if (PlayerPrefs.GetInt ("Coins") >= price)
			anim.enabled = true;
		//если НЕ достаточно денег, то выключаем анимацию
		else
			anim.enabled = false;

		coinsCount.ShowMoney();//отображаем количество денег
	}

	void OnEnable(){
		anim = GetComponent<Animator> ();
		CheckMoney ();
	}

	void Start () {

		audioManager = FindObjectOfType<AudioManager>();
		_previewArrowSpriteImage = previewArrowSprite.GetComponent<Image>();
		_watchVideoBtnRectTransform = watchVideoBtn.GetComponent<RectTransform>();
		CheckAllSkinsBought();

		for (int i = 1; i < allArrows.Length; i++) {
			if (PlayerPrefs.GetString(allArrows [i].name) != "Open")
				closeArrows.Add (allArrows[i]);
		}
		timeBtwBlinking = new WaitForSeconds(0.1f);
	}
		
	public void OnMouseUpAsButton(){

        //если достаточно денег, то запускаем рулетку
		if (PlayerPrefs.GetInt ("Coins") >= price) {
			anim.enabled = false;//выключение анимации 
			StartCoroutine (TimeBtwRandom ());

			for (int k = 0; k < allArrows.Length; k++) {
				
				allArrows [k].GetComponent<Button> ().interactable = false;
			}
			gameObject.GetComponent<Button> ().interactable = false;
			back.GetComponent<Button> ().interactable = false;

			PlayerPrefs.SetInt ("BuyArrowCount", 1);
			removeNum = Random.Range (0, closeArrows.Count);
			PlayerPrefs.SetString (closeArrows [removeNum].name, "Open");

			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - price);
            coinsCount.ShowMoney();
		} else { //если НЕ достаточно денег, то выводим сообщение об этом
			Text textPrefab = Instantiate (notEnoughCoinsText, transform.position, Quaternion.identity) as Text;
			textPrefab.transform.SetParent (transform, false);
		}
	}

    IEnumerator TimeBtwRandom() {

        if (closeArrows.Count > 1)
        {
			//включаем музыку для рандома и выключаем музыку главной темы
			if (audioManager.CheckEnabled("ShopRandom"))
			{//если музыка рандома отключена, то НЕ отключаем главную тему
				audioManager.Stop("MainTheme");
				audioManager.Play("ShopRandom");

			}
            //Анимация выбора случайного скина
            randGO = closeArrows[Random.Range(0, closeArrows.Count)];
            for (int i = 0; i < 75; i++)
            {

                //цикл, чтобы повторно не выбирался скин
                previousRandGO = randGO;
                while (randGO == previousRandGO)
                {
                    randGO = closeArrows[Random.Range(0, closeArrows.Count)];
                }
                selectSprite.transform.position = randGO.transform.transform.position;

                yield return new WaitForSeconds(0.2f);//время между выбором следующего скина

            }
			//включаем музыку для главной темы
			if (audioManager.CheckEnabled("ShopRandom"))//если музыка рандома отключена, то НЕ перезапускаем главную тему
				audioManager.Play("MainTheme");
        }
		if (audioManager.CheckEnabled("Click"))
			audioManager.Play("Click");//щелчок

        selectSprite.transform.position = closeArrows [removeNum].transform.position;

				//Мигание окончательно выбранного скина
				for (int j = 0; j < 3; j++) {

                selectSprite.enabled = false;
				yield return timeBtwBlinking;//время между морганием

                selectSprite.enabled = true;
				yield return timeBtwBlinking;//время между морганием
				}

        
        PlayerPrefs.SetString ("Now Arrow", closeArrows[removeNum].name);

			    _previewArrowSpriteImage.sprite = closeArrows [removeNum].GetComponent<SelectArrows> ().arrowSprite;
			    closeArrows [removeNum].GetComponent<Image> ().sprite = closeArrows [removeNum].GetComponent<SelectArrows> ().unlockedArrowSprite;

				closeArrows.Remove (closeArrows[removeNum]);

				for (int k = 0; k < allArrows.Length; k++) {
					allArrows [k].GetComponent<Button> ().interactable = true;
				}
				gameObject.GetComponent<Button> ().interactable = true;
				back.GetComponent<Button> ().interactable = true;

        if (closeArrows.Count < 1)
        {//если не осталось скинов, то кнопка рандома пропадает
			PlayerPrefs.SetInt("AllSkinsBought", 1);
			CheckAllSkinsBought();
        }

        CheckMoney ();

        
    }

	void CheckAllSkinsBought()
	{
		if (PlayerPrefs.GetInt("AllSkinsBought") == 1)
		{
			Destroy(gameObject);
			_watchVideoBtnRectTransform.position = new Vector2(_watchVideoBtnRectTransform.position.x - 75,
				_watchVideoBtnRectTransform.position.y);
		}
	}
	}


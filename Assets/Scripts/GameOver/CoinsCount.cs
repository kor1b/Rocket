using UnityEngine;
using UnityEngine.UI;

public class CoinsCount : MonoBehaviour
{

	public ScoreController scoreController;

	Text coinsText;

	public bool showMoney;//true - объект только отображает количество денег

	public int coins;

	private void OnEnable()
	{
		ShowMoney();
	}

	/*private void FixedUpdate()
	{		
			ShowMoney();
	}*/

	void Awake()
	{
		coinsText = GetComponent<Text>();

		if (!showMoney)
		{//проверка на то, в магазине ли мы

			if (scoreController.score <= 300)
				coins = 0;

			else if (300 < scoreController.score && scoreController.score <= 500)
				coins = 1;

			else if (500 < scoreController.score && scoreController.score < 800)
				coins = Random.Range(2, 4);

			else if (800 < scoreController.score && scoreController.score < 1000)
				coins = Random.Range(3, 5);

			else if (1000 < scoreController.score && scoreController.score <= 2000)
				coins = Random.Range(5, 7);

			else if (2000 < scoreController.score && scoreController.score <= 3000)
				coins = Random.Range(7, 10);

			else if (3000 < scoreController.score && scoreController.score <= 5000)
				coins = Random.Range(10, 15);

			else if (scoreController.score > 5000 && scoreController.score <= 7000)
				coins = Random.Range(15, 20);

			else if (7000 < scoreController.score && scoreController.score <= 10000)
				coins = Random.Range(20, 30);

			else if (scoreController.score > 10000 && scoreController.score <= 20000)
				coins = Random.Range(30, 50);

			else if (scoreController.score > 20000)
				coins = Random.Range(50, 70);

			PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + coins);
		}
		ShowMoney();
	}

	public void ShowMoney()
	{
		coinsText.text = PlayerPrefs.GetInt("Coins").ToString();//выводим кол-во монет
	}
}


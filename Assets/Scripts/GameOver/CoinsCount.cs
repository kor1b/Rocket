using UnityEngine;
using UnityEngine.UI;

public class CoinsCount : MonoBehaviour {

	public ScoreController scoreController;

	public bool showMoney;//true - объект только отображает количество денег

	public int coins;

	private void OnEnable()
	{
		ShowMoney();
	}

	void Awake () {

		if (!showMoney) {//проверка на то, в магазине ли мы

			if (scoreController.score <= 300)
				coins = 0;

			else if (300 < scoreController.score && scoreController.score <= 500)
				coins = Random.Range(0, 2);

			else if (500 < scoreController.score && scoreController.score < 1000)
				coins = Random.Range(1, 3);

			else if (1000 < scoreController.score && scoreController.score <= 3000)
				coins = Random.Range(2, 4);

			else if (3000 < scoreController.score && scoreController.score <= 5000)
				coins = Random.Range(3, 6);

			else if (scoreController.score > 5000 && scoreController.score <= 10000)
				coins = Random.Range(5, 11);

			else if (scoreController.score > 10000 && scoreController.score <= 20000)
				coins = Random.Range(10, 21);

			else if (scoreController.score > 20000)
				coins = Random.Range(20, 41);

			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + coins);
		}
        ShowMoney();
	}

    public void ShowMoney()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();//выводим кол-во монет
    }
}

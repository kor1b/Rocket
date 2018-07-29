using UnityEngine;
using UnityEngine.UI;

public class CoinsCount : MonoBehaviour {

	public ScoreController scoreController;

	public bool showMoney;//true - объект только отображает количество денег

	public int coins; 

	void Start () {

		if (!showMoney) {//проверка на то, в магазине ли мы

				if (scoreController.score <= 1000)
					coins = 10;

			if (1000 < scoreController.score && scoreController.score <= 3000)
					coins = Random.Range (0, 3);

				if (3000 < scoreController.score && scoreController.score <= 5000)
					coins = Random.Range (3, 5);

				if (scoreController.score > 5000)
					coins = Random.Range (5, 10);

				PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") + coins);
		}
        ShowMoney();
	}

    public void ShowMoney()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("Coins").ToString();//выводим кол-во монет
    }
}

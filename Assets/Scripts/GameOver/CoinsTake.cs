using UnityEngine;
using UnityEngine.UI;

public class CoinsTake : MonoBehaviour
{
	public CoinsCount coinsCount;

	void Start()
	{
		GetComponent<Text>().text = "+ " + coinsCount.coins.ToString();
	}
}

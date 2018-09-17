using UnityEngine.Purchasing;
using UnityEngine;

public class Game : MonoBehaviour {

	public void AddEvent () {
		PurchaseManager.OnPurchaseNonConsumable += PurchaseManager_OnPurchaseNonConsumable;
	}

	private void PurchaseManager_OnPurchaseNonConsumable(PurchaseEventArgs args)
	{
		if (PlayerPrefs.GetInt("no_adsBought") != 1)
		{
			Debug.Log("Your purchase: " + args.purchasedProduct.definition.id);
			PlayerPrefs.SetInt("no_adsBought", 1);
			Debug.Log(PlayerPrefs.GetInt("no_adsBought"));
		}
	}
}

/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class ADSController : MonoBehaviour, IRewardedVideoAdListener {

	const string appKey = "b29e62fae4e288032603b1a42059e402efefd26970fa8a32";

	public static int loseCount;//счетчик смертей

	static ADSController instance;
	CoinsCount coinsCount;

	void InitAds()
	{
		Appodeal.disableLocationPermissionCheck();
		Appodeal.initialize(appKey, Appodeal.BANNER | Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);
		Appodeal.setRewardedVideoCallbacks(this);
	}


	void Start()
	{
		InitAds();
		ShowBanner();
	}

	public void ShowInterstitial()
	{
		loseCount++;
		Debug.Log(loseCount);
		if (loseCount == 7)
		{
			//if (Appodeal.isLoaded(Appodeal.INTERSTITIAL))
			//{
				Appodeal.show(Appodeal.INTERSTITIAL);
				loseCount = 0;
			//}
			//else
			//	loseCount = 6;
		}
		//else if (loseCount == 15)
			//Appodeal.show(Appodeal.vide)
	}

	public void ShowBanner()
	{
		//if (Appodeal.isLoaded(Appodeal.BANNER))
			Appodeal.show(Appodeal.BANNER_BOTTOM);

		
	}

	public void ShowRewardedVideo() {
		//if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
			Appodeal.show(Appodeal.REWARDED_VIDEO);
	}

	#region Rewarded Video callback handlers
	public void onRewardedVideoLoaded(bool isPrecache) { print("Video loaded"); }
	public void onRewardedVideoFailedToLoad() { print("Video failed"); }
	public void onRewardedVideoShown() { print("Video shown"); }
	public void onRewardedVideoClosed(bool finished) { print("Video closed"); }
	public void onRewardedVideoFinished(double amount, string name) { PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 50);
		coinsCount.ShowMoney();
	}
	public void onRewardedVideoExpired() { Debug.Log("Video expired"); }
	#endregion
}
*/

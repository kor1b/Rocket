using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class ADSController : MonoBehaviour, IRewardedVideoAdListener {

	const string appKey = "fb8058d83db46700c711298e1110805894e176233719122f";

	public static int loseCount;//счетчик смертей

	static ADSController instance;
	CoinsCount coinsCount;

	void InitAds()
	{
		Appodeal.disableNetwork("inmobi");
		Appodeal.disableLocationPermissionCheck();
		Appodeal.initialize(appKey, Appodeal.BANNER | Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);
		Appodeal.setRewardedVideoCallbacks(this);
	}


	void Start()
	{
		InitAds();
		//ShowBanner();
	}

	public void ShowInterstitial()
	{
		loseCount++;
		Debug.Log(loseCount);
		if (loseCount == 7)//если 7 проигрышей, то показывается реклама
				Appodeal.show(Appodeal.INTERSTITIAL);
	}

	/*показывается баннер
	 public void ShowBanner() 
	{
			Appodeal.show(Appodeal.BANNER_BOTTOM);
	}*/

	public void ShowRewardedVideo() {
			Appodeal.show(Appodeal.REWARDED_VIDEO);
	}

	#region Rewarded Video callback handlers
	public void onRewardedVideoLoaded(bool isPrecache) { print("Video loaded"); }
	public void onRewardedVideoFailedToLoad() { print("Video failed"); }
	public void onRewardedVideoShown() { print("Video shown");
		coinsCount.ShowMoney();
	}
	public void onRewardedVideoClosed(bool finished) { print("Video closed"); }
	public void onRewardedVideoFinished(double amount, string name) { PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 50);
		coinsCount.ShowMoney();
	}
	public void onRewardedVideoExpired() { Debug.Log("Video expired"); }
	#endregion
}


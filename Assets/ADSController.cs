using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class ADSController : MonoBehaviour, IRewardedVideoAdListener {

	const string appKey = "fb8058d83db46700c711298e1110805894e176233719122f";

	public static int loseCount;//счетчик смертей

	public bool rewardedVideoShowed = false;

	static ADSController instance;
	CoinsCount coinsCount;

	void InitAds()
	{
		Appodeal.disableNetwork("inmobi");
		Appodeal.disableLocationPermissionCheck();
		Appodeal.disableWriteExternalStoragePermissionCheck();
		Appodeal.initialize(appKey, Appodeal.BANNER | Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);
		Appodeal.setRewardedVideoCallbacks(this);
	}

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);
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
		coinsCount.ShowMoney();
	}

	#region Rewarded Video callback handlers
	public void onRewardedVideoLoaded(bool isPrecache) { print("Video loaded"); }
	public void onRewardedVideoFailedToLoad() { print("Video failed"); }
	public void onRewardedVideoShown() { print("Video shown");}
	public void onRewardedVideoClosed(bool finished) { print("Video closed");}
	public void onRewardedVideoFinished(double amount, string name) { PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 50);
		rewardedVideoShowed = true;
	}
	public void onRewardedVideoExpired() { Debug.Log("Video expired");}
	#endregion
}


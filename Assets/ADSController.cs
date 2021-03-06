﻿using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using UnityEngine.UI;

public class ADSController : MonoBehaviour, IRewardedVideoAdListener {

	const string appKey = "fb8058d83db46700c711298e1110805894e176233719122f";

	public static int loseCount;//счетчик смертей

	public Text noAdsNow;
	public GameObject noAdsNowParentShop;
	public GameObject noAdsNowParentGameOver;

	static ADSController instance;

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
		Debug.Log(loseCount + "loses");
		if (loseCount == 7)
		{//если 7 проигрышей, то показывается реклама
			Appodeal.show(Appodeal.INTERSTITIAL);
			Debug.Log("7 lose");
		}
	}

	/*показывается баннер
	 public void ShowBanner() 
	{
			Appodeal.show(Appodeal.BANNER_BOTTOM);
	}*/

	public void ShowRewardedVideo() {
		if (!Appodeal.isLoaded(Appodeal.REWARDED_VIDEO) && noAdsNowParentShop)
		    Instantiate(noAdsNow, noAdsNow.transform.position, Quaternion.identity, noAdsNowParentShop.transform);
        else if (!Appodeal.isLoaded(Appodeal.REWARDED_VIDEO) && noAdsNowParentGameOver)
			Instantiate(noAdsNow, noAdsNow.transform.position, Quaternion.identity, noAdsNowParentGameOver.transform);
		else
			Appodeal.show(Appodeal.REWARDED_VIDEO);

		if(FindObjectOfType<RandomBuy>())
		FindObjectOfType<RandomBuy>().CheckMoney();
	}

	#region Rewarded Video callback handlers
	public void onRewardedVideoLoaded(bool isPrecache) { print("Video loaded"); }
	public void onRewardedVideoFailedToLoad() { print("Video failed"); }
	public void onRewardedVideoShown() { print("Video shown");
	}
	public void onRewardedVideoClosed(bool finished) { print("Video closed");}
	public void onRewardedVideoFinished(double amount, string name) { PlayerPrefs.SetInt("Coins", PlayerPrefs.GetInt("Coins") + 50);
		FindObjectOfType<CoinsCount>().ShowMoney();
	}
	public void onRewardedVideoExpired() { Debug.Log("Video expired");
	}
	#endregion
}


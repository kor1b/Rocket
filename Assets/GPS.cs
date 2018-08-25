using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GPS : MonoBehaviour {

	public const string leaderboard = "CgkIrOW39fQEEAIQAQ";
	static GPS Instance { set; get; }
	public bool isLogenIn;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			isLogenIn = false;
			PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
			PlayGamesPlatform.InitializeInstance(config);
			PlayGamesPlatform.DebugLogEnabled = true;
			PlayGamesPlatform.Activate();
			SignIn();
			DontDestroyOnLoad(gameObject);
		}
		else
			Destroy(gameObject);
	}

	void SignIn()
	{
		if (isLogenIn == false)
		{
			Social.localUser.Authenticate(success =>
			{
				isLogenIn = success;
			});
		}
	}
}

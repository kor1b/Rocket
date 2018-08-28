using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class GPS : MonoBehaviour
{
	public const string leaderboard = "CgkIl__F3doMEAIQAQ";
	public static GPS Instance { set; get; }
	public bool isLogedIn;
	void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
			isLogedIn = false;
			PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
			PlayGamesPlatform.InitializeInstance(config);
			PlayGamesPlatform.DebugLogEnabled = true;
			PlayGamesPlatform.Activate();
			SignIn();
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void SignIn()
	{
		if (isLogedIn == false)
		{
			Social.localUser.Authenticate(success => {
				isLogedIn = success;
			});
		}
	}
}
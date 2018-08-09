using UnityEngine;

public class DontDestroyScript : MonoBehaviour {

	static DontDestroyScript instance;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else
		{
            Destroy(gameObject);
			return;
		}

		DontDestroyOnLoad(gameObject);
	}
}

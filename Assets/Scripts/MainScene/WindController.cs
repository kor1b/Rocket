using UnityEngine;

public class WindController : MonoBehaviour {

	public HazardController hazardController;
	public GameController gameController;
	
	void Update () {

		if (hazardController.tap && !gameController.gameHasEnded)
			gameObject.SetActive(true);

		else if (!hazardController.tap || gameController.gameHasEnded)
			gameObject.SetActive(false);
	}
}

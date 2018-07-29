using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour {
	public Text scoreText;
	public GameController gameController;
	public int score;

	void Update () {

        if (gameController.gameHasEnded == false)
        {
            score++;
            scoreText.text = score.ToString();
        }
	}
}

using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public ScoreController scoreController;

	void Start () {

		GetComponent<Text> ().text = scoreController.score.ToString();

	}
}

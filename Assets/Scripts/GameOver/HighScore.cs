using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public ScoreController scoreController;

	void Start(){

        if (scoreController.score > PlayerPrefs.GetInt("HighScore", 0)) { 

            PlayerPrefs.SetInt("HighScore", scoreController.score);
			GetComponent<Text> ().text = "NEW HIGH SCORE";
			GetComponent<Animator> ().enabled = true;
		}
		else 
			GetComponent<Text> ().text = "HIGH SCORE: " + PlayerPrefs.GetInt ("HighScore").ToString ();

	}
}

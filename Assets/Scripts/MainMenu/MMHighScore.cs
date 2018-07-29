using UnityEngine;
using UnityEngine.UI;

public class MMHighScore : MonoBehaviour {

	void OnEnable () {
		GetComponent<Text> ().text = "Score: " + PlayerPrefs.GetInt ("HighScore").ToString ();

	}

}

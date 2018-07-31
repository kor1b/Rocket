using UnityEngine;
using UnityEngine.UI;

public class MMHighScore : MonoBehaviour {

	void OnEnable () {
		GetComponent<Text> ().text = "BEST: " + PlayerPrefs.GetInt ("HighScore").ToString ();

	}

}

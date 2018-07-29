using UnityEngine;

public class BuyArrow : MonoBehaviour {

	public GameObject whichArrow; 


	public void OnMouseUpAsButton (){

		if (PlayerPrefs.GetInt ("Coins") >= PlayerPrefs.GetInt ("Price")){

			PlayerPrefs.SetString ("Now Arrow", whichArrow.GetComponent<IconsArray> ().arrowName);
			PlayerPrefs.SetInt ("BuyArrowCount", 1);
			Debug.Log (PlayerPrefs.GetInt ("BuyArrowCount"));


			PlayerPrefs.SetString (whichArrow.GetComponent<IconsArray> ().arrowName, "Open");
			PlayerPrefs.SetInt ("Coins", PlayerPrefs.GetInt ("Coins") - PlayerPrefs.GetInt ("Price"));
			gameObject.SetActive (false);
	}

}
}
